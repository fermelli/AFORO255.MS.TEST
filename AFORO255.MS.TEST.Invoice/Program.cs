using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Invoce.Persistences;
using AFORO255.MS.TEST.Invoce.Services;
using AFORO255.MS.TEST.Invoce.Data;
using MediatR;
using Aforo255.Cross.Event.Src;
using AFORO255.MS.TEST.Invoice.Messages.EventHandlers;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Messages.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["postgres:cn"]);
    }
);
builder.Services.AddScoped<IInvoceService, InvoceService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<PayEventHandler>();
builder.Services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
}
