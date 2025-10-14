using PortfilioMS.Models.Entities;

namespace PortfilioMS.Models.ViewModels.Blog
{
    public class BlogPostViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<BlogPost> RelatedPosts { get; set; } = new List<BlogPost>();
        public List<BlogComment> Comments { get; set; } = new List<BlogComment>();

        // Comment Form
        public string CommentName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentText { get; set; }

        // Navigation
        public BlogPost PreviousPost { get; set; }
        public BlogPost NextPost { get; set; }
    }
}
