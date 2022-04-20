using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InsanKaynaklari.Utilities.Mailing.SmtpMailSender
{
    public class SmtpMailService : IMailService
    {
        private readonly MailOptions _mailOptions;
        public SmtpMailService(IConfiguration configuration)
        {
            _mailOptions = configuration.GetSection("MailConfig").Get<MailOptions>();
        }

        public void SendEmail(MailTemplate mailTemplate)
        {
            for (int i = 0; i < mailTemplate.To.Length; i++)
            {
                MailMessage message = new(mailTemplate.From,
                                          mailTemplate.To[i],
                                          mailTemplate.Subject,
                                          mailTemplate.Body);

                NetworkCredential netCred = new(_mailOptions.Email, _mailOptions.Password);
                SmtpClient smtpobj = new(_mailOptions.SmtpHost, _mailOptions.SmtpPort);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                smtpobj.Send(message);
            }
        }
    }
}
