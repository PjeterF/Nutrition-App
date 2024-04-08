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
        FindItemDataStorage findItemDataStorage;
        public NutrientCalculatorController(DatabaseContext databaseContext, HttpClient client, FindItemDataStorage findItemData)
        {
            this.databaseContext = databaseContext;
            this.httpClient = client;
            this.findItemDataStorage = findItemData;
        }
        public IActionResult Index()
        {
            var currUser = HttpContext.Session.GetString("currentUser");
            return View();
        }
        public IActionResult FindItem(int index = -1)
        {
            findItemDataStorage.selectedIndex = index;
            return View(new FindItemData(findItemDataStorage.selectedIndex, findItemDataStorage.foodList));
        }
        [HttpPost]
        public async Task<ActionResult> FindItem(string foodName)
        {
            string url = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=PDhtf6KxCYiAEcqI7HZeO8Nb5Eg9FajCV3d6d21J&query=" + foodName;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            JObject jobj = JObject.Parse(json);
            JArray jList = (JArray)jobj["foods"];

            findItemDataStorage.foodList.Clear();
            foreach (var jFood in jList)
            {
                Food newFood = new Food(jFood.ToString());

                if(newFood.BrandName=="Null")
                    findItemDataStorage.foodList.Add(newFood);
            }

            findItemDataStorage.selectedIndex = -1;
            return View(new FindItemData(findItemDataStorage.selectedIndex, findItemDataStorage.foodList));
        }
    }
}
