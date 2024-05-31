using Microsoft.EntityFrameworkCore;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

// This class is going to be our "Database Context" class
// for our application.  We only need one class that inherits
// from the EF Core DbContext class in our app (assuming you have
// one database and one database only).
// This class is what will handle our EF Core database
// communication for us.
// We're going to instantiate an object of this context class
// somewhere and this will give us the methods that talk to our
// DB for us, completely abstracting away writing any SQL.
public class TrackMyStuffContext : DbContext // DbContext comes in as part of Microsoft.EntityFrameworkCore
{
    // We need to make our Context class aware of the model
    // classes it needs to track for us.  It's going to look like we're
    // setting up class fields, but they need ot be done in this specific way.
    // We're not going to create a list of documents, items, etc.  We do this
    // by creating DbSets for our model classes. MAKE SURE YOU HAVE A GET; SET;
    // These will ultimately be our tables (or the things that our schema 
    // thta is generated for us is based on)

    public DbSet<User> Users {get; set;}
    public DbSet<Item> Items {get; set;}
    public DbSet<Pet> Pets {get; set;}
    public DbSet<Document> Documents {get; set;}

    // Here is a parameterless constructor
    public TrackMyStuffContext () {}

    // In order to create/apply a migration, we need a contructor
    // that accepts a DbContextOptions and passes it to the base constructor
    // that comes in from the DbContext parent class.
    // : base(options) means we also pass it to the base constructor
    public TrackMyStuffContext(DbContextOptions options) : base (options) {}

    // In order to tweak EF Core's default behavior/assumptions
    // of what we want in our DB, whether it's in regards to things like
    // table structure, relationships, primary key/foreign key, how it handles
    // inheritance, etc., we need to epxlicitly override a method that comes
    // from the DbContext base class called OnModelCreating()
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Here we override EF Core's default assumption as to how we want
        // our items, pets, and documents to be modeled in our database
        // by forcing it to use Table-Per-Concrete-Type mapping.
        // This will create a separate table with all columns for objects
        // that are part of an inheritance hierarchy.
        // We will add this call for each of our models in the hierarchy.
        modelBuilder.Entity<Item>().UseTpcMappingStrategy()
            .ToTable("Items");
        modelBuilder.Entity<Pet>()
            .ToTable("Pets");
        modelBuilder.Entity<Document>()
            .ToTable("Documents");

        // We explicitly named our other tables, so why not explicitly name the Users table?
        modelBuilder.Entity<User>()
            .ToTable("Users");
        
       /* modelBuilder.Entity<User>()
            .HasMany(e => e.items)
            .WithOne(e => e.userId
*/
    }

}