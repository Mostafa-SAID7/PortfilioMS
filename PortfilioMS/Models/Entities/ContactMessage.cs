using System;
using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models.Entities
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(150)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters")]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [Display(Name = "Sent Date")]
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Is Read")]
        public bool IsRead { get; set; } = false;

        [Display(Name = "Read Date")]
        public DateTime? ReadDate { get; set; }

        [Display(Name = "Is Replied")]
        public bool IsReplied { get; set; } = false;

        [Display(Name = "Reply Date")]
        public DateTime? ReplyDate { get; set; }

        [StringLength(50)]
        [Display(Name = "IP Address")]
        public string IpAddress { get; set; }

        [StringLength(200)]
        [Display(Name = "User Agent")]
        public string UserAgent { get; set; }

        [Display(Name = "Is Spam")]
        public bool IsSpam { get; set; } = false;

        [StringLength(2000)]
        [Display(Name = "Admin Notes")]
        public string AdminNotes { get; set; }
    }
}
