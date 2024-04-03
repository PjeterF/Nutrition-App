using Microsoft.EntityFrameworkCore;
using NutritionApp.Models;

namespace NutritionApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem { Id = 1, Name = "White Rice 100g", Calories = 340 },
                new FoodItem { Id = 2, Name = "Beluga Lentils 100g", Calories = 357 },
                new FoodItem { Id = 3, Name = "Soybeans 100g", Calories = 412 }
                );
        }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
