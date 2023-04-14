using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Invoce.Persistences;
using AFORO255.MS.TEST.Invoce.Services;
using AFORO255.MS.TEST.Invoce.Data;
using MediatR;
using Aforo255.Cross.Event.Src;
using AFORO255.MS.TEST.Invoice.Messages.EventHandlers;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;

var builder = WebApplication.CreateBuilder(args);

IHostBuilder hostBuilder = builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    IConfigurationRoot c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["cn:postgres"]);
    }
);
builder.Services.AddScoped<IInvoceService, InvoceService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<PayEventHandler>();
builder.Services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseConsul();

DbCreated.CreateDbIfNotExists(app);

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
}
