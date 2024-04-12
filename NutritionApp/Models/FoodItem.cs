using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionApp.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public int USDA_ID { get; set; }
        public List<FoodSet> FoodSets { get; set; }
    }
}
