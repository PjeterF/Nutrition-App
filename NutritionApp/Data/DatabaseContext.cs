using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Email = "DEMO@demo.com", Username = "DEMO_User", Password = "DEMO" }
                );

            modelBuilder.Entity<FoodSet>()
                .HasMany(x => x.FoodItems)
                .WithMany(x => x.FoodSets)
                .UsingEntity<FoodItemSet>();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodSet> FoodSets { get; set; }
        public DbSet<FoodItemSet> FoodItemSet_JOIN { get; set; }
    }
}
