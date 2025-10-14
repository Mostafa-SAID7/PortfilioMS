using PortfolioWebsite.Models;

namespace PortfilioMS.Models.ViewModels.Projects
{
    public class ProjectDetailsViewModel
    {
        public Project Project { get; set; }
        public List<ProjectImage> ProjectImages { get; set; } = new List<ProjectImage>();
        public List<Project> RelatedProjects { get; set; } = new List<Project>();
        public string PreviousProjectSlug { get; set; }
        public string NextProjectSlug { get; set; }
    }
}
