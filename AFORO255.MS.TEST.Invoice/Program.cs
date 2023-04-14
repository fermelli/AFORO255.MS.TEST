using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Invoce.Persistences;
using AFORO255.MS.TEST.Invoce.Services;
using AFORO255.MS.TEST.Invoce.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["postgres:cn"]);
    }
);
builder.Services.AddScoped<IInvoceService, InvoceService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();
