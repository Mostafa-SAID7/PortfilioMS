namespace PortfilioMS.Models.ViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int ProficiencyLevel { get; set; }
        public string IconClass { get; set; }
        public string ColorCode { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public int? YearsOfExperience { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
