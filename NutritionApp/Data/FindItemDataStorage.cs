using NutritionApp.Models;

namespace NutritionApp.Data
{

    public class FindItemDataStorage
    {
        public List<Food> foodList;
        public int selectedIndex;

        public FindItemDataStorage()
        {
            this.foodList = new List<Food>();
            this.selectedIndex = -1;
        }
        public void Reset()
        {
            this.foodList.Clear();
            this.selectedIndex = -1;
        }
    }
}
