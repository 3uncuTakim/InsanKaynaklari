using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.API;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]

    public class EmployeeController : Controller
    {
        private readonly DatabaseContext _context;
        

        public EmployeeController(DatabaseContext context)
        {
            _context = context;
            
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            
            string json = new WebClient().DownloadString("https://api.ubilisim.com/resmitatiller/");
            PublicHolidayRoot publicHoliday = JsonConvert.DeserializeObject<PublicHolidayRoot>(json);
            var upcomingHoliday = publicHoliday.resmitatiller.Take(5).ToList();
            var now = DateTime.Now;
            var birthday =  (from c in _context.Companies
                            join p in _context.Personels on c.ID equals p.CompanyID
                            join pd in _context.PersonelDetails on p.ID equals pd.ID
                            where c.CompanyName == HttpContext.Session.GetString("usercompany")
                            orderby pd.Birthday
                            select new BirthDays { Firstname = pd.FirstName, Lastname = pd.LastName, Birthday = pd.Birthday }).ToList();
            var orderBirthday = (from dt in birthday
                               orderby BirthdayControl.IsBeforeNow(now, dt.Birthday), dt.Birthday.Month, dt.Birthday.Day
                               select dt).Take(5).ToList();
            EmployeeMainPageVM emp = new EmployeeMainPageVM
            {
                PublicHoliday = upcomingHoliday,
                BirthDays=orderBirthday
                
            };
            return View(emp);
        }
    }
}
