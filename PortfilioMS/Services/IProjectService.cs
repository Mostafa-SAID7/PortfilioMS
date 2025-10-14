using System.Collections.Generic;
using System.Threading.Tasks;
using PortfilioMS.Models.Entities;

namespace PortfolioWebsite.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}
