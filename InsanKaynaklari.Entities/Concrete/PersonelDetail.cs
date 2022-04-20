using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class PersonelDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public decimal Wage { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string WorkStyle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //Relational  Properties Begin
        //one to one with Personel
        public virtual Personel Personel { get; set; }

      
    }
}
