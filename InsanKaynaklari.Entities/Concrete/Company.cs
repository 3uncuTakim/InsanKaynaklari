using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Company:BaseEntity
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public bool Activation { get; set; }

    }
}
