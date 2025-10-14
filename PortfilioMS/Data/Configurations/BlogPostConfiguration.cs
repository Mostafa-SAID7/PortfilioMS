using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioWebsite.Models;

namespace PortfilioMS.Data.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(bp => bp.Id);

            builder.Property(bp => bp.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(bp => bp.Slug)
                .IsRequired()
                .HasMaxLength(350);

            builder.Property(bp => bp.Summary)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(bp => bp.Content)
                .IsRequired();

            builder.Property(bp => bp.Category)
                .HasMaxLength(100);

            builder.Property(bp => bp.Tags)
                .HasMaxLength(500);

            builder.Property(bp => bp.MetaDescription)
                .HasMaxLength(160);

            builder.Property(bp => bp.MetaKeywords)
                .HasMaxLength(200);

            builder.Property(bp => bp.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(bp => bp.ViewCount)
                .HasDefaultValue(0);

            builder.Property(bp => bp.IsPublished)
                .HasDefaultValue(false);

            builder.Property(bp => bp.AllowComments)
                .HasDefaultValue(true);

            // Unique constraint
            builder.HasIndex(bp => bp.Slug)
                .IsUnique();

            // Indexes
            builder.HasIndex(bp => bp.Category);
            builder.HasIndex(bp => bp.IsPublished);
            builder.HasIndex(bp => bp.PublishedDate);
            builder.HasIndex(bp => bp.CreatedDate);

            // Relationships
            builder.HasOne(bp => bp.Author)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(bp => bp.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(bp => bp.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
