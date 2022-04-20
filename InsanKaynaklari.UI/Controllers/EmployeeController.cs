using InsanKaynaklari.UI.API;
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
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            string json = new WebClient().DownloadString("https://api.ubilisim.com/resmitatiller/");
            PublicHolidayRoot publicHoliday = JsonConvert.DeserializeObject<PublicHolidayRoot>(json);
            EmployeeMainPageVM emp = new EmployeeMainPageVM
            {
                PublicHoliday = publicHoliday
            };
            return View(emp);
        }
    }
}
