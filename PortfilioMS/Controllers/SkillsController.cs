using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
