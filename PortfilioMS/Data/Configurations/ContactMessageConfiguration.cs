using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioWebsite.Models;

namespace PortfilioMS.Data.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cm => cm.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(cm => cm.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(cm => cm.Subject)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(cm => cm.Message)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(cm => cm.AdminNotes)
                .HasMaxLength(2000);

            builder.Property(cm => cm.IpAddress)
                .HasMaxLength(50);

            builder.Property(cm => cm.UserAgent)
                .HasMaxLength(200);

            builder.Property(cm => cm.SentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(cm => cm.IsRead)
                .HasDefaultValue(false);

            builder.Property(cm => cm.IsReplied)
                .HasDefaultValue(false);

            builder.Property(cm => cm.IsSpam)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(cm => cm.SentDate);
            builder.HasIndex(cm => cm.IsRead);
            builder.HasIndex(cm => cm.IsSpam);
            builder.HasIndex(cm => cm.Email);
        }
    }
}
