using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.Data;
using AFORO255.MS.TEST.Security.Persistences;
using AFORO255.MS.TEST.Security.Services;
using Microsoft.EntityFrameworkCore;

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
        opt.UseSqlServer(builder.Configuration["cn:sql"]);
    }
);
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseConsul();

DbCreated.CreateDbIfNotExists(app);

app.Run();
