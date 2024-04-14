using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace NutritionApp.Models
{
    public class FoodNutrient
    {
        public FoodNutrient()
        {

        }
        public FoodNutrient(string jsonFoodNutrient, string endpoint="search")
        {
            switch (endpoint)
            {
                case "search":
                    {
                        JObject jobj = JObject.Parse(jsonFoodNutrient);

                        this.NutrientId = (int)jobj["nutrientId"];
                        this.Name = (string)jobj["nutrientName"];

                        if (this.NutrientId == 2047)
                            this.NutrientId = 1008;

                        switch ((string)jobj["unitName"])
                        {
                            case "G":
                                this.Value = (float)jobj["value"];
                                this.UnitName = "G";
                                this.OGUnitName = "G";
                                break;
                            case "MG":
                                this.Value = (float)jobj["value"] * 0.001f;
                                this.UnitName = "G";
                                this.OGUnitName = "MG";
                                break;
                            case "UG":
                                this.Value = (float)jobj["value"] * 0.000001f;
                                this.UnitName = "G";
                                this.OGUnitName = "UG";
                                break;
                            case "KCAL":
                                this.Value = (float)jobj["value"];
                                this.UnitName = "KCAL";
                                this.OGUnitName = "KCAL";
                                break;
                            case "IU":
                                this.Value = (float)jobj["value"];
                                this.UnitName = "IU";
                                this.OGUnitName = "IU";
                                break;
                        }
                    }
                break;

                case "foods":
                {
                        JObject jobj = JObject.Parse(jsonFoodNutrient);

                        this.NutrientId = (int)jobj["nutrient"]["id"];
                        this.Name = (string)jobj["nutrient"]["name"];

                        if (this.NutrientId == 2047)
                            this.NutrientId = 1008;

                        switch ((string)jobj["nutrient"]["unitName"])
                        {
                            case "g":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"];
                                else
                                    this.Value = 0;
                                this.UnitName = "g";
                                this.OGUnitName = "g";
                                break;
                            case "mg":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"] * 0.001f;
                                else
                                    this.Value = 0;
                                this.UnitName = "g";
                                this.OGUnitName = "mg";
                                break;
                            case "µg":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"] * 0.000001f;
                                else
                                    this.Value = 0;
                                this.UnitName = "g";
                                this.OGUnitName = "µg";
                                break;
                            case "kcal":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"];
                                else
                                    this.Value = 0;
                                this.UnitName = "kcal";
                                this.OGUnitName = "kcal";
                                break;
                            case "KCAL":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"];
                                else
                                    this.Value = 0;
                                this.UnitName = "kcal";
                                this.OGUnitName = "kcal";
                                break;
                            case "iu":
                                if (jobj.GetValue("amount") != null)
                                    this.Value = (float)jobj["amount"];
                                else
                                    this.Value = 0;
                                this.UnitName = "iu";
                                this.OGUnitName = "iu";
                                break;
                        }
                    }
                break;
            }
        }
        [JsonProperty("nutrientId")]
        public int NutrientId { get; set; }
        [JsonProperty("nutrientName")]
        public string Name { get; set; }
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        public string OGUnitName { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
