using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Debit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class DebitController : Controller
    {
        private readonly DatabaseContext _context;

        public DebitController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var debit = (from deb in _context.Debits
                         where deb.PersonelID == Convert.ToInt32(id)
                         select new DebitViewModel
                         {
                             DebitName=deb.DebitName,
                             DebitCode=deb.DebitCode,
                             DateOfIssue=deb.DateOfIssue,
                             Description=deb.Description,
                             DateOfReturn=deb.DateOfReturn
                         }
                         ).ToList();
           
           
            return View(debit);
            //izinlerdekinin aynısı webgrid kulllanılacak (sb admin-2)
            //Onay butonu olacak (edit işlemi sadece confirm status ü değiştirecek)!sadece bir kere editleyebilecek
            //İtiraz butonu olacak(e-mail (form şeklinde))
        }
    }
}
