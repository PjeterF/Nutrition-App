using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NutritionApp.Models
{
    public class FoodNutrient
    {
        public FoodNutrient()
        {

        }
        public FoodNutrient(string jsonFoodNutrient)
        {
            JObject jobj = JObject.Parse(jsonFoodNutrient);

            this.NutrientId = (int)jobj["nutrientId"];
            this.Name = (string)jobj["nutrientName"];

            switch((string)jobj["unitName"])
            {
                case "G":
                    this.Value = (float)jobj["value"];
                    this.UnitName = "G";
                    break;
                case "MG":
                    this.Value = (float)jobj["value"]*0.001f;
                    this.UnitName = "G";
                    break;
                case "UG":
                    this.Value = (float)jobj["value"] * 0.000001f;
                    this.UnitName = "G";
                    break;
                case "KCAL":
                    this.Value = (float)jobj["value"];
                    this.UnitName = "KCAL";
                    break;
                case "IU":
                    this.Value = (float)jobj["value"];
                    this.UnitName = "IU";
                    break;
            }
        }
        [JsonProperty("nutrientId")]
        public int NutrientId { get; set; }
        [JsonProperty("nutrientName")]
        public string Name { get; set; }
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
