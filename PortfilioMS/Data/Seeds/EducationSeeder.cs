using Microsoft.EntityFrameworkCore;
using PortfilioMS.Models.Entities;

namespace PortfilioMS.Data.Seeds
{
    public static class EducationSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    Id = 1,
                    Degree = "Bachelor of Science in Computer Science",
                    Institution = "University of Technology",
                    FieldOfStudy = "Computer Science",
                    Location = "City, Country",
                    StartDate = new DateTime(2016, 9, 1),
                    EndDate = new DateTime(2020, 6, 30),
                    IsCurrentlyStudying = false,
                    Grade = "3.8 GPA",
                    Description = "Comprehensive study of computer science fundamentals including algorithms, data structures, software engineering, and web development.",
                    Achievements = "Dean's List, Outstanding Project Award",
                    DisplayOrder = 1,
                    IsVisible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Education
                {
                    Id = 2,
                    Degree = "Microsoft Certified: Azure Developer Associate",
                    Institution = "Microsoft",
                    FieldOfStudy = "Cloud Computing",
                    Location = "Online",
                    StartDate = new DateTime(2022, 3, 1),
                    EndDate = new DateTime(2022, 5, 15),
                    IsCurrentlyStudying = false,
                    Description = "Professional certification in Azure cloud services and application development.",
                    DisplayOrder = 2,
                    IsVisible = true,
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
