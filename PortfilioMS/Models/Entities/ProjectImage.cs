using PortfolioWebsite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfilioMS.Models
{
    public class ProjectImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Caption { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public bool IsPrimary { get; set; } = false;

        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        // Navigation Property
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
