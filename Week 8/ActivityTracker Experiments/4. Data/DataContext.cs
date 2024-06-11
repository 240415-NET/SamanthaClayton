using Microsoft.EntityFrameworkCore;
using ActivityTracker.Models;

namespace ActivityTracker.Data;


public class DataContext : DbContext
{
   // public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activity { get; set; }

    public DataContext () {}
    public DataContext(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
               modelBuilder.Entity<Activity>().UseTpcMappingStrategy()
            .ToTable("Activity");

        modelBuilder.Entity<User>()
            .ToTable("Users");
 modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
    }

}