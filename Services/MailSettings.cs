using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo5.Services
{
    public class MailSettings
    {
        public string FromEmail { get; set; }
        public SmtpSettings Smtp { get; set; }
        public class SmtpSettings
        {
            public string Host { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Port { get; set; }
            public bool Ssl { get; set; }
        }
    }
}
