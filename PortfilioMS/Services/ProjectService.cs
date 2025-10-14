using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWebsite.Models;
using PortfolioWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace PortfolioWebsite.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
    }
}
