using ModernStore.Domain.Services;

namespace ModernStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            // System.Net.Mail => Enviar E-mail
        }
    }
}
