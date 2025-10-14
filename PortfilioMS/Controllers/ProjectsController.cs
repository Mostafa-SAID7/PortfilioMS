using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
