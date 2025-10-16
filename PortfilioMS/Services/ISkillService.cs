using PortfilioMS.Models.ViewModels;
using PortfilioMS.Models.ViewModels.Shared;

namespace PortfilioMS.Services
{
    public interface ISkillService
    {
        // Basic CRUD Operations
        Task<SkillViewModel> GetSkillByIdAsync(int id);
        Task<List<SkillViewModel>> GetAllSkillsAsync();
        Task<List<SkillViewModel>> GetTopSkillsAsync(int count = 8);
        Task<List<SkillViewModel>> GetSkillsByCategoryAsync(string category);
        Task<List<SkillViewModel>> GetFeaturedSkillsAsync();

        // Administrative Operations
        Task<OperationResult> CreateSkillAsync(CreateSkillRequest request);
        Task<OperationResult> UpdateSkillAsync(int id, UpdateSkillRequest request);
        Task<OperationResult> DeleteSkillAsync(int id);
        Task<OperationResult> ToggleSkillStatusAsync(int id);

        // Utility Methods
        Task<List<string>> GetSkillCategoriesAsync();
        Task<List<SkillViewModel>> SearchSkillsAsync(string searchTerm);
        Task<bool> SkillExistsAsync(int id);
        Task<int> GetSkillsCountAsync();

        // Specialized Queries
        Task<List<SkillViewModel>> GetSkillsWithProjectsAsync();
        Task<Dictionary<string, List<SkillViewModel>>> GetSkillsGroupedByCategoryAsync();
        Task<List<SkillViewModel>> GetSkillsByProficiencyAsync(int minProficiency = 70);
    }

    public class CreateSkillRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Proficiency { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class UpdateSkillRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Proficiency { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
    }

}
