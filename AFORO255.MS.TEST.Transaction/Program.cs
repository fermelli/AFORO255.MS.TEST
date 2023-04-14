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
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;

var builder = WebApplication.CreateBuilder(args);

IHostBuilder hostBuilder = builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    IConfigurationRoot c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.Configure<Mongosettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("cn:mongo").Value;
    opt.DatabaseName = builder.Configuration.GetSection("database:mongo").Value;
});
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<PayEventHandler>();
builder.Services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();
app.MapCarter();
app.UseAuthorization();
app.MapControllers();
app.UseConsul();

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
}

