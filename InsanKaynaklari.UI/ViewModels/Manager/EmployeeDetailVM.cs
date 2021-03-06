using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Manager
{
    public class EmployeeDetailVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public decimal Wage { get; set; }
        public string Picture { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string WorkStyle { get; set; }
        public DateTime StartDate { get; set; }
        public bool Activation { get; set; }
    }
}
