using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    public class Logout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
