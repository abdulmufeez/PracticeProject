namespace PracticeProject.Services.MailService
{
    public class EmailParams
    {
        // public EmailParams(List<string> ccs, string methodName, string dateTime, string subject, string message)
        // {
        //     Ccs = ccs;
        //     MethodName = methodName;
        //     DateTime = dateTime;
        //     Subject = subject;
        //     Message = message;
        // }

        public List<string> Ccs { get; set; } = new List<string>();
        public string MethodName { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}