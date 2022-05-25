using InsanKaynaklari.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Manager
{
    public class EmployeeCreateVM
    {
        public string Email { get; set; }
        public bool Activation { get; set; }
        public string Password { get; set; }
        public UserStatus Role { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
        public decimal Wage { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string WorkStyle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
