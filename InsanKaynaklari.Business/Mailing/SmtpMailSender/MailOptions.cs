using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.Mailing.SmtpMailSender
{
    public class MailOptions
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
    }
}
