using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.UI.ViewModels.Debit
{
    public class DebitViewModel
    {
        public string Cancelation { get; set; }
        public List<DebitList> DebitList { get; set; }

    }
    public class DebitList
    {
        public int ID { get; set; }
        public string DebitName { get; set; }     
        public string DebitCode { get; set; }      
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }        
        public string Description { get; set; }        
        public bool IsConfirmed { get; set; }
        
    }
}
