using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlogProject.Utilities.Mailing
{
    public interface IMailService
    {
        public void SendEmail(MailTemplate mailTemplate);
    }
}