using PortfolioWebsite.Models;

namespace PortfilioMS.Models.ViewModels.Home
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int TotalBlogPosts { get; set; }
        public int TotalSkills { get; set; }
        public int UnreadMessages { get; set; }
        public List<ContactMessage> RecentMessages { get; set; }
        public List<Project> RecentProjects { get; set; }
    }
}
