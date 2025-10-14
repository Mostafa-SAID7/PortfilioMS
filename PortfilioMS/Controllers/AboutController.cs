using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
