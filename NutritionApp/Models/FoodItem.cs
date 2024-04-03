using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NutritionApp.Models
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1, 2000)]
        public int Calories { get; set; }
    }
}
