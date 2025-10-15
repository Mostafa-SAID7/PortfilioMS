using System.Collections.Generic;
using PortfilioMS.Models.Entities;
using PortfilioMS.Models.ViewModels.Blog;
using PortfilioMS.Models.ViewModels.Projects;

namespace PortfilioMS.Models.ViewModels.Home
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
        public string HeroTitle { get; set; }
        public string HeroSubtitle { get; set; }
        public string HeroDescription { get; set; }
        public string HeroImageUrl { get; set; }
        public string CallToActionText { get; set; }
        public string CallToActionLink { get; set; }

        public List<ProjectViewModel> FeaturedProjects { get; set; } = new List<ProjectViewModel>();
        public List<BlogPostViewModel> RecentBlogPosts { get; set; } = new List<BlogPostViewModel>();
        public List<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public StatsViewModel Stats { get; set; }
        public List<TestimonialViewModel> Testimonials { get; set; } = new List<TestimonialViewModel>();

        public SeoMetadataViewModel SeoMetadata { get; set; }
    }
}
