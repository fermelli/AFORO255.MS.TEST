using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.Data;
using AFORO255.MS.TEST.Security.Persistences;
using AFORO255.MS.TEST.Security.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration["sql:cn"]);
    }
);
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();