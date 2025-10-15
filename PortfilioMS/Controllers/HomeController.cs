using Microsoft.AspNetCore.Mvc;
using PortfilioMS.Models.Entities;
using PortfilioMS.Models.ViewModels.Home;
using PortfolioWebsite.Services;
using System.Diagnostics;

namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectService _projectService;
        private readonly IBlogService _blogService;
        private readonly ISkillService _skillService;

        public HomeController(
            ILogger<HomeController> logger,
            IProjectService projectService,
            IBlogService blogService,
            ISkillService skillService)
        {
            _logger = logger;
            _projectService = projectService;
            _blogService = blogService;
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featuredProjects = await _projectService.GetFeaturedProjectsAsync(3);
                var recentBlogPosts = await _blogService.GetRecentPostsAsync(3);
                var skills = await _skillService.GetAllSkillsAsync();

                var viewModel = new HomeViewModel
                {
                    HeroTitle = "Full Stack Developer",
                    HeroSubtitle = "Crafting digital experiences with clean code and modern technologies",
                    FeaturedProjects = featuredProjects,
                    RecentBlogPosts = recentBlogPosts,
                    Skills = skills,
                    Stats = new StatsViewModel
                    {
                        ProjectsCompleted = 50,
                        HappyClients = 25,
                        YearsExperience = 3,
                        GithubContributions = 1200
                    }
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading home page");
                // Return view with empty model or handle error appropriately
                return View(new HomeViewModel());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet]
        public async Task<JsonResult> GetHeroData()
        {
            var stats = new
            {
                projects = 50,
                clients = 25,
                experience = 3,
                contributions = 1200
            };

            return Json(stats);
        }

        [HttpGet]
        public async Task<JsonResult> GetFeaturedContent()
        {
            var featuredProjects = await _projectService.GetFeaturedProjectsAsync(3);
            var recentPosts = await _blogService.GetRecentPostsAsync(3);

            return Json(new { projects = featuredProjects, posts = recentPosts });
        }
    }
}
