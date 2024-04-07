namespace NutritionApp.Models
{
    public class FindItemData
    {
        public FindItemData(int selectedIndex, List<Food> foodList)
        {
            this.selectedIndex = selectedIndex;
            this.foodList = foodList;
        }
        public FindItemData()
        {
            this.selectedIndex = -1;
            this.foodList = new List<Food>();
        }

        public int selectedIndex { get; set; }
        public List<Food> foodList { get; set; }
    }
}
