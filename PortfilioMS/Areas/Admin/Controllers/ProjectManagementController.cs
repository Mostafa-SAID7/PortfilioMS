using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfilioMS.Data;
using PortfilioMS.Models.Entities;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
     [Area("Admin")]
    [Authorize]
    public class ProjectManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProjectManagementController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "projects");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    project.ImageUrl = "/images/projects/" + uniqueFileName;
                }

                project.CreatedDate = DateTime.UtcNow;
                project.UpdatedDate = DateTime.UtcNow;

                _context.Add(project);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Project created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project, IFormFile imageFile)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProject = await _context.Projects.FindAsync(id);

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        // Delete old image if exists
                        if (!string.IsNullOrEmpty(existingProject.ImageUrl))
                        {
                            var oldImagePath = Path.Combine(_environment.WebRootPath, existingProject.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Upload new image
                        var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "projects");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }

                        existingProject.ImageUrl = "/images/projects/" + uniqueFileName;
                    }

                    // Update other properties
                    existingProject.Title = project.Title;
                    existingProject.ShortDescription = project.ShortDescription;
                    existingProject.DetailedDescription = project.DetailedDescription;
                    existingProject.Technologies = project.Technologies;
                    existingProject.GithubUrl = project.GithubUrl;
                    existingProject.Category = project.Category;
                    existingProject.IsPublished = project.IsPublished;
                    existingProject.IsFeatured = project.IsFeatured;
                    existingProject.DisplayOrder = project.DisplayOrder;
                    existingProject.UpdatedDate = DateTime.UtcNow;

                    _context.Update(existingProject);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Project updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                // Delete associated image
                if (!string.IsNullOrEmpty(project.ImageUrl))
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, project.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Project deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleFeatured(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                project.IsFeatured = !project.IsFeatured;
                project.UpdatedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return Json(new { success = true, isFeatured = project.IsFeatured });
            }

            return Json(new { success = false });
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
