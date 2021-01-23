using Lesson4Project.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class EmailMessageSender:IMessageSender
    {
        private readonly InfestationEmailConfiguration emailConfiguration;
        public EmailMessageSender (IOptions<InfestationEmailConfiguration> options)
        {
            emailConfiguration = options.Value;
        }
        public void SendMessage(string addressTo, string messageText)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfiguration.MailBoxFromName, emailConfiguration.EmailAddress));
            message.To.Add(new MailboxAddress(emailConfiguration.MailBoxToName, addressTo));

            message.Subject = emailConfiguration.MessageSubject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = messageText;

            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect(emailConfiguration.ConnectHost, emailConfiguration.ConntectPort,emailConfiguration.ConnectSSL);
                client.Authenticate(emailConfiguration.EmailAddress, emailConfiguration.EmailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        
    }
}
