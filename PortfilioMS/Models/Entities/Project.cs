using PortfilioMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebsite.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Project title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Project Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [StringLength(500, ErrorMessage = "Short description cannot exceed 500 characters")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Detailed description is required")]
        [Display(Name = "Detailed Description")]
        public string DetailedDescription { get; set; }

        [StringLength(500)]
        [Display(Name = "Technologies Used (comma-separated)")]
        public string Technologies { get; set; }

        [Display(Name = "Main Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "GitHub Repository URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string GithubUrl { get; set; }

        [Display(Name = "Live Demo URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string LiveDemoUrl { get; set; }

        [StringLength(100)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; } = false;

        [Display(Name = "Is Published")]
        public bool IsPublished { get; set; } = true;

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; } = 0;

        [Display(Name = "View Count")]
        public int ViewCount { get; set; } = 0;

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        // Foreign Key
        [Display(Name = "Created By")]
        public string CreatedById { get; set; }

        // Navigation Properties
        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual ICollection<ProjectImage> ProjectImages { get; set; }

        [NotMapped]
        public List<string> TechnologyList =>
            !string.IsNullOrEmpty(Technologies)
                ? Technologies.Split(',').Select(t => t.Trim()).ToList()
                : new List<string>();
    }
}
