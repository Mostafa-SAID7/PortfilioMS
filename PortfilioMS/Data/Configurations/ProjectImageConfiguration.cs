using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfilioMS.Models;

namespace PortfilioMS.Data.Configurations
{
    public class ProjectImageConfiguration : IEntityTypeConfiguration<ProjectImage>
    {
        public void Configure(EntityTypeBuilder<ProjectImage> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(pi => pi.Caption)
                .HasMaxLength(200);

            builder.Property(pi => pi.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(pi => pi.IsPrimary)
                .HasDefaultValue(false);

            builder.Property(pi => pi.UploadedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(pi => pi.ProjectId);
            builder.HasIndex(pi => pi.IsPrimary);
        }
    }
}
