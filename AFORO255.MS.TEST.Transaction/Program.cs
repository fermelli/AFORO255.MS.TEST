using AFORO255.MS.TEST.Transaction.Persistences.Settings;
using AFORO255.MS.TEST.Transaction.Persistences;
using Carter;
using AFORO255.MS.TEST.Transaction.Features.Services;
using AFORO255.MS.TEST.Transaction.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.Configure<Mongosettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("mongo:cn").Value;
    opt.DatabaseName = builder.Configuration.GetSection("mongo:database").Value;
});
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();

var app = builder.Build();
app.MapCarter();
app.Run();
