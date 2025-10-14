using PortfilioMS.Models.Entities;

namespace PortfilioMS.Models.ViewModels.Pages
{
    public class AboutViewModel
    {
        public string FullName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Bio { get; set; }
        public string CurrentPosition { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Skill> Skills { get; set; } = new List<Skill>();

        // Grouped Skills
        public Dictionary<string, List<Skill>> GroupedSkills { get; set; } = new Dictionary<string, List<Skill>>();

        // Certifications
        public List<string> Certifications { get; set; } = new List<string>();

        // Statistics
        public int YearsOfExperience { get; set; }
        public int TotalProjects { get; set; }

        // Resume
        public string ResumeUrl { get; set; }

        // Social Links
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
