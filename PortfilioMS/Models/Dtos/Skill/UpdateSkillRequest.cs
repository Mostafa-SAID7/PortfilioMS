using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models.Dtos.Skill
{
    public class UpdateSkillRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Range(0, 100)]
        public int ProficiencyLevel { get; set; }

        [StringLength(100)]
        public string IconClass { get; set; }

        [StringLength(50)]
        public string ColorCode { get; set; }

        public int DisplayOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; } = false;
        public int? YearsOfExperience { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }

}
