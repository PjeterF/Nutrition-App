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
            ViewBag.error = "Incorrect credentials";
            if (email==null || password==null)
            {
                ViewBag.error = "Incorrect credentials!";
                return View();
            }

            Account acc= databaseContext.Accounts.Where(e=>e.Email==email).First();
            if(acc==null)
            {
                ViewBag.error = "Incorrect credentials!";
                return View();
            }
            
            if(acc.Password!=password)
            {
                ViewBag.error = "Incorrect credentials";
                return RedirectToAction("Login", "Auth");
            }

            HttpContext.Session.SetString("currentUser", email);
            return RedirectToAction("Index", "NutrientCalculator");
        }
        public IActionResult Register()
        {
            string message = ViewBag.error;
            return View(message);
        }
        [HttpPost]
        public IActionResult Register(string username, string email, string password, string password2)
        {
            Account acc;
            acc = databaseContext.Accounts.Where(e => e.Email == email).First();
            if (acc!=null)
            {
                ViewBag.error = "Account with this email address already exists!";
                return View();
            }

            acc = databaseContext.Accounts.Where(n => n.Username == username).FirstOrDefault();
            if(acc!=null)
            {
                ViewBag.error = "Account with this username already exists!";
                return View();
            }

            if(password!=password2)
            {
                ViewBag.error = "Password do not match";
                return View();
            }

            databaseContext.Add(new Account { Username = username, Email = email, Password = password });
            databaseContext.SaveChanges();

            return RedirectToAction("Login", "Auth");
        }
    }
}
