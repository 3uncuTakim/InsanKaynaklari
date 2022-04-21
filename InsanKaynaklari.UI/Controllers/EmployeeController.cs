using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.API;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Employee;
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

        public IActionResult Index()
        {
            string json = new WebClient().DownloadString("https://api.ubilisim.com/resmitatiller/");
            PublicHolidayRoot publicHoliday = JsonConvert.DeserializeObject<PublicHolidayRoot>(json);
            var upcomingHoliday = publicHoliday.resmitatiller.Take(5).ToList();
            //var list = _context.PersonelDetails.

            EmployeeMainPageVM emp = new EmployeeMainPageVM
            {
                PublicHoliday = upcomingHoliday,
                //PersonelDetails = list
                
            };
            return View(emp);
        }
    }
}
