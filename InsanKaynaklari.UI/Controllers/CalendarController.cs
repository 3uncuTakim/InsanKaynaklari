using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.API;
using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class CalendarController : Controller
    {

        private readonly DatabaseContext _context;
        public CalendarController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllEvent()
        {
            List<Resmitatiller> holidays= GetHolidays.GetPublicHoliday().ToList();
            List<Event> events = new List<Event>();
            for (int i = 0; i < holidays.Count; i++)
            {
                Event holidayList = new Event();
                holidayList.Start = DateTime.Parse(holidays[i].tarih);
                holidayList.End = DateTime.Parse(holidays[i].tarih).AddDays(1);
                holidayList.Title = holidays[i].gun;
                holidayList.Color = "#ee2c2c";
                holidayList.TextColor = "# f8f8ff";
                holidayList.ID = 0;
                events.Add(holidayList);

            };
            
            var allEvent = _context.Events.ToList();
            allEvent.AddRange(events);
            return new JsonResult(allEvent);
        }
    }
}
