using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Utilities.Mailing.FakeMailSender
{
    public class FakeMailSender : IMailService
    {
        public void SendEmail(MailTemplate mailTemplate)
        {
            Console.WriteLine(mailTemplate);
        }
    }
}