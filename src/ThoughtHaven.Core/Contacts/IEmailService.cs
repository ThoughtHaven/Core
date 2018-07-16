using System.Threading.Tasks;

namespace ThoughtHaven.Contacts
{
    public interface IEmailService
    {
        Task Send(EmailMessage message);
    }
}