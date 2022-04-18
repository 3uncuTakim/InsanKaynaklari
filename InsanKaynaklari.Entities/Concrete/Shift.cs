using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Shift : BaseEntity
    {
        public DateTime ShiftDay { get; set; }
        public DateTime StartOfShift { get; set; }
        public DateTime EndOfShift { get; set; }
        public string Description { get; set; }

        //Relational  Properties Begin
        //One to many with personel
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
