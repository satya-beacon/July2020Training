using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsermanagementApp.Web.UI.Helpers
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }

        public string Signature { get; set; }
    }
}
