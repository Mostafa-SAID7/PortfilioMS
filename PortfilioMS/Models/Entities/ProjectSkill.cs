using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfilioMS.Models.Entities
{
    public class ProjectSkill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }

        // Navigation Properties
        public Project Project { get; set; }
        public Skill Skill { get; set; }
    }
}
