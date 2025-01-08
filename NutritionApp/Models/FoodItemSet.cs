namespace NutritionApp.Models
{
    public class FoodItemSet
    {
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int FoodSetId { get; set; }
        public FoodSet FoodSet { get; set; }
        public float Quantity { get; set; }
    }
}
