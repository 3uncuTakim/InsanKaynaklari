using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Debit : BaseEntity
    {      
        public string DebitName { get; set; }
        public string DebitCode { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public string Description { get; set; }
        public bool IsCorfirmed { get; set; }

        //Relational  Properties Begin

        //one to many with Personel
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }

    }
}
