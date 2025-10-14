# Portfolio Website Structure Creation Script
# Run this script from PowerShell in your desired location

$projectName = "PortfolioWebsite"
$rootPath = Join-Path (Get-Location) $projectName

Write-Host "Creating Portfolio Website structure at: $rootPath" -ForegroundColor Green
Write-Host "================================================" -ForegroundColor Green

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

Write-Host "`nCreating directories..." -ForegroundColor Cyan
foreach ($dir in $directories) {
    $fullPath = Join-Path $rootPath $dir
    if (!(Test-Path $fullPath)) {
        New-Item -ItemType Directory -Path $fullPath -Force | Out-Null
        Write-Host "  [+] $dir" -ForegroundColor Gray
    }
}

# Create Controllers
Write-Host "`nCreating Controllers..." -ForegroundColor Cyan
$controllers = @(
    "HomeController.cs",
    "AboutController.cs",
    "ProjectsController.cs",
    "SkillsController.cs",
    "ContactController.cs",
    "BlogController.cs"
)

foreach ($controller in $controllers) {
    $className = $controller -replace '\.cs$', ''
    $content = @"
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class $className : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
"@
    $filePath = Join-Path (Join-Path $rootPath "Controllers") $controller
    Set-Content -Path $filePath -Value $content -Encoding UTF8
    Write-Host "  [+] $controller" -ForegroundColor Gray
}

# Create Models
Write-Host "`nCreating Models..." -ForegroundColor Cyan
$models = @(
    "Project.cs",
    "Skill.cs",
    "ContactMessage.cs",
    "BlogPost.cs",
    "Education.cs",
    "Experience.cs"
)

foreach ($model in $models) {
    $className = $model -replace '\.cs$', ''
    $content = @"
using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class $className
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
"@
    $filePath = Join-Path (Join-Path $rootPath "Models") $model
    Set-Content -Path $filePath -Value $content -Encoding UTF8
    Write-Host "  [+] $model" -ForegroundColor Gray
}

# Create ViewModels
Write-Host "`nCreating ViewModels..." -ForegroundColor Cyan
$viewModels = @(
    "HomeViewModel.cs",
    "ProjectViewModel.cs",
    "ContactViewModel.cs"
)

foreach ($viewModel in $viewModels) {
    $className = $viewModel -replace '\.cs$', ''
    $content = @"
using System.Collections.Generic;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Models.ViewModels
{
    public class $className
    {
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
"@
    $filePath = Join-Path (Join-Path $rootPath "Models\ViewModels") $viewModel
    Set-Content -Path $filePath -Value $content -Encoding UTF8
    Write-Host "  [+] $viewModel" -ForegroundColor Gray
}

# Create Shared Views
Write-Host "`nCreating Shared Views..." -ForegroundColor Cyan

# _Layout.cshtml
$layoutContent = @'
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Portfolio Website</title>
    <link rel="stylesheet" href="~/css/site.css" />
    <link rel="stylesheet" href="~/css/responsive.css" />
</head>
<body>
    <partial name="_Header" />
    <partial name="_Navigation" />
    
    <main role="main">
        @RenderBody()
    </main>
    
    <partial name="_Footer" />
    
    <script src="~/js/site.js"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
'@
Set-Content -Path (Join-Path $rootPath "Views\Shared\_Layout.cshtml") -Value $layoutContent -Encoding UTF8
Write-Host "  [+] _Layout.cshtml" -ForegroundColor Gray

# _Header.cshtml
$headerContent = @'
<header>
    <div class="container">
        <h1>My Portfolio</h1>
    </div>
</header>
'@
Set-Content -Path (Join-Path $rootPath "Views\Shared\_Header.cshtml") -Value $headerContent -Encoding UTF8
Write-Host "  [+] _Header.cshtml" -ForegroundColor Gray

# _Navigation.cshtml
$navContent = @'
<nav>
    <ul>
        <li><a asp-controller="Home" asp-action="Index">Home</a></li>
        <li><a asp-controller="About" asp-action="Index">About</a></li>
        <li><a asp-controller="Projects" asp-action="Index">Projects</a></li>
        <li><a asp-controller="Skills" asp-action="Index">Skills</a></li>
        <li><a asp-controller="Blog" asp-action="Index">Blog</a></li>
        <li><a asp-controller="Contact" asp-action="Index">Contact</a></li>
    </ul>
</nav>
'@
Set-Content -Path (Join-Path $rootPath "Views\Shared\_Navigation.cshtml") -Value $navContent -Encoding UTF8
Write-Host "  [+] _Navigation.cshtml" -ForegroundColor Gray

# _Footer.cshtml
$footerContent = @'
<footer>
    <div class="container">
        <p>&copy; 2024 My Portfolio. All rights reserved.</p>
    </div>
</footer>
'@
Set-Content -Path (Join-Path $rootPath "Views\Shared\_Footer.cshtml") -Value $footerContent -Encoding UTF8
Write-Host "  [+] _Footer.cshtml" -ForegroundColor Gray

# Error.cshtml
$errorContent = @'
@{
    ViewData["Title"] = "Error";
}

<h2>An error occurred</h2>
<p>Please try again later.</p>
'@
Set-Content -Path (Join-Path $rootPath "Views\Shared\Error.cshtml") -Value $errorContent -Encoding UTF8
Write-Host "  [+] Error.cshtml" -ForegroundColor Gray

# Create View Pages
Write-Host "`nCreating View Pages..." -ForegroundColor Cyan

$viewPages = @{
    "Home\Index.cshtml" = @'
@{
    ViewData["Title"] = "Home";
}

<section class="hero">
    <h1>Welcome to My Portfolio</h1>
    <p>Discover my projects and skills</p>
</section>
'@
    "Home\Privacy.cshtml" = @'
@{
    ViewData["Title"] = "Privacy Policy";
}

<h2>Privacy Policy</h2>
<p>Your privacy is important to us.</p>
'@
    "About\Index.cshtml" = @'
@{
    ViewData["Title"] = "About Me";
}

<h2>About Me</h2>
<p>Learn more about my background and experience.</p>
'@
    "Projects\Index.cshtml" = @'
@{
    ViewData["Title"] = "Projects";
}

<h2>My Projects</h2>
<div class="projects-grid">
    <p>Project listings will appear here.</p>
</div>
'@
    "Projects\Details.cshtml" = @'
@{
    ViewData["Title"] = "Project Details";
}

<h2>Project Details</h2>
<p>Detailed information about the selected project.</p>
'@
    "Skills\Index.cshtml" = @'
@{
    ViewData["Title"] = "Skills";
}

<h2>My Skills</h2>
<p>Technologies and tools I work with.</p>
'@
    "Contact\Index.cshtml" = @'
@{
    ViewData["Title"] = "Contact";
}

<h2>Contact Me</h2>
<form method="post">
    <input type="text" name="Name" placeholder="Your Name" required />
    <input type="email" name="Email" placeholder="Your Email" required />
    <textarea name="Message" placeholder="Your Message" required></textarea>
    <button type="submit">Send</button>
</form>
'@
    "Contact\Success.cshtml" = @'
@{
    ViewData["Title"] = "Message Sent";
}

<h2>Thank You!</h2>
<p>Your message has been sent successfully.</p>
'@
    "Blog\Index.cshtml" = @'
@{
    ViewData["Title"] = "Blog";
}

<h2>Blog Posts</h2>
<p>My latest articles and thoughts.</p>
'@
    "Blog\Post.cshtml" = @'
@{
    ViewData["Title"] = "Blog Post";
}

<article>
    <h2>Blog Post Title</h2>
    <p>Full blog post content goes here.</p>
</article>
'@
}

foreach ($view in $viewPages.GetEnumerator()) {
    $filePath = Join-Path $rootPath "Views\$($view.Key)"
    Set-Content -Path $filePath -Value $view.Value -Encoding UTF8
    Write-Host "  [+] $($view.Key)" -ForegroundColor Gray
}

# Create _ViewImports and _ViewStart
$viewImports = @'
@using PortfolioWebsite
@using PortfolioWebsite.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
'@
Set-Content -Path (Join-Path $rootPath "Views\_ViewImports.cshtml") -Value $viewImports -Encoding UTF8
Write-Host "  [+] _ViewImports.cshtml" -ForegroundColor Gray

$viewStart = @'
@{
    Layout = "_Layout";
}
'@
Set-Content -Path (Join-Path $rootPath "Views\_ViewStart.cshtml") -Value $viewStart -Encoding UTF8
Write-Host "  [+] _ViewStart.cshtml" -ForegroundColor Gray

# Create Data files
Write-Host "`nCreating Data files..." -ForegroundColor Cyan
$dbContextContent = @"
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
Set-Content -Path (Join-Path $rootPath "Data\ApplicationDbContext.cs") -Value $dbContextContent -Encoding UTF8
Write-Host "  [+] ApplicationDbContext.cs" -ForegroundColor Gray

# Create Services
Write-Host "`nCreating Services..." -ForegroundColor Cyan

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
            // Implement email sending logic
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
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}
"@
    "ProjectService.cs" = @"
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
"@
}

foreach ($file in $serviceFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Services") $file.Key
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] $($file.Key)" -ForegroundColor Gray
}

# Create wwwroot files
Write-Host "`nCreating wwwroot files..." -ForegroundColor Cyan

$cssFiles = @{
    "site.css" = "/* Main site styles */`nbody { font-family: Arial, sans-serif; margin: 0; padding: 0; }"
    "home.css" = "/* Home page styles */`n.hero { text-align: center; padding: 50px; }"
    "projects.css" = "/* Projects page styles */`n.projects-grid { display: grid; gap: 20px; }"
    "responsive.css" = "/* Responsive styles */`n@media (max-width: 768px) { body { font-size: 14px; } }"
}

foreach ($file in $cssFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "wwwroot\css") $file.Key
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] css\$($file.Key)" -ForegroundColor Gray
}

$jsFiles = @{
    "site.js" = "// Main site JavaScript`nconsole.log('Site loaded');"
    "animations.js" = "// Animation functionality"
    "contact-form.js" = "// Contact form handling"
}

foreach ($file in $jsFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "wwwroot\js") $file.Key
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] js\$($file.Key)" -ForegroundColor Gray
}

# Create Admin Area files
Write-Host "`nCreating Admin Area files..." -ForegroundColor Cyan

$adminControllers = @{
    "DashboardController.cs" = @"
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    [Area("Admin")]
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
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] Admin\Controllers\$($file.Key)" -ForegroundColor Gray
}

$adminView = @'
@{
    ViewData["Title"] = "Admin Dashboard";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Admin Dashboard</h2>
<p>Welcome to the admin area.</p>
'@
Set-Content -Path (Join-Path $rootPath "Areas\Admin\Views\Dashboard\Index.cshtml") -Value $adminView -Encoding UTF8
Write-Host "  [+] Admin\Views\Dashboard\Index.cshtml" -ForegroundColor Gray

# Create Helper files
Write-Host "`nCreating Helper files..." -ForegroundColor Cyan

$helperFiles = @{
    "ImageHelper.cs" = @"
namespace PortfolioWebsite.Helpers
{
    public static class ImageHelper
    {
        public static string GetImagePath(string filename)
        {
            return $"/images/{filename}";
        }
    }
}
"@
    "ValidationHelper.cs" = @"
using System.Text.RegularExpressions;

namespace PortfolioWebsite.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
"@
}

foreach ($file in $helperFiles.GetEnumerator()) {
    $filePath = Join-Path (Join-Path $rootPath "Helpers") $file.Key
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] $($file.Key)" -ForegroundColor Gray
}

# Create Repository files
Write-Host "`nCreating Repository files..." -ForegroundColor Cyan

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
        Task DeleteAsync(int id);
    }
}
"@
    "Repository.cs" = @"
using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
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

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
"@
    "UnitOfWork.cs" = @"
using PortfolioWebsite.Data;
using System.Threading.Tasks;

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
    Set-Content -Path $filePath -Value $file.Value -Encoding UTF8
    Write-Host "  [+] $($file.Key)" -ForegroundColor Gray
}

# Create root configuration files
Write-Host "`nCreating configuration files..." -ForegroundColor Cyan

$appsettings = @'
{
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
    "SenderEmail": "your-email@example.com"
  }
}
'@
Set-Content -Path (Join-Path $rootPath "appsettings.json") -Value $appsettings -Encoding UTF8
Write-Host "  [+] appsettings.json" -ForegroundColor Gray

$appsettingsDev = @'
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information"
    }
  }
}
'@
Set-Content -Path (Join-Path $rootPath "appsettings.Development.json") -Value $appsettingsDev -Encoding UTF8
Write-Host "  [+] appsettings.Development.json" -ForegroundColor Gray

$programCs = @"
using Microsoft.EntityFrameworkCore;
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

app.Run();
"@
Set-Content -Path (Join-Path $rootPath "Program.cs") -Value $programCs -Encoding UTF8
Write-Host "  [+] Program.cs" -ForegroundColor Gray

$startupCs = @"
using Microsoft.EntityFrameworkCore;
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
}
"@
Set-Content -Path (Join-Path $rootPath "Startup.cs") -Value $startupCs -Encoding UTF8
Write-Host "  [+] Startup.cs" -ForegroundColor Gray

$readme = @"
# Portfolio Website

A professional portfolio website built with ASP.NET Core MVC.

## Features
- Responsive design
- Project showcase
- Skills display
- Blog functionality
- Contact form
- Admin area

## Setup Instructions
1. Update connection string in appsettings.json
2. Run: dotnet ef migrations add InitialCreate
3. Run: dotnet ef database update
4. Run: dotnet run

## Technologies
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
"@
Set-Content -Path (Join-Path $rootPath "README.md") -Value $readme -Encoding UTF8
Write-Host "  [+] README.md" -ForegroundColor Gray

# Create placeholder file
New-Item -ItemType File -Path (Join-Path $rootPath "wwwroot\documents\resume.pdf") -Force | Out-Null
Write-Host "  [+] wwwroot\documents\resume.pdf" -ForegroundColor Gray

Write-Host "`n================================================" -ForegroundColor Green
Write-Host "SUCCESS! Portfolio structure created" -ForegroundColor Green
Write-Host "================================================" -ForegroundColor Green
Write-Host "`nLocation: $rootPath" -ForegroundColor Yellow
Write-Host "`nNext Steps:" -ForegroundColor Cyan
Write-Host "1. cd $projectName" -ForegroundColor White
Write-Host "2. dotnet new sln" -ForegroundColor White
Write-Host "3. dotnet new mvc -n PortfolioWebsite (if needed)" -ForegroundColor White
Write-Host "4. Install NuGet packages" -ForegroundColor White
Write-Host "5. Run migrations" -ForegroundColor White
Write-Host "`nHappy Coding! 🚀" -ForegroundColor Magenta