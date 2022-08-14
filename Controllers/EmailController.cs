using Microsoft.AspNetCore.Mvc;
using PracticeProject.Services.MailService;

namespace PracticeProject.Controllers
{
    [ApiController]
    [Route("api/emailcontroller")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendEma")]
        public async Task<ActionResult> SendEmailAsync()
        {
            
            var emailParams = new EmailParams()
            {
                Message = "ksaskdn",
                MethodName = "dfafqd",
                DateTime = "sdfsfw",
                Subject = "sdfsfs2342"
            };
            await _emailService.SendMailAsync(emailParams);             
                
            
            return Ok();
        }
    }
}