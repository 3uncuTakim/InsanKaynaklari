using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class ExpenseType :BaseEntity       
    {
        public string ExpenseTypeName { get; set; }
        //Relational  Properties Begin
        //one to one with Expense
        public virtual List<Expense> Expenses { get; set; }

    }
}
