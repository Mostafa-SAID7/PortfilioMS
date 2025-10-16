using Microsoft.EntityFrameworkCore;
using PortfilioMS.Data;
using PortfilioMS.Models.Entities;
using PortfilioMS.Models.ViewModels;
using PortfilioMS.Models.ViewModels.Shared;

namespace PortfilioMS.Services
{
public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SkillService> _logger;

        public SkillService(ApplicationDbContext context, ILogger<SkillService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SkillViewModel> GetSkillByIdAsync(int id)
        {
            try
            {
                var skill = await _context.Skills
                    .Where(s => s.Id == id && s.IsActive)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .FirstOrDefaultAsync();

                return skill;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skill by ID: {SkillId}", id);
                throw;
            }
        }

        public async Task<List<SkillViewModel>> GetAllSkillsAsync()
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive)
                    .OrderBy(s => s.DisplayOrder)
                    .ThenBy(s => s.Name)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all skills");
                throw;
            }
        }

        public async Task<List<SkillViewModel>> GetTopSkillsAsync(int count = 8)
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive && s.IsFeatured)
                    .OrderByDescending(s => s.ProficiencyLevel)
                    .ThenBy(s => s.DisplayOrder)
                    .Take(count)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting top skills");
                throw;
            }
        }

        public async Task<List<SkillViewModel>> GetSkillsByCategoryAsync(string category)
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive && s.Category == category)
                    .OrderBy(s => s.DisplayOrder)
                    .ThenBy(s => s.Name)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skills by category: {Category}", category);
                throw;
            }
        }

        public async Task<List<SkillViewModel>> GetFeaturedSkillsAsync()
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive && s.IsFeatured)
                    .OrderBy(s => s.DisplayOrder)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting featured skills");
                throw;
            }
        }

        public async Task<OperationResult> CreateSkillAsync(CreateSkillRequest request)
        {
            try
            {
                var skill = new Skill
                {
                    Name = request.Name,
                    Category = request.Category,
                    ProficiencyLevel = request.Proficiency,
                    IconClass = request.IconUrl,
                    DisplayOrder = request.DisplayOrder,
                    Description = request.Description,
                    YearsOfExperience = request.YearsOfExperience,
                    IsFeatured = request.IsFeatured,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();

                return OperationResult.SuccessResult("Skill created successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating skill");
                return OperationResult.Failure("Failed to create skill");
            }
        }

        public async Task<OperationResult> UpdateSkillAsync(int id, UpdateSkillRequest request)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(id);
                if (skill == null)
                    return OperationResult.Failure("Skill not found");

                skill.Name = request.Name;
                skill.Category = request.Category;
                skill.ProficiencyLevel = request.Proficiency;
                skill.IconClass = request.IconUrl;
                skill.DisplayOrder = request.DisplayOrder;
                skill.Description = request.Description;
                skill.YearsOfExperience = request.YearsOfExperience;
                skill.IsFeatured = request.IsFeatured;
                skill.IsActive = request.IsActive;
                skill.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return OperationResult.SuccessResult("Skill updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating skill: {SkillId}", id);
                return OperationResult.Failure("Failed to update skill");
            }
        }

        public async Task<OperationResult> DeleteSkillAsync(int id)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(id);
                if (skill == null)
                    return OperationResult.Failure("Skill not found");

                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();

                return OperationResult.SuccessResult("Skill deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting skill: {SkillId}", id);
                return OperationResult.Failure("Failed to delete skill");
            }
        }

        public async Task<OperationResult> ToggleSkillStatusAsync(int id)
        {
            try
            {
                var skill = await _context.Skills.FindAsync(id);
                if (skill == null)
                    return OperationResult.Failure("Skill not found");

                skill.IsActive = !skill.IsActive;
                skill.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                var status = skill.IsActive ? "activated" : "deactivated";
                return OperationResult.SuccessResult($"Skill {status} successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling skill status: {SkillId}", id);
                return OperationResult.Failure("Failed to toggle skill status");
            }
        }

        public async Task<List<string>> GetSkillCategoriesAsync()
        {
            try
            {
                var categories = await _context.Skills
                    .Where(s => s.IsActive)
                    .Select(s => s.Category)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skill categories");
                throw;
            }
        }

        public async Task<List<SkillViewModel>> SearchSkillsAsync(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return await GetAllSkillsAsync();

                var skills = await _context.Skills
                    .Where(s => s.IsActive && 
                               (s.Name.Contains(searchTerm) || 
                                s.Category.Contains(searchTerm) ||
                                s.Description.Contains(searchTerm)))
                    .OrderBy(s => s.DisplayOrder)
                    .ThenBy(s => s.Name)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching skills: {SearchTerm}", searchTerm);
                throw;
            }
        }

        public async Task<bool> SkillExistsAsync(int id)
        {
            return await _context.Skills.AnyAsync(s => s.Id == id && s.IsActive);
        }

        public async Task<int> GetSkillsCountAsync()
        {
            return await _context.Skills.CountAsync(s => s.IsActive);
        }

        public async Task<List<SkillViewModel>> GetSkillsWithProjectsAsync()
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive)
                    .Include(s => s.ProjectSkills)
                    .ThenInclude(ps => ps.Project)
                    .Where(s => s.ProjectSkills.Any(ps => ps.Project.IsActive))
                    .OrderBy(s => s.DisplayOrder)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skills with projects");
                throw;
            }
        }

        public async Task<Dictionary<string, List<SkillViewModel>>> GetSkillsGroupedByCategoryAsync()
        {
            try
            {
                var skills = await GetAllSkillsAsync();
                return skills.GroupBy(s => s.Category)
                           .ToDictionary(g => g.Key, g => g.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skills grouped by category");
                throw;
            }
        }

        public async Task<List<SkillViewModel>> GetSkillsByProficiencyAsync(int minProficiency = 70)
        {
            try
            {
                var skills = await _context.Skills
                    .Where(s => s.IsActive && s.ProficiencyLevel >= minProficiency)
                    .OrderByDescending(s => s.ProficiencyLevel)
                    .ThenBy(s => s.Name)
                    .Select(s => new SkillViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Category = s.Category,
                        ProficiencyLevel = s.ProficiencyLevel,
                        IconClass = s.IconClass,
                        DisplayOrder = s.DisplayOrder,
                        Description = s.Description,
                        YearsOfExperience = s.YearsOfExperience,
                        IsFeatured = s.IsFeatured
                    })
                    .ToListAsync();

                return skills;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting skills by proficiency");
                throw;
            }
        }
    }
}
