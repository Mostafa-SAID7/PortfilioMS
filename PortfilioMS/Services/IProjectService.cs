using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}
