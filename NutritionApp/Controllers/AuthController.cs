using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NutritionApp.Data;
using NutritionApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutritionApp.Controllers
{
    public class AuthController : Controller
    {
        DatabaseContext databaseContext;
        IConfiguration configuration;

        private List<Claim> GenerateClaims(Account account)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("Username", account.Username));

            return claims;
        }
        private string GenerateToken(Account account)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: GenerateClaims(account),
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login? login)
        {
            if (login == null)
            {
                ViewBag.error = "Incorrect creadentials";
                return View();
            }

            if (login.Username==null || login.Password==null)
            {
                ViewBag.error = "All fields must be filled";
                return View();
            }

            Account? acc = databaseContext.Accounts.Where(e=>e.Username==login.Username).FirstOrDefault();
            if(acc==null)
            {
                ViewBag.error = "Incorrect credentials!";
                return View();
            }
            
            if(acc.Password!=login.Password)
            {
                ViewBag.error = "Incorrect credentials";
                return View();
            }


            string token = GenerateToken(acc);

            HttpContext.Session.SetString("currentUser", login.Username);
            HttpContext.Session.SetString("FoodSetId", acc.Id.ToString());
            return RedirectToAction("Index", "NutrientCalculator");
        }
        public IActionResult Register()
        {
            string message = ViewBag.error;
            return View(message);
        }
        [HttpPost]
        public IActionResult Register(Register? register)
        {
            if(register == null)
            {
                ViewBag.error = "All fields must be filled";
                return View();
            }

            if(register.Username==null || register.Password == null || register.Password2 == null)
            {
                ViewBag.error = "All fields must be filled";
                return View();
            }

            if (register.Password != register.Password2)
            {
                ViewBag.error = "Password do not match";
                return View();
            }

            Account? acc = databaseContext.Accounts.Where(e => e.Username == register.Username).FirstOrDefault();
            if(acc!=null)
            {
                ViewBag.error = "Account with this username already exists!";
                return View();
            }

            databaseContext.Add(new Account { Username = register.Username, Password = register.Password });
            databaseContext.SaveChanges();

            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "Null");
            return RedirectToAction("Login", "Auth");
        }
    }
}
