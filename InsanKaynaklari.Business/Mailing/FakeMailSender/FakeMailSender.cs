using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.Mailing.FakeMailSender
{
    public class FakeMailSender : IMailService
    {
        public void SendEmail(MailTemplate mailTemplate)
        {
            Console.WriteLine(mailTemplate);
        }
    }
}