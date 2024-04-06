using Microsoft.AspNetCore.Mvc;
using NutritionApp.Data;
using NutritionApp.Models;

namespace NutritionApp.Controllers
{
    public class FoodItemController : Controller
    {
        private DatabaseContext databaseContext;
        private HttpClient client;
        public FoodItemController(DatabaseContext databaseContext, HttpClient client)
        {
            this.databaseContext = databaseContext;
            this.client = client;
        }
        public async Task<ActionResult> Index()
        {
            string url = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=DEMO_KEY&query=Cheddar%20Cheese";
            HttpResponseMessage response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            List<FoodItem> FoodItemList = databaseContext.FoodItems.ToList();
            return View(FoodItemList);
        }

        public IActionResult AddFoodItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFoodItem(FoodItem foodItem)
        {
            if(ModelState.IsValid)
            {
                databaseContext.FoodItems.Add(foodItem);
                databaseContext.SaveChanges();
                return RedirectToAction("Index", "FoodItem");
            }

            return View();
        }
        public IActionResult Edit(int id)
        {
            FoodItem item = databaseContext.FoodItems.Find(id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                databaseContext.FoodItems.Update(foodItem);
                databaseContext.SaveChanges();
                return RedirectToAction("Index", "FoodItem");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            databaseContext.FoodItems.Remove(databaseContext.FoodItems.Find(id));
            databaseContext.SaveChanges();
            return RedirectToAction("Index", "FoodItem");
        }
    }
}
