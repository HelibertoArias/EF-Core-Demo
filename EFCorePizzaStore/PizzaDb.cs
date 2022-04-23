using EFCorePizzaStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePizzaStore
{
    public class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
