using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace NutritionApp.Models
{
    public class Food
    {
        public Food(string jsonFood, string endpoint="search")
        {
            JObject jFood= JObject.Parse(jsonFood);

            this.USDA_ID = (int)jFood["fdcId"];

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

            if (jFood["dataType"] != null)
                this.DataType = (string)jFood["dataType"];
            else
                this.DataType = "Null";

            this.Nutrients = new List<FoodNutrient>();

            foreach(var jNutrient in jFood["foodNutrients"])
            {
                JObject jObjNutrient = jNutrient.ToObject<JObject>();
                FoodNutrient foodNutrient = new FoodNutrient(jObjNutrient.ToString(), endpoint);
                this.Nutrients.Add(foodNutrient);
            }
        }
        public int USDA_ID { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int ServingSize { get; set; }
        public string ServingSizeUnit { get; set; }
        public List<FoodNutrient> Nutrients { get; set;}
        public string DataType { get; set; }
    }
}
