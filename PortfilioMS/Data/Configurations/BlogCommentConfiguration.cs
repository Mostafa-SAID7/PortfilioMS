using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfilioMS.Models;

namespace PortfilioMS.Data.Configurations
{
    public class BlogCommentConfiguration : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.HasKey(bc => bc.Id);

            builder.Property(bc => bc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(bc => bc.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(bc => bc.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(bc => bc.IpAddress)
                .HasMaxLength(50);

            builder.Property(bc => bc.CommentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(bc => bc.IsApproved)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(bc => bc.BlogPostId);
            builder.HasIndex(bc => bc.CommentDate);
            builder.HasIndex(bc => bc.IsApproved);
        }
    }
}
