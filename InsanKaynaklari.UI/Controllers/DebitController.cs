using InsanKaynaklari.Business.Mailing;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Debit;
using Microsoft.AspNetCore.Http;
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
        private readonly IMailService _mailService;

        public DebitController(DatabaseContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var debit = (from deb in _context.Debits
                         where deb.PersonelID == Convert.ToInt32(id)
                         select new DebitList
                         {
                             DebitName = deb.DebitName,
                             DebitCode = deb.DebitCode,
                             DateOfIssue = deb.DateOfIssue,
                             Description = deb.Description,
                             DateOfReturn = deb.DateOfReturn,
                             IsConfirmed = deb.IsCorfirmed,
                             ID = deb.ID
                         }
                         ).ToList();

            var newDebit = new DebitViewModel
            {
                DebitList = debit
            };
            return View(newDebit);
            //izinlerdekinin aynısı webgrid kulllanılacak (sb admin-2)
            //Onay butonu olacak (edit işlemi sadece confirm status ü değiştirecek)!sadece bir kere editleyebilecek
            //İtiraz butonu olacak(e-mail (form şeklinde))
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Cancel(int id, DebitViewModel model)
        {
            var debit = _context.Debits.FirstOrDefault(x => x.ID == id);
            var sMail = _context.Personels.Where(x => x.ID.Equals(debit.PersonelID)).Select(x => x.Email).ToString();
            if (debit.IsCorfirmed)
            {
                debit.IsCorfirmed = false;
                _context.SaveChanges();

                _mailService.SendEmail(new MailTemplate(sMail, "Zimmet iptali",model.Cancelation,"yonetici@ik.com"));
                TempData["message"] = "Zimmet iptal edildi";

                return RedirectToAction("Index", "Debit", new { Id = HttpContext.Session.GetString("userId") });
            }
            return View();
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Accept(int id)
        {
            var debit = _context.Debits.FirstOrDefault(x => x.ID == id);
            if (debit.IsCorfirmed != true)
            {
                debit.IsCorfirmed = true;
                TempData["message"] = "Zimmet onaylandı";
                _context.SaveChanges();
                return RedirectToAction("Index", "Debit", new { Id = HttpContext.Session.GetString("userId") });
            }
            return View();
        }
    }
}
