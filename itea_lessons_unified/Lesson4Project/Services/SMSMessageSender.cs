using Lesson4Project.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Lesson4Project.Services
{
    public class SMSMessageSender:IMessageSender
    {
        private readonly InfestationSmsConfiguration smsConfiguration;

        public SMSMessageSender(IOptions<InfestationSmsConfiguration> options)
        {
            smsConfiguration = options.Value;
        }
        public void SendMessage(string addressTo, string messageText)
        {

            TwilioClient.Init(smsConfiguration.AccountId, smsConfiguration.AuthToken);
                              
            var message = MessageResource.Create(from: new PhoneNumber(smsConfiguration.PhoneNumberSend), 
                                                 to: new PhoneNumber(addressTo), 
                                                 body: messageText);
            Console.WriteLine(message.Status);
        }
    }
}
