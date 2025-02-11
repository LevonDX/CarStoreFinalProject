namespace CarStore.Web.Services
{
    public interface ICarSendMailService
    {
        Task SendMailAsync(string to, string subject, string body);
    }
}
