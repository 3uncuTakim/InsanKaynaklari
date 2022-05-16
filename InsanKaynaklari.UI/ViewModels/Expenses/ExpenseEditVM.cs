using Microsoft.AspNetCore.Http;
using System;

namespace InsanKaynaklari.UI.ViewModels.Expenses
{
    public class ExpenseEditVM
    {
        public int ID { get; set; }
        public IFormFile CheckDocument { get; set; }
        public DateTime DateOfExpense { get; set; }
        public int Amount { get; set; }
        public string Explanation { get; set; }
        public int ExpenseTypeID { get; set; }
        public string CheckDocumentName { get; set; }

        public string GetCheckDocumentName()
        {
            if (string.IsNullOrEmpty(CheckDocumentName))
            {
                return default;
            }
            else
            {
                return CheckDocumentName.Substring(CheckDocumentName.IndexOf("_") + 1);
            }
        }
    }
}
