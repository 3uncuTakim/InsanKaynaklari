using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsanKaynaklari.Utilities.Mailing
{
    public class MailTemplate
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] To { get; set; }

        public MailTemplate(string from, string subject, string body, params string[] to)
        {
            From = from;
            Subject = subject;
            Body = body;
            To = to;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
