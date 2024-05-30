using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
    /* This constructor: 
        1) Accepts a parameter of type DbContextOptions<PizzaContext>
        2) Allows external code to pass in the configuration so that
            the same DbContext can be
            a) shared between test & production code &
            b) used with different providers */
    public PizzaContext (DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    /* These DbSet properties correspond to tables to create in the DB.
    The table names will match the property names.
    (You can override this behavior if needed.) */
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();

    /* When you instantiate an object of this type,
    it'll expose the Pizzas, Toppings, & Sauces properties.
    Changes you make to the collcetions that those
    properties expose will be propagated to the DB.*/ 
}