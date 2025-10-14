using System;
using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models.Entities
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(200, ErrorMessage = "Job title cannot exceed 200 characters")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(200, ErrorMessage = "Company name cannot exceed 200 characters")]
        [Display(Name = "Company Name")]
        public string Company { get; set; }

        [StringLength(200)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [StringLength(50)]
        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; } // Full-time, Part-time, Contract, Freelance, etc.

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Currently Working")]
        public bool IsCurrentJob { get; set; } = false;

        [StringLength(1000)]
        [Display(Name = "Job Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Responsibilities (JSON array or newline separated)")]
        public string Responsibilities { get; set; }

        [StringLength(500)]
        [Display(Name = "Technologies Used")]
        public string TechnologiesUsed { get; set; }

        [StringLength(500)]
        [Display(Name = "Key Achievements")]
        public string Achievements { get; set; }

        [StringLength(500)]
        [Display(Name = "Company Website")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string CompanyWebsite { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; } = 0;

        [Display(Name = "Is Visible")]
        public bool IsVisible { get; set; } = true;

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
