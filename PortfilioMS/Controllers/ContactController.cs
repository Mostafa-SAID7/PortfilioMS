using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
