using InsanKaynaklari.UI.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Manager
{
    public class ManagerMainPageVM
    {
        public int EmployeeCount { get; set; }

        public List<BirthDays> BirthDays { get; set; }
    }
}
