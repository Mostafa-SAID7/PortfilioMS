using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioWebsite.Models;

namespace PortfilioMS.Data.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(ex => ex.Id);

            builder.Property(ex => ex.JobTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ex => ex.Company)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ex => ex.Location)
                .HasMaxLength(200);

            builder.Property(ex => ex.EmploymentType)
                .HasMaxLength(50);

            builder.Property(ex => ex.Description)
                .HasMaxLength(1000);

            builder.Property(ex => ex.TechnologiesUsed)
                .HasMaxLength(500);

            builder.Property(ex => ex.Achievements)
                .HasMaxLength(500);

            builder.Property(ex => ex.CompanyWebsite)
                .HasMaxLength(500);

            builder.Property(ex => ex.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(ex => ex.IsVisible)
                .HasDefaultValue(true);

            builder.Property(ex => ex.IsCurrentJob)
                .HasDefaultValue(false);

            builder.Property(ex => ex.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(ex => ex.StartDate);
            builder.HasIndex(ex => ex.DisplayOrder);
            builder.HasIndex(ex => ex.IsVisible);
            builder.HasIndex(ex => ex.IsCurrentJob);
        }
    }
}
