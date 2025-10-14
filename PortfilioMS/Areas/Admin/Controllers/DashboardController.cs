using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfilioMS.Data;
using PortfilioMS.Models.ViewModels;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardStats = new DashboardViewModel
            {
                TotalProjects = await _context.Projects.CountAsync(),
                TotalBlogPosts = await _context.BlogPosts.CountAsync(),
                TotalSkills = await _context.Skills.CountAsync(),
                UnreadMessages = await _context.ContactMessages.CountAsync(m => !m.IsRead),
                RecentMessages = await _context.ContactMessages
                    .OrderByDescending(m => m.ReadDate)
                    .Take(5)
                    .ToListAsync(),
                RecentProjects = await _context.Projects
                    .OrderByDescending(p => p.CreatedDate)
                    .Take(5)
                    .ToListAsync()
            };

            return View(dashboardStats);
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = new
            {
                ProjectsByCategory = await _context.Projects
                    .GroupBy(p => p.Category)
                    .Select(g => new { Category = g.Key, Count = g.Count() })
                    .ToListAsync(),
                SkillsByCategory = await _context.Skills
                    .Where(s => s.IsActive)
                    .GroupBy(s => s.Category)
                    .Select(g => new { Category = g.Key, Count = g.Count() })
                    .ToListAsync(),
              
            };

            return Json(stats);
        }
    }
}
