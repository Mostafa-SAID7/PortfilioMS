using Microsoft.EntityFrameworkCore;
using PortfilioMS.Models.Entities;
using System;

namespace PortfilioMS.Data.Seeds
{
    public static class ExperienceSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    JobTitle = "Senior Software Engineer",
                    Company = "Tech Solutions Inc.",
                    Location = "Cairo, Egypt",
                    EmploymentType = "Full-time",
                    StartDate = new DateTime(2022, 7, 1),
                    EndDate = null,
                    IsCurrentJob = true,
                    Description = "Developing and maintaining enterprise-level web applications using ASP.NET Core, React, and Azure services.",
                    Responsibilities = "Develop, Test, Deploy, Maintain applications",
                    TechnologiesUsed = "ASP.NET Core, React, SQL Server, Azure, Docker",
                    Achievements = "Led a team of 5 developers and delivered multiple successful projects.",
                    CompanyWebsite = "https://techsolutions.com",
                    DisplayOrder = 1,
                    IsVisible = true,
                    CreatedDate = DateTime.UtcNow.AddYears(-2),
                    UpdatedDate = DateTime.UtcNow.AddMonths(-1)
                },
                new Experience
                {
                    Id = 2,
                    JobTitle = "Full Stack Developer",
                    Company = "Digital Innovations LLC",
                    Location = "Alexandria, Egypt",
                    EmploymentType = "Full-time",
                    StartDate = new DateTime(2020, 6, 1),
                    EndDate = new DateTime(2022, 6, 30),
                    IsCurrentJob = false,
                    Description = "Built responsive web applications and REST APIs for various clients across different industries.",
                    Responsibilities = "Develop APIs, Design UI, Optimize SQL queries",
                    TechnologiesUsed = "ASP.NET MVC, Angular, Entity Framework, SQL Server",
                    Achievements = "Improved performance by 30% through optimized API endpoints.",
                    CompanyWebsite = "https://digitalinnovations.com",
                    DisplayOrder = 2,
                    IsVisible = true,
                    CreatedDate = DateTime.UtcNow.AddYears(-3),
                    UpdatedDate = DateTime.UtcNow.AddMonths(-4)
                },
                new Experience
                {
                    Id = 3,
                    JobTitle = "Junior Developer",
                    Company = "StartUp Ventures",
                    Location = "Remote",
                    EmploymentType = "Internship",
                    StartDate = new DateTime(2019, 1, 1),
                    EndDate = new DateTime(2020, 5, 31),
                    IsCurrentJob = false,
                    Description = "Started as an intern and quickly progressed to a junior developer role. Worked on multiple small-scale web projects.",
                    Responsibilities = "Assist in development, Fix bugs, Write documentation",
                    TechnologiesUsed = "C#, ASP.NET, JavaScript, HTML, CSS",
                    Achievements = "Developed a reusable component library for internal projects.",
                    CompanyWebsite = "https://startupventures.com",
                    DisplayOrder = 3,
                    IsVisible = true,
                    CreatedDate = DateTime.UtcNow.AddYears(-5),
                    UpdatedDate = DateTime.UtcNow.AddYears(-3)
                }
            );
        }
    }
}
