using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Index()
        {
            var currUser = HttpContext.Session.GetString("currentUser");
            int curSetId = Int32.Parse(HttpContext.Session.GetString("FoodSetId"));

            var foodSet = databaseContext.FoodSets
                .Where(x => x.Id == curSetId)
                .Include(fs => fs.FoodItems)
                .FirstOrDefault();

            string key = "PDhtf6KxCYiAEcqI7HZeO8Nb5Eg9FajCV3d6d21J";
            string url = "https://api.nal.usda.gov/fdc/v1/foods?fdcIds=";

            for(int i=0;i<foodSet.FoodItems.Count;i++)
            {
                url = url + foodSet.FoodItems[i].USDA_ID;
                if (i < foodSet.FoodItems.Count - 1)
                    url = url + ",";
            }
            url = url+ "&api_key=" + key;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            JArray jArray = JArray.Parse(json);

            List<Food> list = new List<Food>();
            foreach(var jItem in jArray)
            {
                list.Add(new Food(jItem.ToString()));
            }

            return View(list);
        }
        [HttpPost]
        public async Task<ActionResult> Index(int foodId)
        {
            string key = "PDhtf6KxCYiAEcqI7HZeO8Nb5Eg9FajCV3d6d21J";
            string url = "https://api.nal.usda.gov/fdc/v1/food/" + foodId + "?api_key=" + key;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            Food food = new Food(json);

            var currUser = HttpContext.Session.GetString("currentUser");
            return View();
        }
        public IActionResult FindItem(int index = -1)
        {
            findItemDataStorage.selectedIndex = index;
            return View(new FindItemData(findItemDataStorage.selectedIndex, findItemDataStorage.foodList));
        }
        [HttpPost("FindItem/{foodItemId}/{foodSetId}")]
        public IActionResult FindItem(int foodItemId, int foodSetId)
        {
            FoodItem foodItem = databaseContext.FoodItems.Where(x => x.USDA_ID == foodItemId).FirstOrDefault();
            if(foodItem == null)
            {
                foodItem = new FoodItem() { USDA_ID = foodItemId };
                databaseContext.FoodItems.Add(foodItem);
            }

            FoodSet foodSet = databaseContext.FoodSets.Find(foodSetId);
            if (foodSet == null)
            {
                foodSet = new FoodSet();
                databaseContext.FoodSets.Add(foodSet);
            }

            databaseContext.SaveChanges();
            databaseContext.FoodItemSet_JOIN.Add(new FoodItemSet() { FoodItemId=foodItem.Id, FoodSetId=foodSetId });
            databaseContext.SaveChanges();

            return RedirectToAction("Index", "NutrientCalculator");
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

                if(newFood.DataType!="Branded")
                    findItemDataStorage.foodList.Add(newFood);
            }

            findItemDataStorage.selectedIndex = -1;
            return View(new FindItemData(findItemDataStorage.selectedIndex, findItemDataStorage.foodList));
        }
    }
}
