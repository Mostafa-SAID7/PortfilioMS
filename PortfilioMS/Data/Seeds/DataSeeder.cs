using Microsoft.EntityFrameworkCore;

namespace PortfilioMS.Data.Seeds
{
    public static class DataSeeder
    {

        public static void SeedAll(ModelBuilder modelBuilder)
        {
            IdentitySeeder.Seed(modelBuilder);
            SkillSeeder.Seed(modelBuilder);
            EducationSeeder.Seed(modelBuilder);
            ExperienceSeed.Seed(modelBuilder);
            ProjectSeed.Seed(modelBuilder);
            BlogPostSeed.Seed(modelBuilder);
        }
    }
}
