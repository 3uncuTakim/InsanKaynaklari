using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.UI.ViewModels.Debit
{
    public class DebitViewModel
    {
        [Required]
        public string Cancelation { get; set; }
        public List<DebitList> DebitList { get; set; }

    }
    public class DebitList
    {

        [Required]
        public string DebitName { get; set; }
        [Required]
        public string DebitCode { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        public int ID { get; set; }
    }
}
