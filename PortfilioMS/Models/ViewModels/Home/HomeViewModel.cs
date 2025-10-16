using System.Collections.Generic;
using PortfilioMS.Models.Entities;
using PortfilioMS.Models.ViewModels.Blog;
using PortfilioMS.Models.ViewModels.Projects;
using PortfilioMS.Models.ViewModels.Shared;

namespace PortfilioMS.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        // Hero Section
        public string HeroTitle { get; set; }
        public string HeroSubtitle { get; set; }
        public string HeroDescription { get; set; }
        public string ProfileImageUrl { get; set; }
        public string HeroImageUrl { get; set; }

        // Call to Action
        public string CallToActionText { get; set; }
        public string CallToActionLink { get; set; }
        public bool ShowDownloadResume { get; set; } = true;
        public string ResumeUrl { get; set; }

        // Featured Content
        public List<ProjectViewModel> FeaturedProjects { get; set; } = new List<ProjectViewModel>();
        public List<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public List<BlogPostViewModel> RecentBlogPosts { get; set; } = new List<BlogPostViewModel>();

        // Statistics
        public StatsViewModel Stats { get; set; }
        public int TotalProjects { get; set; }
        public int YearsOfExperience { get; set; }
        public int TotalSkills { get; set; }
        public int TotalBlogPosts { get; set; }

        // Social Links
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string EmailAddress { get; set; }

        // Additional Sections
        public List<TestimonialViewModel> Testimonials { get; set; } = new List<TestimonialViewModel>();
        public SeoMetadataViewModel SeoMetadata { get; set; }
    }

}