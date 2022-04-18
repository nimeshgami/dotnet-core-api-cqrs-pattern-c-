using System.Threading.Tasks;
using ExampleProject.Application.Configuration.Emails;

namespace ExampleProject.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            // Integration with email service.

            return;
        }
    }
}