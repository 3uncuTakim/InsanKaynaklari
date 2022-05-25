using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Employee;
using InsanKaynaklari.UI.ViewModels.Manager;
using InsanKaynaklari.UI.ViewModels.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [NewAuthorization(Role = "Manager")]
    [LoggedUser]
    public class ManagerController : Controller
    {
        private readonly DatabaseContext _context;

        public ManagerController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var now = DateTime.Now;
            var birthday = (from c in _context.Companies
                            join p in _context.Personels on c.ID equals p.CompanyID
                            join pd in _context.PersonelDetails on p.ID equals pd.ID
                            where c.CompanyName == HttpContext.Session.GetString("usercompany")
                            select new BirthDays { Firstname = pd.FirstName, Lastname = pd.LastName, Birthday = pd.Birthday }).ToList();
            var orderBirthday = (from dt in birthday
                                 orderby BirthdayControl.IsBeforeNow(DateTime.Now, dt.Birthday), dt.Birthday.Month, dt.Birthday.Day
                                 select dt).Take(5).ToList();
            var empCount = _context.Personels.Where(x => x.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))).Count();
            ManagerMainPageVM main = new ManagerMainPageVM()
            {
                EmployeeCount=empCount,
                BirthDays=orderBirthday
            };
            return View(main);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult EmployeeList(string id)
        {
            var empList = (from p in _context.Personels
                           join pd in _context.PersonelDetails on p.ID equals pd.ID
                           where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))
                           select new EmployeeListVM 
                           { 
                               ID=pd.ID,
                               FirstName = pd.FirstName, 
                               LastName = pd.LastName, 
                               Photo = string.IsNullOrEmpty(pd.Picture) ? "null.png" : pd.Picture
                           }).ToList();
            
            return View(empList);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var profile = _context.PersonelDetails.Where(x => x.ID == id).Select(x => new EmployeeDetailVM
            {
                Activation=x.Personel.Activation,
                ID = x.ID,
                Email = x.Personel.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Birthday = x.Birthday,
                Address = x.Address,
                Department = x.Department,
                StartDate = x.StartDate,
                Title = x.Title,
                WorkStyle = x.WorkStyle,
                Picture = string.IsNullOrEmpty(x.Picture) ? "null.png" : x.Picture
            }).FirstOrDefault();

            return View(profile);

        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult DeactiveEmployee(int id)
        {
            var employee = _context.Personels.FirstOrDefault(x => x.ID == id);
            employee.Activation = false;
            _context.SaveChanges();
            return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });
    
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult ActiveEmployee(int id)
        {
            var employee = _context.Personels.FirstOrDefault(x => x.ID == id);
            employee.Activation = true;
            _context.SaveChanges();
            return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });


        }
    }
}
