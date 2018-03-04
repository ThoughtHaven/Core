using System.Threading.Tasks;

namespace ThoughtHaven.Messages.Emails
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message);
    }
}