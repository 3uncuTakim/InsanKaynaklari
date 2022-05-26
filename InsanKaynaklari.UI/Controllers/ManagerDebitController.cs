using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.ManagerDebit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    [NewAuthorization(Role = "Manager")]
    public class ManagerDebitController : Controller
    {
        private readonly DatabaseContext _context;

        public ManagerDebitController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var debit = (from deb in _context.Debits
                         join p in _context.Personels on deb.PersonelID equals p.ID
                         where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))
                         select new ManagerDebitMainPageVM
                         {
                             DebitName = deb.DebitName,
                             DebitCode = deb.DebitCode,
                             DateOfIssue = deb.DateOfIssue,
                             Description = deb.Description,
                             DateOfReturn = deb.DateOfReturn,
                             IsConfirmed = deb.IsCorfirmed,
                             ID = deb.ID,
                             FirstName=p.PersonelDetail.FirstName,
                             LastName=p.PersonelDetail.LastName
                            
                         }
                        ).ToList();
            return View(debit);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult CreateDebit(string id)
        {
            IQueryable list = (from pd in _context.PersonelDetails
                               join p in _context.Personels on pd.ID equals p.ID
                               where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))
                               orderby pd.FirstName, pd.LastName
                               select new GetFullName { ID = pd.ID,FullName=$"{pd.FirstName} {pd.LastName}" });             
            ViewData["PersonelList"] = new SelectList(list, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateDebit(ManagerDebitCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var debit = new Debit
                {
                    DebitName=model.DebitName,
                    DateOfIssue=model.DateOfIssue,
                    DebitCode=model.DebitCode,
                    Description=model.Description,
                    IsCorfirmed=false,
                    PersonelID=model.PersonelID
                };
                _context.Debits.Add(debit);
                _context.SaveChanges();
                return RedirectToAction("Index", "ManagerDebit", new { Id = HttpContext.Session.GetString("userId") });
            }
            return View(model);
        }
        public IActionResult ReturnDebit(int id)
        {
            var debit = _context.Debits.Find(id);
            debit.DateOfReturn = DateTime.Today;
            _context.SaveChanges();
            return RedirectToAction("Index", "ManagerDebit", new { Id = HttpContext.Session.GetString("userId") });
        }
    }
}
