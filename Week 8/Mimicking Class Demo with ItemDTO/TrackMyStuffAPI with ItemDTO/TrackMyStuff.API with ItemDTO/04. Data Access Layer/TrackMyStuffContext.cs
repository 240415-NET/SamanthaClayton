using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

/*

This class is going to be our "Database Context"
class for our application.

It will handle our EF Core database communication.

We only need 1 class that inherits from EF Core's
DBContext class in our application (assuming you
just have 1 database).

We're going to instantiate an object of this class in
UserStorage and ItemStorage classes & that will give us
access to methods that talk to our database for us,
completely abstracting away writing any SQL.

*/

public class TrackMyStuffContext : DbContext 
{
    /*
    We have to make our context class aware of the model
    classes that it needs to track for us. It will look
    similar to setting up class fields, but we'll do it in
    the specific format that EF Core needs us to do it.
    Instead of List<Users>, List<Items>, etc., we use
    DbSet<User>, DbSet<Items>, etc. for each model class.

    MAKE SURE YOU HAVE A GET; SET; AFTER EACH.

    Each of these will ultimately be our tables.
    */
    public DbSet<User> Users {get; set;}
    public DbSet<Item> Items {get; set;}
    public DbSet<Pet> Pets {get; set;}
    public DbSet<Document> Documents {get; set;}

    public TrackMyStuffContext(){}

    /*
    In order to create/apply a migration, we need a 
    constructor that accepts a DbContextOptions and
    passes it ot the base constructor that comes in from the
    DbContext parent class.

    The " : base (options)" here means we also pass it to the
    base constructor.
    */
    public TrackMyStuffContext(DbContextOptions options) : base (options) {}

    /*
    In order to tweak EF Core's default behavior/
    assumptions of what we want in our database (whether
    it's in regards to things like the table structure,
    relationships, primary key/foreign key, how it handles
    inheritance, etc.), we need to explicitly override a method
    that comes from the DbContext base class called
    OnModelCreating().
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        We are going to override EF Core's
        default assupmtion as to how we want our items,
        pets, and documents to be modeled in our database.

        We're going to force EF Core to use
        Table-Per-Concrete-Type mapping.

        This will create a separate table with all columns
        for objects that are part of an inheritance hierarchy.
        We will add this call for each of our models in the hierarchy.
        */

        modelBuilder.Entity<Item>().UseTpcMappingStrategy()
            .ToTable("Items");
        modelBuilder.Entity<Pet>()
            .ToTable("Pet");
        modelBuilder.Entity<Document>()
            .ToTable("Documents");

        /* You don't need ot do this part, but since we 
        named all of our other tables,  why not explicitly
        name the Users table.  This is how you
        can name the tables if ya want. */
        
        modelBuilder.Entity<User>()
            .ToTable("Users");

        /* This is how you make your SQL database
        become case sensitive. */
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
    }


}