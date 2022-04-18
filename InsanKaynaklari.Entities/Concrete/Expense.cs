using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    class Expense: BaseEntity
    {
        //Harcamalar
        public int ExpenseID { get; set; }
        public int ID { get; set; }
        public string CheckDocument  { get; set; }
        public int ExpenseTypeID { get; set; }
        public int Amount { get; set; }
        public string Explanation { get; set; }
        public bool AcceptanceStatus { get; set; }


    }
}
