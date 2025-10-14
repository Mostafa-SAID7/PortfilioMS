using Microsoft.AspNetCore.Identity;
using PortfolioWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string FullName => $"{FirstName} {LastName}";

        public string ProfileImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
