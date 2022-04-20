using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class PersonelEvent
    {
        public int EventID { get; set; }
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }  
        public virtual Event Event { get; set; }    
    }
}
