using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Private() 
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            //Login Process
            //Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Mical Mical"));
            claims.Add(new Claim(ClaimTypes.Email, "Mical@mail.com"));
            claims.Add(new Claim("Police Say", "He is a good person"));

            //Claims Identity
            var identity = new ClaimsIdentity(claims, "Police Report");

            //Claims Principle
            var principle = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(principle);
            return RedirectToAction("Index");
        }
    }
}
