using GuardianTalesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuardianTalesWeb.Controllers
{
    public class JoueurController : Controller
    {
        public IActionResult Index()
        {
            GuardianTalesContext context = HttpContext.RequestServices.GetService(typeof(GuardianTalesWeb.Models.GuardianTalesContext)) as GuardianTalesContext;
            return View(context.GetAllJoueur());
        }
    }
}
