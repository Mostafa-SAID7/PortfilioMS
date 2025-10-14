using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;
using System;

namespace PortfilioMS.Data.Seeds
{
    public static class ProjectSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "E-Commerce Platform",
                    ShortDescription = "Full-featured online shopping platform",
                    DetailedDescription = "A complete e-commerce solution with user authentication, product management, shopping cart, and payment integration.",
                    Technologies = "ASP.NET Core, Entity Framework, SQL Server, React, Stripe API",
                    ImageUrl = "/images/projects/ecommerce.jpg",
                    LiveDemoUrl = "https://ecommerce-demo.com",
                    GithubUrl = "https://github.com/username/ecommerce-platform",
                    Category = "Web Application",
                    StartDate = DateTime.UtcNow.AddMonths(-4),
                    EndDate = DateTime.UtcNow.AddMonths(-1),
                    IsFeatured = true,
                    IsPublished = true,
                    DisplayOrder = 1,
                    ViewCount = 0,
                    CreatedDate = DateTime.UtcNow.AddDays(-30),
                    UpdatedDate = DateTime.UtcNow.AddDays(-5)
                },
                new Project
                {
                    Id = 2,
                    Title = "Task Management App",
                    ShortDescription = "Collaborative task and project management tool",
                    DetailedDescription = "A Kanban-style task management application with real-time updates, team collaboration, and progress tracking.",
                    Technologies = "ASP.NET Core, SignalR, Angular, PostgreSQL, Docker",
                    ImageUrl = "/images/projects/taskmanager.jpg",
                    LiveDemoUrl = "https://taskmanager-demo.com",
                    GithubUrl = "https://github.com/username/task-manager",
                    Category = "Web Application",
                    StartDate = DateTime.UtcNow.AddMonths(-6),
                    EndDate = DateTime.UtcNow.AddMonths(-2),
                    IsFeatured = true,
                    IsPublished = true,
                    DisplayOrder = 2,
                    ViewCount = 0,
                    CreatedDate = DateTime.UtcNow.AddDays(-60),
                    UpdatedDate = DateTime.UtcNow.AddDays(-10)
                },
                new Project
                {
                    Id = 3,
                    Title = "Portfolio Website",
                    ShortDescription = "Personal portfolio and blog",
                    DetailedDescription = "A responsive portfolio website with blog functionality, project showcase, and contact form.",
                    Technologies = "ASP.NET Core MVC, Bootstrap, JavaScript, SQL Server",
                    ImageUrl = "/images/projects/portfolio.jpg",
                    LiveDemoUrl = "https://myportfolio.com",
                    GithubUrl = "https://github.com/username/portfolio",
                    Category = "Website",
                    StartDate = DateTime.UtcNow.AddMonths(-8),
                    EndDate = DateTime.UtcNow.AddMonths(-3),
                    IsFeatured = false,
                    IsPublished = true,
                    DisplayOrder = 3,
                    ViewCount = 0,
                    CreatedDate = DateTime.UtcNow.AddDays(-90),
                    UpdatedDate = DateTime.UtcNow.AddDays(-15)
                },
                new Project
                {
                    Id = 4,
                    Title = "Weather Forecast API",
                    ShortDescription = "REST API for weather data",
                    DetailedDescription = "A microservice providing weather forecast data with caching, rate limiting, and multiple data sources.",
                    Technologies = "ASP.NET Core Web API, Redis, MongoDB, Docker, Kubernetes",
                    ImageUrl = "/images/projects/weatherapi.jpg",
                    LiveDemoUrl = "https://weatherapi-demo.com",
                    GithubUrl = "https://github.com/username/weather-api",
                    Category = "API",
                    StartDate = DateTime.UtcNow.AddMonths(-2),
                    EndDate = null, // still in progress
                    IsFeatured = false,
                    IsPublished = true,
                    DisplayOrder = 4,
                    ViewCount = 0,
                    CreatedDate = DateTime.UtcNow.AddDays(-15),
                    UpdatedDate = DateTime.UtcNow.AddDays(-2)
                }
            );
        }
    }
}
