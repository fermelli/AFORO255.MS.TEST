using AFORO255.MS.TEST.Transaction.Persistences.Settings;
using AFORO255.MS.TEST.Transaction.Persistences;
using Carter;
using AFORO255.MS.TEST.Transaction.Features.Services;
using AFORO255.MS.TEST.Transaction.Services;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transactiones.EventHandlers;
using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.Configure<Mongosettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("mongo:cn").Value;
    opt.DatabaseName = builder.Configuration.GetSection("mongo:database").Value;
});
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<PayEventHandler>();
builder.Services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();

var app = builder.Build();
app.MapCarter();

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
}

