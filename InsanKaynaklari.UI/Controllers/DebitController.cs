using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    public class DebitController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //izinlerdekinin aynısı webgrid kulllanılacak (sb admin-2)
            //Onay butonu olacak (edit işlemi sadece confirm status ü değiştirecek)!sadece bir kere editleyebilecek
            //İtiraz butonu olacak(e-mail (form şeklinde))
        }
    }
}
