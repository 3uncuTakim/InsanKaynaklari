using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.API
{
    public class GetHolidays
    {
        public static List<Resmitatiller> GetPublicHoliday()
        {
            string json = new WebClient().DownloadString("https://api.ubilisim.com/resmitatiller/");
            PublicHolidayRoot publicHoliday = JsonConvert.DeserializeObject<PublicHolidayRoot>(json);
            return publicHoliday.resmitatiller.ToList();
        }
    }
}
