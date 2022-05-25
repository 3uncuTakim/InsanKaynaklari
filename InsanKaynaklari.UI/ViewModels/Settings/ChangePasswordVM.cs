using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Settings
{
    public class ChangePasswordVM
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string PasswordControl { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordControl { get; set; }
    }
}
