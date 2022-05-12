using System.Collections.Generic;
using InsanKaynaklari.Entities.Concrete;

namespace InsanKaynaklari.UI.ViewModels.Expenses
{
    public class IndexViewModel
    {
        public List<Expense> Expenses { get; set; }

        public Expense Expense { get; set; } = new Expense();
    }
}
