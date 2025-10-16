using PortfilioMS.Data;
using PortfilioMS.Models.ViewModels.Blog;

namespace PortfilioMS.Services
{
     public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BlogService> _logger;

        public BlogService(ApplicationDbContext context, ILogger<BlogService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BlogPostViewModel> GetPostByIdAsync(int id)
        {
            try
            {
                var post = await _context.BlogPosts
                    .Where(p => p.Id == id)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .FirstOrDefaultAsync();

                return post;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting blog post by ID: {PostId}", id);
                throw;
            }
        }

        public async Task<BlogPostViewModel> GetPostBySlugAsync(string slug)
        {
            try
            {
                var post = await _context.BlogPosts
                    .Where(p => p.Slug == slug && p.IsPublished)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .FirstOrDefaultAsync();

                if (post != null)
                {
                    await IncrementViewCountAsync(post.Id);
                }

                return post;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting blog post by slug: {Slug}", slug);
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _context.BlogPosts
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all blog posts");
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetRecentPostsAsync(int count = 3)
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished)
                    .OrderByDescending(p => p.PublishedDate)
                    .Take(count)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recent blog posts");
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetFeaturedPostsAsync()
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && p.IsFeatured)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting featured blog posts");
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetPublishedPostsAsync()
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting published blog posts");
                throw;
            }
        }

        public async Task<OperationResult> CreatePostAsync(CreateBlogPostRequest request)
        {
            try
            {
                var slug = GenerateSlug(request.Title);
                
                // Check if slug already exists
                if (await SlugExistsAsync(slug))
                {
                    slug = $"{slug}-{DateTime.UtcNow:yyyyMMddHHmmss}";
                }

                var post = new BlogPost
                {
                    Title = request.Title,
                    Slug = slug,
                    Excerpt = request.Excerpt,
                    Content = request.Content,
                    ThumbnailUrl = request.ThumbnailUrl,
                    Author = request.Author,
                    PublishedDate = request.IsPublished ? DateTime.UtcNow : (DateTime?)null,
                    UpdatedDate = DateTime.UtcNow,
                    IsPublished = request.IsPublished,
                    Category = request.Category,
                    Tags = string.Join(',', request.Tags),
                    ReadTime = request.ReadTime,
                    ViewCount = 0,
                    IsFeatured = request.IsFeatured
                };

                _context.BlogPosts.Add(post);
                await _context.SaveChangesAsync();

                return OperationResult.Success("Blog post created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating blog post");
                return OperationResult.Failure("Failed to create blog post");
            }
        }

        public async Task<OperationResult> UpdatePostAsync(int id, UpdateBlogPostRequest request)
        {
            try
            {
                var post = await _context.BlogPosts.FindAsync(id);
                if (post == null)
                    return OperationResult.Failure("Blog post not found");

                // If title changed, update slug
                if (post.Title != request.Title)
                {
                    var newSlug = GenerateSlug(request.Title);
                    if (await SlugExistsAsync(newSlug) && newSlug != post.Slug)
                    {
                        newSlug = $"{newSlug}-{DateTime.UtcNow:yyyyMMddHHmmss}";
                    }
                    post.Slug = newSlug;
                }

                post.Title = request.Title;
                post.Excerpt = request.Excerpt;
                post.Content = request.Content;
                post.ThumbnailUrl = request.ThumbnailUrl;
                post.Author = request.Author;
                post.Category = request.Category;
                post.Tags = string.Join(',', request.Tags);
                post.ReadTime = request.ReadTime;
                post.IsPublished = request.IsPublished;
                post.IsFeatured = request.IsFeatured;
                post.UpdatedDate = DateTime.UtcNow;

                // If publishing for the first time, set published date
                if (request.IsPublished && !post.PublishedDate.HasValue)
                {
                    post.PublishedDate = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return OperationResult.Success("Blog post updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating blog post: {PostId}", id);
                return OperationResult.Failure("Failed to update blog post");
            }
        }

        public async Task<OperationResult> DeletePostAsync(int id)
        {
            try
            {
                var post = await _context.BlogPosts.FindAsync(id);
                if (post == null)
                    return OperationResult.Failure("Blog post not found");

                _context.BlogPosts.Remove(post);
                await _context.SaveChangesAsync();

                return OperationResult.Success("Blog post deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting blog post: {PostId}", id);
                return OperationResult.Failure("Failed to delete blog post");
            }
        }

        public async Task<OperationResult> TogglePostStatusAsync(int id)
        {
            try
            {
                var post = await _context.BlogPosts.FindAsync(id);
                if (post == null)
                    return OperationResult.Failure("Blog post not found");

                post.IsPublished = !post.IsPublished;
                post.UpdatedDate = DateTime.UtcNow;

                if (post.IsPublished && !post.PublishedDate.HasValue)
                {
                    post.PublishedDate = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                var status = post.IsPublished ? "published" : "unpublished";
                return OperationResult.Success($"Blog post {status} successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling blog post status: {PostId}", id);
                return OperationResult.Failure("Failed to toggle blog post status");
            }
        }

        public async Task<OperationResult> IncrementViewCountAsync(int id)
        {
            try
            {
                var post = await _context.BlogPosts.FindAsync(id);
                if (post == null)
                    return OperationResult.Failure("Blog post not found");

                post.ViewCount++;
                await _context.SaveChangesAsync();

                return OperationResult.Success("View count incremented");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error incrementing view count: {PostId}", id);
                return OperationResult.Failure("Failed to increment view count");
            }
        }

        public async Task<List<BlogPostViewModel>> GetPostsByCategoryAsync(string category)
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && p.Category == category)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts by category: {Category}", category);
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetPostsByTagAsync(string tag)
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && p.Tags.Contains(tag))
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts by tag: {Tag}", tag);
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> SearchPostsAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return await GetPublishedPostsAsync();

                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && 
                               (p.Title.Contains(searchTerm) || 
                                p.Excerpt.Contains(searchTerm) ||
                                p.Content.Contains(searchTerm) ||
                                p.Tags.Contains(searchTerm)))
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching posts: {SearchTerm}", searchTerm);
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetPostsByAuthorAsync(string author)
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && p.Author == author)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts by author: {Author}", author);
                throw;
            }
        }

        public async Task<PagedResult<BlogPostViewModel>> GetPostsPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.BlogPosts
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    });

                return await PagedResult<BlogPostViewModel>.CreateAsync(query, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paged blog posts");
                throw;
            }
        }

        public async Task<PagedResult<BlogPostViewModel>> GetPublishedPostsPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.BlogPosts
                    .Where(p => p.IsPublished)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    });

                return await PagedResult<BlogPostViewModel>.CreateAsync(query, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paged published blog posts");
                throw;
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _context.BlogPosts
                    .Where(p => p.IsPublished)
                    .Select(p => p.Category)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting blog categories");
                throw;
            }
        }

        public async Task<List<string>> GetTagsAsync()
        {
            try
            {
                var allTags = await _context.BlogPosts
                    .Where(p => p.IsPublished)
                    .Select(p => p.Tags)
                    .ToListAsync();

                var tags = allTags
                    .SelectMany(t => t.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(t => t.Trim())
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList();

                return tags;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting blog tags");
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetRelatedPostsAsync(int postId, int count = 3)
        {
            try
            {
                var currentPost = await GetPostByIdAsync(postId);
                if (currentPost == null)
                    return new List<BlogPostViewModel>();

                var relatedPosts = await _context.BlogPosts
                    .Where(p => p.IsPublished && 
                               p.Id != postId && 
                               (p.Category == currentPost.Category || 
                                p.Tags.Split(',').Any(t => currentPost.Tags.Contains(t))))
                    .OrderByDescending(p => p.PublishedDate)
                    .Take(count)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return relatedPosts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting related posts for: {PostId}", postId);
                throw;
            }
        }

        public async Task<bool> PostExistsAsync(int id)
        {
            return await _context.BlogPosts.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> SlugExistsAsync(string slug)
        {
            return await _context.BlogPosts.AnyAsync(p => p.Slug == slug);
        }

        public async Task<int> GetTotalPostsCountAsync()
        {
            return await _context.BlogPosts.CountAsync();
        }

        public async Task<int> GetPublishedPostsCountAsync()
        {
            return await _context.BlogPosts.CountAsync(p => p.IsPublished);
        }

        public async Task<Dictionary<string, int>> GetArchiveStatsAsync()
        {
            try
            {
                var stats = await _context.BlogPosts
                    .Where(p => p.IsPublished && p.PublishedDate.HasValue)
                    .GroupBy(p => new { p.PublishedDate.Value.Year, p.PublishedDate.Value.Month })
                    .Select(g => new 
                    { 
                        Year = g.Key.Year, 
                        Month = g.Key.Month, 
                        Count = g.Count() 
                    })
                    .OrderByDescending(x => x.Year)
                    .ThenByDescending(x => x.Month)
                    .ToDictionaryAsync(
                        x => $"{x.Year}-{x.Month:D2}", 
                        x => x.Count
                    );

                return stats;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting archive stats");
                throw;
            }
        }

        public async Task<List<BlogPostViewModel>> GetPostsByYearMonthAsync(int year, int month)
        {
            try
            {
                var posts = await _context.BlogPosts
                    .Where(p => p.IsPublished && 
                               p.PublishedDate.HasValue &&
                               p.PublishedDate.Value.Year == year && 
                               p.PublishedDate.Value.Month == month)
                    .OrderByDescending(p => p.PublishedDate)
                    .Select(p => new BlogPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Slug = p.Slug,
                        Excerpt = p.Excerpt,
                        Content = p.Content,
                        ThumbnailUrl = p.ThumbnailUrl,
                        Author = p.Author,
                        PublishedDate = p.PublishedDate,
                        UpdatedDate = p.UpdatedDate,
                        IsPublished = p.IsPublished,
                        Category = p.Category,
                        Tags = p.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                        ReadTime = p.ReadTime,
                        ViewCount = p.ViewCount,
                        IsFeatured = p.IsFeatured
                    })
                    .ToListAsync();

                return posts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts by year/month: {Year}-{Month}", year, month);
                throw;
            }
        }

        // Helper method to generate slug from title
        private string GenerateSlug(string title)
        {
            return title.ToLower()
                       .Replace(" ", "-")
                       .Replace(".", "-")
                       .Replace(",", "-")
                       .Replace("!", "")
                       .Replace("?", "")
                       .Replace(":", "")
                       .Replace(";", "")
                       .Replace("(", "")
                       .Replace(")", "")
                       .Replace("[", "")
                       .Replace("]", "")
                       .Replace("{", "")
                       .Replace("}", "")
                       .Replace("\"", "")
                       .Replace("'", "")
                       .Replace("&", "and")
                       .Replace("@", "at")
                       .Replace("#", "sharp")
                       .Replace("%", "percent")
                       .Replace("+", "plus")
                       .Replace("=", "equals")
                       .Replace("~", "tilde")
                       .Replace("`", "")
                       .Replace("\\", "")
                       .Replace("/", "")
                       .Replace("|", "")
                       .Replace("<", "")
                       .Replace(">", "")
                       .Replace("--", "-")
                       .Replace("--", "-")
                       .Trim('-');
        }
    }
}
