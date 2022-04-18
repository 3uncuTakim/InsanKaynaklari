using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    class AdvancePayment:BaseEntity
    {
        //Avans
        [Key]
        public int AvansID { get; set; }
        public int PersonelID { get; set; }
        public int Amount { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Explanation { get; set; }
        public bool Status { get; set; }




    }
}
