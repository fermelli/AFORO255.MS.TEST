using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Security.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AFORO255.MS.TEST.Security.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    public DbSet<Access> Access => Set<Access>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>().ToTable("Access");
    }
}
