using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Employee
{
    public class BirthdayControl 
    {
        public static bool IsBeforeNow(DateTime now ,DateTime dateTime)
        {
            return dateTime.Month < now.Month || (dateTime.Month == now.Month && dateTime.Day < now.Day);
        }
    }
}
