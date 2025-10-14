using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
