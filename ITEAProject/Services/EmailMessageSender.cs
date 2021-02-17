using ITEAProject.Configurations;
using ITEAProject.Services.Repositories;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class EmailMessageSender:IMessageSender
    {
        private readonly EmailConfiguration emailConfiguration;
        public EmailMessageSender(IOptions<EmailConfiguration> options)
        {
            emailConfiguration = options.Value;
        }
        public void SendMessage(string addressTo)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfiguration.MailBoxFromName, emailConfiguration.EmailAddress));
            message.To.Add(new MailboxAddress(emailConfiguration.MailBoxToName, addressTo));

            message.Subject = emailConfiguration.MessageSubject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailConfiguration.MessageText;

            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect(emailConfiguration.ConnectHost, emailConfiguration.ConntectPort, emailConfiguration.ConnectSSL);
                client.Authenticate(emailConfiguration.EmailAddress, emailConfiguration.EmailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
