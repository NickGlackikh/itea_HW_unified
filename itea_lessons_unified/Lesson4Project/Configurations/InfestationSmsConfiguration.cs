using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Configurations
{
    public class InfestationSmsConfiguration
    {
        public string AccountId { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumberSend { get; set; }
    }
}
