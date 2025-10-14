using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string message)
        {
            // Implement email sending logic
            await Task.CompletedTask;
        }
    }
}
