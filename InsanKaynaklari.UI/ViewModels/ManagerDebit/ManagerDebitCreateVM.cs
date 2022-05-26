using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.ManagerDebit
{
    public class ManagerDebitCreateVM
    {
        public string DebitName { get; set; }
        public string DebitCode { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Description { get; set; }     
        public int PersonelID { get; set; }
    }
    public class GetFullName
    {
        public int ID { get; set; }
        public string FullName { get; set; }
    }
}
