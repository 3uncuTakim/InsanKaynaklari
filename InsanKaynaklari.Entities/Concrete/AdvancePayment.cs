using InsanKaynaklari.Entities.Abstract;
using InsanKaynaklari.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class AdvancePayment:BaseEntity
    {
             
        public decimal Amount { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Description { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        //Relational  Properties Begin
        //one to many with Personel
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }




    }
}
