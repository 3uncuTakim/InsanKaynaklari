using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.API
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Resmitatiller
    {
        public string gun { get; set; }
        public string en { get; set; }
        public string haftagunu { get; set; }
        public string tarih { get; set; }
        public string uzuntarih { get; set; }
    }

    public class PublicHolidayRoot
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string pagecreatedate { get; set; }
        public List<Resmitatiller> resmitatiller { get; set; }
    }

}
