using Microsoft.AspNetCore.Mvc;
using NutritionApp.Data;
using NutritionApp.Models;

namespace NutritionApp.Controllers
{
    public class AuthController : Controller
    {
        DatabaseContext databaseContext;
        public AuthController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if(email==null || password==null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Account acc= databaseContext.Accounts.Find(email);
            if(acc==null)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            if(acc.Password!=password)
            {
                return RedirectToAction("Login", "Auth");
            }

            HttpContext.Session.SetString("currentUser", email);
            return RedirectToAction("Index", "NutrientCalculator");
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
