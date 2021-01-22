using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;
        public SMSMessageSender(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void SendMessage()
        {
            TwilioClient.Init(configuration.GetSection("Twilio")["AccountId"],
                              configuration.GetSection("Twilio")["AuthToken"]);
            var message = MessageResource.Create(from: new PhoneNumber("+14704144273"), 
                                                 to: new PhoneNumber("+380662959548"), 
                                                 body:"Test SMS");
            Console.WriteLine(message.Status);
        }
    }
}
