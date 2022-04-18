using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Company:BaseEntity
    {
        
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public int CountOfPersonel { get; set; }
        public bool Activation { get; set; }
        //Relational  Properties Begin
        //one to many with Personel
        public virtual List<Personel> Personels { get; set; }

    }
}
