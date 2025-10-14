using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfilioMS.Models.Entities
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.UtcNow;

        public bool IsApproved { get; set; } = false;

        public string IpAddress { get; set; }

        // Navigation Property
        [ForeignKey("BlogPostId")]
        public virtual BlogPost BlogPost { get; set; }
    }
}
