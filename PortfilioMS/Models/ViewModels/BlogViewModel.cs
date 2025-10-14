using PortfolioWebsite.Models;

namespace PortfilioMS.Models.ViewModels
{
    public class BlogViewModel
    {
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public BlogPost FeaturedPost { get; set; }
        public List<BlogPost> RecentPosts { get; set; } = new List<BlogPost>();

        // Filtering
        public string SelectedCategory { get; set; }
        public List<string> Categories { get; set; } = new List<string>();

        public string SelectedTag { get; set; }
        public List<string> PopularTags { get; set; } = new List<string>();

        public string SearchQuery { get; set; }

        // Pagination
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPosts { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalPosts / PageSize);

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
