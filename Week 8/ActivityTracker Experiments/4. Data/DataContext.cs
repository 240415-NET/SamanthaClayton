using Microsoft.EntityFrameworkCore;
using ActivityTracker.Models;

namespace ActivityTracker.Data;


public class DataContext : DbContext
{
   // public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<User> users { get; set; }
    public DbSet<Activity> activities { get; set; }

    public DataContext () {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
    }

}