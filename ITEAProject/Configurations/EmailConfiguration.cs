using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Configurations
{
    public class EmailConfiguration
    {
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
        public string MailBoxFromName { get; set; }
        public string MailBoxToName { get; set; }
        public string MessageSubject { get; set; }
        public string ConnectHost { get; set; }
        public int ConntectPort { get; set; }
        public bool ConnectSSL { get; set; }
        public string MessageText { get; set; }
    }
}
