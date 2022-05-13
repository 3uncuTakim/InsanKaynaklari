using System;
using System.Collections.Generic;
using InsanKaynaklari.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace InsanKaynaklari.UI.ViewModels.Expenses
{
    public class IndexViewModel
    {
        public List<Expense> Expenses { get; set; }
        public DateTime DateOfExpense { get; set; }
        public int Amount { get; set; }
        public string Explanation { get; set; }
        public int ExpenseTypeID { get; set; }
        public IFormFile CheckDocument { get; set; }
    }
}
