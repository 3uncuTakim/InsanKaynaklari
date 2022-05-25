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
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            return View();
        }

        //Güzel bir Takım
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult GetAllEvent(string id)
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
            List<Event> allEvent = (from e in _context.Events
                       join pe in _context.PersonelEvents on e.ID equals pe.EventID
                       join p in _context.Personels on pe.PersonelID equals p.ID
                       where pe.PersonelID == Convert.ToInt32(id)
                       select new Event { ID = e.ID, Start = e.Start, Color = e.Color, End = e.End, TextColor = e.TextColor, Title = e.Title }).ToList();
            //var allEvent = _context.Events.ToList();
            allEvent.AddRange(events);
            return new JsonResult(allEvent);
        }
    }
}
