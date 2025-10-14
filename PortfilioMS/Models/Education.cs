using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        [StringLength(200, ErrorMessage = "Degree cannot exceed 200 characters")]
        [Display(Name = "Degree/Certification")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Institution is required")]
        [StringLength(200, ErrorMessage = "Institution name cannot exceed 200 characters")]
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [StringLength(100)]
        [Display(Name = "Field of Study")]
        public string FieldOfStudy { get; set; }

        [StringLength(200)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Currently Studying")]
        public bool IsCurrentlyStudying { get; set; } = false;

        [StringLength(20)]
        [Display(Name = "Grade/GPA")]
        public string Grade { get; set; }

        [StringLength(1000)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(500)]
        [Display(Name = "Achievements")]
        public string Achievements { get; set; }

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
