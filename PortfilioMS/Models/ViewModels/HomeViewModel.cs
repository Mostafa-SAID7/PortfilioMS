using System.Collections.Generic;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Models.ViewModels
{
    public class HomeViewModel
    {
        public string HeroTitle { get; set; }
        public string HeroSubtitle { get; set; }
        public string HeroDescription { get; set; }
        public string ProfileImageUrl { get; set; }

        public List<Project> FeaturedProjects { get; set; } = new List<Project>();
        public List<Skill> TopSkills { get; set; } = new List<Skill>();
        public List<BlogPost> RecentBlogPosts { get; set; } = new List<BlogPost>();

        // Statistics
        public int TotalProjects { get; set; }
        public int YearsOfExperience { get; set; }
        public int TotalSkills { get; set; }
        public int TotalBlogPosts { get; set; }

        // Social Links
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string EmailAddress { get; set; }

        // Call to Action
        public bool ShowDownloadResume { get; set; } = true;
        public string ResumeUrl { get; set; }
    }
}
