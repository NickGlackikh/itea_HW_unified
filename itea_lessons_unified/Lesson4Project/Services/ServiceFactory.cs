using Lesson4Project.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class ServiceFactory
    {
        
        private readonly IOptions<InfestationEmailConfiguration> emailConfig;
        private readonly IOptions<InfestationSmsConfiguration> smsConfig;
        public ServiceFactory( IOptions<InfestationEmailConfiguration> emailoptions,
                               IOptions<InfestationSmsConfiguration> smsOptions)
        {
            emailConfig = emailoptions;
            smsConfig = smsOptions;
        }
        public IMessageSender getSenderType(string senderType)
        {
            if(senderType=="sms")
            {
                return new SMSMessageSender(smsConfig);
            }
            if (senderType == "email")
            {
                return new EmailMessageSender(emailConfig);
            }
            return null;
        }
    }
}
