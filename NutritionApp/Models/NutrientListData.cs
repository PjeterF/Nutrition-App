namespace NutritionApp.Models
{
    public class NutrientListData
    {
        public string Name { get; set; }
        public List<NutrientListItem> Items { get; set; }
        public List<Food> Foods { get; set; }
    }
}
