using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfilioMS.Models.Entities;

namespace PortfilioMS.Data.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Degree)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Institution)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.FieldOfStudy)
                .HasMaxLength(100);

            builder.Property(e => e.Location)
                .HasMaxLength(200);

            builder.Property(e => e.Grade)
                .HasMaxLength(20);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Achievements)
                .HasMaxLength(500);

            builder.Property(e => e.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(e => e.IsVisible)
                .HasDefaultValue(true);

            builder.Property(e => e.IsCurrentlyStudying)
                .HasDefaultValue(false);

            builder.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(e => e.StartDate);
            builder.HasIndex(e => e.DisplayOrder);
            builder.HasIndex(e => e.IsVisible);
        }
    }
}
