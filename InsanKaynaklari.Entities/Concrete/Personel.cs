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
        public string Password { get; set; }
        public UserStatus Role { get; set; }

        //Relational  Properties Begin
        //one to one with Personel Details
        public virtual PersonelDetail PersonelDetail { get; set; }
        //one to many  (many side)
        public virtual List<Leave> Leaves { get; set; }
        public virtual List<Debit> Debits { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Shift> Shifts { get; set; }

        //one to many(one side)
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<PersonelEvent> PersonelEvents { get; set; }





    }
}
