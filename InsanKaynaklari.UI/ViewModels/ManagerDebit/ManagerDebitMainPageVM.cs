using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.ManagerDebit
{
    public class ManagerDebitMainPageVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DebitName { get; set; }
        public string DebitCode { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
