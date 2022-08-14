using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace PracticeProject.Services.MailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMailAsync(EmailParams emailParams)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("MailFrom").Value));
            email.To.Add(MailboxAddress.Parse(_config.GetSection("MailTo").Value));
            
            if (emailParams.Ccs is not null)
            {                
                foreach (var cc in emailParams.Ccs)
                {
                    email.Cc.Add(MailboxAddress.Parse(cc));       
                }
            }
            
            email.Subject = emailParams.Subject;

            var htmlTemplate = await System.IO.File.ReadAllTextAsync("Services/MailService/EmailBody.txt");
            
            email.Body = new TextPart(TextFormat.Html) 
            {
                Text = htmlTemplate 
            };
            
            /*
            we can also use bodybuilder as
            
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlTemplate;
            
            but we have to change this also
            
            email.Body = new TextPart(TextFormat.PlainText)
            {
                Text = bodyBuilder.ToMesage();
            };
            */
            

            using var smtp = new SmtpClient();
            smtp.Connect(_config["Email:Host"], Int32.Parse(_config["Email:Port"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["Email:Username"], _config["Email:Password"]);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);            
        }
    }
}