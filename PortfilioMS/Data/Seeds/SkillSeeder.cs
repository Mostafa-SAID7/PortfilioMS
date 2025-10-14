using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfilioMS.Data.Seeds
{
    public static class SkillSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                // Frontend Skills
                new Skill { Id = 1, Name = "HTML5", Category = "Frontend", ProficiencyLevel = 95, IconClass = "fab fa-html5", ColorCode = "#E34F26", YearsOfExperience = 5, DisplayOrder = 1, IsActive = true },
                new Skill { Id = 2, Name = "CSS3", Category = "Frontend", ProficiencyLevel = 95, IconClass = "fab fa-css3-alt", ColorCode = "#1572B6", YearsOfExperience = 5, DisplayOrder = 2, IsActive = true },
                new Skill { Id = 3, Name = "JavaScript", Category = "Frontend", ProficiencyLevel = 90, IconClass = "fab fa-js", ColorCode = "#F7DF1E", YearsOfExperience = 5, DisplayOrder = 3, IsActive = true },
                new Skill { Id = 4, Name = "React", Category = "Frontend", ProficiencyLevel = 85, IconClass = "fab fa-react", ColorCode = "#61DAFB", YearsOfExperience = 3, DisplayOrder = 4, IsActive = true },
                new Skill { Id = 5, Name = "Bootstrap", Category = "Frontend", ProficiencyLevel = 90, IconClass = "fab fa-bootstrap", ColorCode = "#7952B3", YearsOfExperience = 4, DisplayOrder = 5, IsActive = true },
                new Skill { Id = 6, Name = "TypeScript", Category = "Frontend", ProficiencyLevel = 80, IconClass = "fas fa-code", ColorCode = "#3178C6", YearsOfExperience = 2, DisplayOrder = 6, IsActive = true },

                // Backend Skills
                new Skill { Id = 7, Name = "C#", Category = "Backend", ProficiencyLevel = 90, IconClass = "fas fa-code", ColorCode = "#239120", YearsOfExperience = 5, DisplayOrder = 7, IsActive = true },
                new Skill { Id = 8, Name = "ASP.NET Core", Category = "Backend", ProficiencyLevel = 88, IconClass = "fas fa-server", ColorCode = "#512BD4", YearsOfExperience = 4, DisplayOrder = 8, IsActive = true },
                new Skill { Id = 9, Name = "Node.js", Category = "Backend", ProficiencyLevel = 80, IconClass = "fab fa-node-js", ColorCode = "#339933", YearsOfExperience = 3, DisplayOrder = 9, IsActive = true },
                new Skill { Id = 10, Name = "RESTful API", Category = "Backend", ProficiencyLevel = 85, IconClass = "fas fa-plug", ColorCode = "#009688", YearsOfExperience = 4, DisplayOrder = 10, IsActive = true },

                // Database Skills
                new Skill { Id = 11, Name = "SQL Server", Category = "Database", ProficiencyLevel = 85, IconClass = "fas fa-database", ColorCode = "#CC2927", YearsOfExperience = 5, DisplayOrder = 11, IsActive = true },
                new Skill { Id = 12, Name = "MongoDB", Category = "Database", ProficiencyLevel = 75, IconClass = "fas fa-leaf", ColorCode = "#47A248", YearsOfExperience = 2, DisplayOrder = 12, IsActive = true },
                new Skill { Id = 13, Name = "PostgreSQL", Category = "Database", ProficiencyLevel = 70, IconClass = "fas fa-database", ColorCode = "#336791", YearsOfExperience = 2, DisplayOrder = 13, IsActive = true },

                // Tools & DevOps
                new Skill { Id = 14, Name = "Git", Category = "Tools", ProficiencyLevel = 85, IconClass = "fab fa-git-alt", ColorCode = "#F05032", YearsOfExperience = 5, DisplayOrder = 14, IsActive = true },
                new Skill { Id = 15, Name = "Docker", Category = "DevOps", ProficiencyLevel = 70, IconClass = "fab fa-docker", ColorCode = "#2496ED", YearsOfExperience = 2, DisplayOrder = 15, IsActive = true },
                new Skill { Id = 16, Name = "Azure", Category = "Cloud", ProficiencyLevel = 75, IconClass = "fab fa-microsoft", ColorCode = "#0089D6", YearsOfExperience = 3, DisplayOrder = 16, IsActive = true },
                new Skill { Id = 17, Name = "GitHub", Category = "Tools", ProficiencyLevel = 90, IconClass = "fab fa-github", ColorCode = "#181717", YearsOfExperience = 5, DisplayOrder = 17, IsActive = true },
                new Skill { Id = 18, Name = "Visual Studio", Category = "Tools", ProficiencyLevel = 85, IconClass = "fas fa-laptop-code", ColorCode = "#5C2D91", YearsOfExperience = 5, DisplayOrder = 18, IsActive = true }
            );
        }
    }
}
