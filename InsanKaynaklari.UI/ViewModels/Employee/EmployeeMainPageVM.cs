using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Employee
{
    public class EmployeeMainPageVM
    {
        public List<Resmitatiller> PublicHoliday { get; set; }
        public  List<BirthDays>BirthDays { get; set; }
        public List<Leavelist> Leaves { get; set; }

    }
    public class BirthDays
    {
        public DateTime Birthday { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    
    public class Leavelist
    {
        public string LeaveTypeName { get; set; }
        public int LeaveDuration { get; set; }
        public DateTime LeaveStartDate { get; set; }
    }
}
