using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models.Entities
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill name is required")]
        [StringLength(100, ErrorMessage = "Skill name cannot exceed 100 characters")]
        [Display(Name = "Skill Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Range(0, 100, ErrorMessage = "Proficiency must be between 0 and 100")]
        [Display(Name = "Proficiency Level (%)")]
        public int ProficiencyLevel { get; set; } = 0;

        [StringLength(100)]
        [Display(Name = "Icon Class (Font Awesome)")]
        public string IconClass { get; set; } // e.g., "fab fa-react", "fab fa-js"

        [StringLength(50)]
        [Display(Name = "Color Code")]
        public string ColorCode { get; set; } // e.g., "#61DAFB" for React

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; } = 0;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Is Featured")]
        public bool IsFeatured { get; set; } = false;

        [Display(Name = "Years of Experience")]
        public int? YearsOfExperience { get; set; }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        // Navigation property (optional)
        public ICollection<ProjectSkill> ProjectSkills { get; set; }
    }
}
