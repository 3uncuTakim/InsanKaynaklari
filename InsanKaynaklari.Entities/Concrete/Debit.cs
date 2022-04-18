using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    class Debit
    {
        //Zimmet
        [Key]
        public int DebitID { get; set; }
        public string DebitName { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string Explanation { get; set; }
    }
}
