using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
