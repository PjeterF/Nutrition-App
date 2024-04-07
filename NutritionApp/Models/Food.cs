using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace NutritionApp.Models
{
    public class Food
    {
        public Food(string jsonFood)
        {
            JObject jFood= JObject.Parse(jsonFood);

            this.FdcId = (int)jFood["fdcId"];

            if (jFood["description"] != null)
                this.Name = (string)jFood["description"];
            else
                this.Name = "Null";

            if (jFood["brandName"] != null)
                this.BrandName = (string)jFood["brandName"];
            else
                this.BrandName = "Null";

            if (jFood["servingSize"] != null)
                this.ServingSize = (int)jFood["servingSize"];
            else
                this.ServingSize = -1;

            if (jFood["descservingSizeUnitription"] != null)
                this.ServingSizeUnit = (string)jFood["servingSizeUnit"];
            else
                this.ServingSizeUnit = "Null";

            this.Nutrients = new List<FoodNutrient>();

            foreach(var jNutrient in jFood["foodNutrients"])
            {
                JObject jObjNutrient = jNutrient.ToObject<JObject>();
                FoodNutrient foodNutrient = jObjNutrient.ToObject<FoodNutrient>();
                this.Nutrients.Add(foodNutrient);
            }
        }
        public int FdcId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int ServingSize { get; set; }
        public string ServingSizeUnit { get; set; }
        public List<FoodNutrient> Nutrients { get; set;}
    }
}
