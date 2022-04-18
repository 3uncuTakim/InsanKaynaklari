using InsanKaynaklari.Entities.Abstract;
using InsanKaynaklari.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    
    public class Personel : BaseEntity
    {
        public string Email { get; set; }
        public bool Activation { get; set; }
        public string Password  { get; set; }
        public UserStatus Role { get; set; }

        //Relational  Properties Begin
        //one to one with Personel Details
        public virtual PersonelDetail PersonelDetail { get; set; }
        //one to many  (many side)
        public virtual AdvancePayment AdvancePayment { get; set; }
        public virtual Leave Leave { get; set; }
        public virtual Debit Debit { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Overtime Overtime { get; set; }

        //one to many(one side)




    }
}
