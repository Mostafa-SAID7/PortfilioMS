using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfilioMS.Models.Entities;

namespace PortfilioMS.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.ProficiencyLevel)
                .HasDefaultValue(0);

            builder.Property(s => s.IconClass)
                .HasMaxLength(100);

            builder.Property(s => s.ColorCode)
                .HasMaxLength(50);

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.Property(s => s.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(s => s.Category);
            builder.HasIndex(s => s.IsActive);
            builder.HasIndex(s => s.DisplayOrder);
        }
    }
}
