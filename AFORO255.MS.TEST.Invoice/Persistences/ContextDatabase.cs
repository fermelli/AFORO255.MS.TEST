using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Invoce.Models;

namespace AFORO255.MS.TEST.Invoce.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    public DbSet<InvoceModel> Invoce => Set<InvoceModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.InvoceModel>().ToTable("Invoce");
    }
}

