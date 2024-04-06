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
            this.UnitName = (string)jobj["unitName"];
            this.Value = (int)jobj["value"];
        }
        [JsonProperty("nutrientId")]
        public int NutrientId { get; set; }
        [JsonProperty("nutrientName")]
        public string Name { get; set; }
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
