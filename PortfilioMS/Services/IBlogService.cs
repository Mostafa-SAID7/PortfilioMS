using PortfilioMS.Models.ViewModels.Blog;
using PortfilioMS.Models.ViewModels.Shared;

namespace PortfilioMS.Services
{
    public interface IBlogService
    {
        // Basic CRUD Operations
        Task<BlogPostViewModel> GetPostByIdAsync(int id);
        Task<BlogPostViewModel> GetPostBySlugAsync(string slug);
        Task<List<BlogPostViewModel>> GetAllPostsAsync();
        Task<List<BlogPostViewModel>> GetRecentPostsAsync(int count = 3);
        Task<List<BlogPostViewModel>> GetFeaturedPostsAsync();
        Task<List<BlogPostViewModel>> GetPublishedPostsAsync();

        // Administrative Operations
        Task<OperationResult> CreatePostAsync(CreateBlogPostRequest request);
        Task<OperationResult> UpdatePostAsync(int id, UpdateBlogPostRequest request);
        Task<OperationResult> DeletePostAsync(int id);
        Task<OperationResult> TogglePostStatusAsync(int id);
        Task<OperationResult> IncrementViewCountAsync(int id);

        // Filtering and Searching
        Task<List<BlogPostViewModel>> GetPostsByCategoryAsync(string category);
        Task<List<BlogPostViewModel>> GetPostsByTagAsync(string tag);
        Task<List<BlogPostViewModel>> SearchPostsAsync(string searchTerm);
        Task<List<BlogPostViewModel>> GetPostsByAuthorAsync(string author);

        // Pagination
        Task<PagedResult<BlogPostViewModel>> GetPostsPagedAsync(int pageNumber = 1, int pageSize = 10);
        Task<PagedResult<BlogPostViewModel>> GetPublishedPostsPagedAsync(int pageNumber = 1, int pageSize = 10);

        // Utility Methods
        Task<List<string>> GetCategoriesAsync();
        Task<List<string>> GetTagsAsync();
        Task<List<BlogPostViewModel>> GetRelatedPostsAsync(int postId, int count = 3);
        Task<bool> PostExistsAsync(int id);
        Task<bool> SlugExistsAsync(string slug);
        Task<int> GetTotalPostsCountAsync();
        Task<int> GetPublishedPostsCountAsync();

        // Archive and Statistics
        Task<Dictionary<string, int>> GetArchiveStatsAsync();
        Task<List<BlogPostViewModel>> GetPostsByYearMonthAsync(int year, int month);
    }

    public class CreateBlogPostRequest
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public int ReadTime { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class UpdateBlogPostRequest
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public int ReadTime { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
    }
}
