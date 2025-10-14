using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PortfolioWebsite.Helpers
{
    public interface IValidationHelper
    {
        bool IsValidEmail(string email);
        bool IsValidPhoneNumber(string phoneNumber);
        bool IsValidUrl(string url);
        bool IsStrongPassword(string password);
        string SanitizeHtml(string input);
        bool IsValidImageFile(string fileName);
    }

    public class ValidationHelper : IValidationHelper
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Basic international phone number validation
            return Regex.IsMatch(phoneNumber,
                @"^\+?[1-9]\d{1,14}$",
                RegexOptions.None, TimeSpan.FromMilliseconds(250));
        }

        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            // Check for at least one uppercase, one lowercase, one number, and one special character
            var hasUpperCase = Regex.IsMatch(password, "[A-Z]");
            var hasLowerCase = Regex.IsMatch(password, "[a-z]");
            var hasDigits = Regex.IsMatch(password, "[0-9]");
            var hasSpecialChar = Regex.IsMatch(password, "[!@#$%^&*(),.?:{}|<>]");

            return hasUpperCase && hasLowerCase && hasDigits && hasSpecialChar;
        }

        public string SanitizeHtml(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Basic HTML sanitization - remove script tags and dangerous attributes
            var sanitized = Regex.Replace(input, @"<script[^>]*>[\s\S]*?</script>", string.Empty, RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"on\w+=""[^""]*""", string.Empty, RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"on\w+='[^']*'", string.Empty, RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"on\w+=\w+", string.Empty, RegexOptions.IgnoreCase);

            return sanitized.Trim();
        }

        public bool IsValidImageFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            return allowedExtensions.Contains(extension);
        }

        public static List<ValidationResult> ValidateObject(object obj)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return validationResults;
        }

        public static bool IsValidSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return false;

            return Regex.IsMatch(slug, @"^[a-z0-9]+(?:-[a-z0-9]+)*$");
        }

        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            var slug = title.ToLowerInvariant();

            // Replace spaces with hyphens
            slug = Regex.Replace(slug, @"\s+", "-");

            // Remove invalid characters
            slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");

            // Replace multiple hyphens with single hyphen
            slug = Regex.Replace(slug, @"-+", "-");

            // Trim hyphens from start and end
            slug = slug.Trim('-');

            return slug;
        }

        public static bool IsValidHexColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return false;

            return Regex.IsMatch(color, @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }
    }
}
