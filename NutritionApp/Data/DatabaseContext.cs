using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NutritionApp.Models;
using NutritionApp.Models.FoodCollection;

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
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Email = "DEMO@demo.com", Username = "DEMO_User", Password = "DEMO" }
                );
            modelBuilder.Entity<FoodCollection>()
                .HasMany<Item>(i => i.Items)
                .WithMany(c => c.Collections);
                
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Coll> foodCollections { get; set; }
    }
}
