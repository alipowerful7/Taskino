namespace Taskino.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendConfirmationEmailAsync(string email, string confirmationCode);
    }
}
