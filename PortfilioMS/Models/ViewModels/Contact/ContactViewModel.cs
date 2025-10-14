using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfilioMS.Models.ViewModels.Contact
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number (Optional)")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters")]
        [Display(Name = "Your Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        // reCAPTCHA
        public string RecaptchaResponse { get; set; }

        // Contact Information Display
        public string DisplayEmail { get; set; }
        public string DisplayPhone { get; set; }
        public string DisplayLocation { get; set; }

        // Social Media Links
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
    }
}
