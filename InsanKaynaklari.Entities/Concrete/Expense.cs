using InsanKaynaklari.Entities.Abstract;
using InsanKaynaklari.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Expense: BaseEntity
    {
        public string CheckDocument  { get; set; }        
        public int Amount { get; set; }
        public string Explanation { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }

        //Relational  Properties Begin

        //one to many with ExpenseType
        public int ExpenseTypeID { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
        //One to many with personel
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }


    }
}
