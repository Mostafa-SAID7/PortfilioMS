using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
