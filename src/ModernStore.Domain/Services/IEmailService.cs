namespace ModernStore.Domain.Services
{
    public interface IEmailService
    {
        void Send(string name, string email, string subject, string body);
    }
}
