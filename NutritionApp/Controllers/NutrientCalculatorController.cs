using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NutritionApp.Data;
using NutritionApp.Models;
using static System.Net.WebRequestMethods;

namespace NutritionApp.Controllers
{
    public class NutrientCalculatorController : Controller
    {
        DatabaseContext databaseContext;
        HttpClient httpClient;
        public NutrientCalculatorController(DatabaseContext databaseContext, HttpClient client)
        {
            this.databaseContext = databaseContext;
            this.httpClient = client;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FindItem(List<Food>? foodList)
        {
            return View(foodList);
        }
        [HttpPost]
        public async Task<ActionResult> FindItem(string foodName)
        {
            string url = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=PDhtf6KxCYiAEcqI7HZeO8Nb5Eg9FajCV3d6d21J&query=" + foodName;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            JObject jobj = JObject.Parse(json);
            JArray foodList = (JArray)jobj["foods"];

            List<Food> foods = new List<Food>();
            foreach(var jFood in foodList)
            {
                string foodStr = jFood.ToString();
                foods.Add(new Food(foodStr));
            }

            return View(foods);
        }
    }
}
