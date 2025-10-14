using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioWebsite.Models;

namespace PortfilioMS.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.DetailedDescription)
                .IsRequired();

            builder.Property(p => p.Technologies)
                .HasMaxLength(500);

            builder.Property(p => p.Category)
                .HasMaxLength(100);

            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.ViewCount)
                .HasDefaultValue(0);

            builder.Property(p => p.IsFeatured)
                .HasDefaultValue(false);

            builder.Property(p => p.IsPublished)
                .HasDefaultValue(true);

            builder.Property(p => p.DisplayOrder)
                .HasDefaultValue(0);

            // Indexes
            builder.HasIndex(p => p.Category);
            builder.HasIndex(p => p.IsFeatured);
            builder.HasIndex(p => p.IsPublished);
            builder.HasIndex(p => p.CreatedDate);

            // Relationships
            builder.HasOne(p => p.CreatedBy)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ProjectImages)
                .WithOne(pi => pi.Project)
                .HasForeignKey(pi => pi.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
