using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Settings
{
    public class EmployeeProfileVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }       
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string WorkStyle { get; set; }
        public DateTime StartDate { get; set; }
        
    }
}
