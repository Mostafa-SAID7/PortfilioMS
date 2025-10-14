# Portfolio Website Structure Creation Script
$rootPath = "C:\Users\Mostafa\OneDrive\Desktop\Projects\PortfilioMS\PortfilioMS\Files\PortfolioWebsite"

# Create main directories
$directories = @(
    "Controllers",
    "Models",
    "Models\ViewModels",
    "Views",
    "Views\Shared",
    "Views\Home",
    "Views\About",
    "Views\Projects",
    "Views\Skills",
    "Views\Contact",
    "Views\Blog",
    "Data",
    "Data\Migrations",
    "Services",
    "wwwroot\css",
    "wwwroot\js",
    "wwwroot\images",
    "wwwroot\images\profile",
    "wwwroot\images\projects",
    "wwwroot\images\icons",
    "wwwroot\lib",
    "wwwroot\lib\bootstrap",
    "wwwroot\lib\jquery",
    "wwwroot\lib\font-awesome",
    "wwwroot\documents",
    "Areas\Admin\Controllers",
    "Areas\Admin\Views",
    "Areas\Admin\Views\Dashboard",
    "Helpers",
    "Repositories"
)

# Create all directories
foreach ($dir in $directories) {
    $fullPath = Join-Path $rootPath $dir
    if (!(Test-Path $fullPath)) {
        New-Item -ItemType Directory -Path $fullPath -Force
        Write-Host "Created directory: $fullPath" -ForegroundColor Green
    }
}

# Create Controllers
$controllers = @(
    "HomeController.cs",
    "AboutController.cs",
    "ProjectsController.cs",
    "SkillsController.cs",
    "ContactController.cs",
    "BlogController.cs"
)

$controllerTemplate = @"
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PortfolioWebsite.Controllers
{
    public class {0} : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
"@

foreach ($controller in $controllers) {
    $className = $controller -replace '\.cs$', ''
    $content = $controllerTemplate -f $className
    $filePath = Join-Path (Join-Path $rootPath "Controllers") $controller
    Set-Content -Path $filePath -Value $content
    Write-Host "Created controller: $filePath" -ForegroundColor Yellow
}

# Create Models
$models = @(
    "Project.cs",
    "Skill.cs",
    "ContactMessage.cs",
    "BlogPost.cs",
    "Education.cs",
    "Experience.cs"
)

$modelTemplate = @"
using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class {0}
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
"@

foreach ($model in $models) {
    $className = $model -replace '\.cs$', ''
    $content = $modelTemplate -f $className
    $filePath = Join-Path (Join-Path $rootPath "Models") $model
    Set-Content -Path $filePath -Value $content
    Write-Host "Created model: $filePath" -ForegroundColor Yellow
}

# Create ViewModels
$viewModels = @(
    "HomeViewModel.cs",
    "ProjectViewModel.cs",
    "ContactViewModel.cs"
)

$viewModelTemplate = @"
using System.Collections.Generic;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Models.ViewModels
{
    public class {0}
    {
        public List<Project> FeaturedProjects { get; set; }
        public List<Skill> TopSkills { get; set; }
        public List<BlogPost> RecentPosts { get; set; }
    }
}
"@

foreach ($viewModel in $viewModels) {
    $className = $viewModel -replace '\.cs$', ''
    $content = $viewModelTemplate -f $className
    $filePath = Join-Path (Join-Path $rootPath "Models\ViewModels") $viewModel
    Set-Content -Path $filePath -Value $content
    Write-Host "Created view model: $filePath" -ForegroundColor Yellow
}

# Create Views
# Shared Views
$sharedViews = @{
    "_Layout.cshtml" = '<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Portfolio Website</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <partial name="_Header" />
    <partial name="_Navigation" />
    
    <main role="main">
        @RenderBody()
    </main>
    
    <partial name="_Footer" />
    
    <script src="~/js/site.js"></script>
    @RenderSection("Scripts", required: false)
</body>
</html>'
    "_Header.cshtml" = '<header><h1>My Portfolio</h1></header>'
    "_Footer.cshtml" = '<footer><p>&copy; 2024 My Portfolio. All rights reserved.</p></footer>'
    "_Navigation.cshtml" = '<nav>
    <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/About">About</a></li>
        <li><a href="/Projects">Projects</a></li>
        <li><a href="/Skills">Skills</a></li>
        <li><a href="/Blog">Blog</a></li>
        <li><a href="/Contact">Contact</a></li>
    </ul>
</nav>'
    "Error.cshtml" = '<h2>An error occurred while processing your request.</h2>'
}

foreach ($view in $sharedViews.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Views\Shared") $view.Key
    Set-Content -Path $filePath -Value $view.Value
    Write-Host "Created shared view: $filePath" -ForegroundColor Cyan
}

# Home Views
$homeViews = @{
    "Index.cshtml" = '@{
    ViewData["Title"] = "Home";
}

<h1>Welcome to My Portfolio</h1>
<p>This is the home page of my portfolio website.</p>'
    "Privacy.cshtml" = '<h2>Privacy Policy</h2><p>Your privacy is important to us.</p>'
}

foreach ($view in $homeViews.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Views\Home") $view.Key
    Set-Content -Path $filePath -Value $view.Value
    Write-Host "Created home view: $filePath" -ForegroundColor Cyan
}

# Other Views (simplified content)
$viewTemplates = @{
    "About\Index.cshtml" = "<h2>About Me</h2><p>Learn more about my background and experience.</p>"
    "Projects\Index.cshtml" = "<h2>My Projects</h2><p>Here are some of my recent projects.</p>"
    "Projects\Details.cshtml" = "<h2>Project Details</h2><p>Detailed view of a specific project.</p>"
    "Skills\Index.cshtml" = "<h2>My Skills</h2><p>Technologies and skills I work with.</p>"
    "Contact\Index.cshtml" = "<h2>Contact Me</h2><p>Get in touch with me.</p>"
    "Contact\Success.cshtml" = "<h2>Message Sent</h2><p>Thank you for your message!</p>"
    "Blog\Index.cshtml" = "<h2>Blog</h2><p>My latest thoughts and articles.</p>"
    "Blog\Post.cshtml" = "<h2>Blog Post</h2><p>Full blog post content.</p>"
}

foreach ($view in $viewTemplates.GetEnumerator()) {
    $filePath = Join-Path $rootPath "Views\$($view.Key)"
    Set-Content -Path $filePath -Value $view.Value
    Write-Host "Created view: $filePath" -ForegroundColor Cyan
}

# Create Data files
$dataFiles = @{
    "ApplicationDbContext.cs" = @"
using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
"@
}

foreach ($file in $dataFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Data") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created data file: $filePath" -ForegroundColor Magenta
}

# Create Services
$serviceFiles = @{
    "IEmailService.cs" = @"
using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
"@
    "EmailService.cs" = @"
using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            // Implement email sending logic here
            await Task.CompletedTask;
        }
    }
}
"@
    "IProjectService.cs" = @"
using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
    }
}
"@
    "ProjectService.cs" = @"
using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<List<Project>> GetProjectsAsync()
        {
            // Implement project retrieval logic
            return await Task.FromResult(new List<Project>());
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            // Implement project retrieval by ID
            return await Task.FromResult(new Project());
        }

        public async Task AddProjectAsync(Project project)
        {
            // Implement project addition logic
            await Task.CompletedTask;
        }
    }
}
"@
}

foreach ($file in $serviceFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Services") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created service: $filePath" -ForegroundColor Magenta
}

# Create wwwroot files
$cssFiles = @{
    "site.css" = "/* Main site styles */"
    "home.css" = "/* Home page specific styles */"
    "projects.css" = "/* Projects page specific styles */"
    "responsive.css" = "/* Responsive design styles */"
}

foreach ($file in $cssFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "wwwroot\css") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created CSS file: $filePath" -ForegroundColor Blue
}

$jsFiles = @{
    "site.js" = "// Main site JavaScript"
    "animations.js" = "// Animation functionality"
    "contact-form.js" = "// Contact form handling"
}

foreach ($file in $jsFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "wwwroot\js") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created JS file: $filePath" -ForegroundColor Blue
}

# Create Areas files
$adminControllers = @{
    "DashboardController.cs" = @"
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area(""Admin"")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
"@
    "ProjectManagementController.cs" = @"
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area(""Admin"")]
    public class ProjectManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
"@
}

foreach ($file in $adminControllers.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Areas\Admin\Controllers") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created admin controller: $filePath" -ForegroundColor Yellow
}

$adminViews = @{
    "Dashboard\Index.cshtml" = "<h2>Admin Dashboard</h2><p>Welcome to the admin area.</p>"
}

foreach ($view in $adminViews.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Areas\Admin\Views") $view.Key
    Set-Content -Path $filePath -Value $view.Value
    Write-Host "Created admin view: $filePath" -ForegroundColor Cyan
}

# Create Helper files
$helperFiles = @{
    "ImageHelper.cs" = @"
using System.Threading.Tasks;

namespace PortfolioWebsite.Helpers
{
    public class ImageHelper
    {
        public static async Task<string> ResizeImageAsync(string imagePath, int width, int height)
        {
            // Implement image resizing logic
            return await Task.FromResult(imagePath);
        }
    }
}
"@
    "ValidationHelper.cs" = @"
using System.Text.RegularExpressions;

namespace PortfolioWebsite.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Simple email validation
                return Regex.IsMatch(email,
                    @""^[^@\s]+@[^@\s]+\.[^@\s]+$"",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
"@
}

foreach ($file in $helperFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Helpers") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created helper: $filePath" -ForegroundColor Magenta
}

# Create Repository files
$repositoryFiles = @{
    "IRepository.cs" = @"
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
"@
    "Repository.cs" = @"
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
"@
    "UnitOfWork.cs" = @"
using PortfolioWebsite.Data;

namespace PortfolioWebsite.Repositories
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
"@
}

foreach ($file in $repositoryFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Repositories") $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created repository: $filePath" -ForegroundColor Magenta
}

# Create root files
$rootFiles = @{
    "appsettings.json" = '{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PortfolioWebsite;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Portfolio Website",
    "SenderEmail": ""
  }
}'
    "appsettings.Development.json" = '{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}'
    "Program.cs" = 'using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;
using PortfolioWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();'
    "Startup.cs" = 'using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;
using PortfolioWebsite.Services;

namespace PortfolioWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProjectService, ProjectService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}'
    "README.md" = '# Portfolio Website

A professional portfolio website built with ASP.NET Core MVC.

## Project Structure

- **Controllers**: Handle HTTP requests and responses
- **Models**: Data models and view models
- **Views**: Razor views for UI presentation
- **Services**: Business logic and external service integration
- **Data**: Entity Framework context and data access
- **wwwroot**: Static files (CSS, JS, images)
- **Areas**: Admin area for content management
- **Helpers**: Utility classes and helper methods
- **Repositories**: Data access abstraction layer

## Features

- Responsive design
- Project showcase
- Skills display
- Blog functionality
- Contact form
- Admin area for content management

## Setup

1. Update connection strings in appsettings.json
2. Run database migrations
3. Configure email settings
4. Build and run the application'
}

foreach ($file in $rootFiles.GetEnumerator()) {
    $filePath = Join-Path $rootPath $file.Key
    Set-Content -Path $filePath -Value $file.Value
    Write-Host "Created root file: $filePath" -ForegroundColor Green
}

# Create empty files for wwwroot documents and placeholder files
$emptyFiles = @(
    "wwwroot\documents\resume.pdf"
)

foreach ($file in $emptyFiles) {
    $filePath = Join-Path $rootPath $file
    if (!(Test-Path $filePath)) {
        New-Item -ItemType File -Path $filePath -Force
        Write-Host "Created placeholder: $filePath" -ForegroundColor Gray
    }
}

Write-Host "`nPortfolio Website structure created successfully!" -ForegroundColor Green
Write-Host "Location: $rootPath" -ForegroundColor Yellow