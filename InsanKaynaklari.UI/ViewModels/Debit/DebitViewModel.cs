using System;
using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.UI.ViewModels.Debit
{
    public class DebitViewModel
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
        public bool IsCorfirmed { get; set; }

    }
}
