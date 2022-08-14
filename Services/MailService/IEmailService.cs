namespace PracticeProject.Services.MailService
{
    public interface IEmailService
    {
        Task SendMailAsync(EmailParams emailDto);
    }
}