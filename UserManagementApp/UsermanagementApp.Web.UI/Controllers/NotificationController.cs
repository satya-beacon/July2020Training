using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsermanagementApp.Web.UI.Helpers;

namespace UsermanagementApp.Web.UI.Controllers
{
    public class NotificationController : Controller
    {
        private EmailSettings settings;
        public NotificationController(IOptions<EmailSettings> settings)
        {
            this.settings = settings.Value;
        }
        public string Index()
        {
            var smtpServer = this.settings.SmtpServer;
            
            return smtpServer;
        }
    }
}
