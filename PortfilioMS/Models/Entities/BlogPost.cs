using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfilioMS.Models.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(300, ErrorMessage = "Title cannot exceed 300 characters")]
        [Display(Name = "Post Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        [StringLength(350)]
        [Display(Name = "URL Slug")]
        [RegularExpression(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", ErrorMessage = "Slug must be lowercase with hyphens only")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Summary is required")]
        [StringLength(500, ErrorMessage = "Summary cannot exceed 500 characters")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Featured Image URL")]
        public string FeaturedImageUrl { get; set; }

        [StringLength(100)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [StringLength(500)]
        [Display(Name = "Tags (comma-separated)")]
        public string Tags { get; set; }

        [Display(Name = "Published Date")]
        [DataType(DataType.DateTime)]
        public DateTime? PublishedDate { get; set; }

        [Display(Name = "Is Published")]
        public bool IsPublished { get; set; } = false;

        [Display(Name = "View Count")]
        public int ViewCount { get; set; } = 0;

        [Display(Name = "Allow Comments")]
        public bool AllowComments { get; set; } = true;

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        // SEO Properties
        [StringLength(160)]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        [Display(Name = "Meta Keywords")]
        public string MetaKeywords { get; set; }

        // Foreign Key
        [Display(Name = "Author")]
        public string AuthorId { get; set; }

        // Navigation Properties
        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }

        [NotMapped]
        public List<string> TagList =>
            !string.IsNullOrEmpty(Tags)
                ? Tags.Split(',').Select(t => t.Trim()).ToList()
                : new List<string>();

        [NotMapped]
        public int ReadingTimeMinutes => (int)Math.Ceiling(Content?.Split(' ').Length / 200.0 ?? 0);
    }
}
