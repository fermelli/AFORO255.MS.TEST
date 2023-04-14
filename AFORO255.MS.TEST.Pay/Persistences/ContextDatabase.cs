using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Pay.Models;

namespace AFORO255.MS.TEST.Pay.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    public DbSet<PayModel> PayModel => Set<PayModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.PayModel>().ToTable("Pay");
    }
}
