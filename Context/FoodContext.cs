using Microsoft.EntityFrameworkCore;
using RandomFoodSelection.EntityConfiguration;
using RandomFoodSelection.Model;

namespace RandomFoodSelection.Context
{
    public class FoodContext : DbContext
    {
        // to connect our db to .net core
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {

        }

        // Convert Models to DbSets, queries against this DbSet will be translated to queries against database.
        public DbSet<Food> Food { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FoodEntityConfiguration());
        }

    }
}
