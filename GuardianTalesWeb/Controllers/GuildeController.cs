using GuardianTalesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuardianTalesWeb.Controllers
{
    public class GuildeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Guilde(int id)
        {
            GuardianTalesContext context = HttpContext.RequestServices.GetService(typeof(GuardianTalesWeb.Models.GuardianTalesContext)) as GuardianTalesContext;
            return View(context.GetJoueurFromGuild(id));
        }
    }
}
