using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class EmailMessageSender:IMessageSender
    {
        private readonly IConfiguration configuration;
        public EmailMessageSender (IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void SendMessage()
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Infestation","nglackikh@gmail.com"));
            message.To.Add(new MailboxAddress("Natalia", "nataliaglackikh@gmail.com"));

            message.Subject = "Test email";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Hello World";

            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect("smtp.gmail.com", 465,true);
                client.Authenticate(configuration.GetSection("Infestation")["EmailAddress"], 
                                    configuration.GetSection("Infestation")["EmailPassword"]);
                //client.Authenticate("nglackikh@gmail.com","animaljazz2000");
                client.Send(message);
                client.Disconnect(true);
            }
        }
        
    }
}
