using System.Collections.Generic;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Models.ViewModels
{
    public class ProjectViewModel
    {
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Project> FeaturedProjects { get; set; } = new List<Project>();

        // Filtering
        public string SelectedCategory { get; set; }
        public List<string> Categories { get; set; } = new List<string>();

        public string SearchQuery { get; set; }
        public string SortBy { get; set; } = "Date"; // Date, Name, Featured

        // Pagination
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 9;
        public int TotalProjects { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalProjects / PageSize);

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
