using System.Threading.Tasks;

namespace Petify.Common.Infrastructure.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, EmailTemplate emailTemplate);
    }
}
