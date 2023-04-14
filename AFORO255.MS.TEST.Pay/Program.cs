using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Discovery.Mvc;
using Aforo255.Cross.Event.Src;
using AFORO255.MS.TEST.Pay.Data;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Messages.CommandsHandlers;
using AFORO255.MS.TEST.Pay.Persistences;
using AFORO255.MS.TEST.Pay.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Deposit.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["mysql:cn"]);
    }
);
builder.Services.AddScoped<IPayService, PayService>();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<IRequestHandler<PayCreateCommand, bool>, PayCommandHandler>();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();


app.UseAuthorization();
app.MapControllers();
app.UseConsul();

DbCreated.CreateDbIfNotExists(app);

app.Run();
