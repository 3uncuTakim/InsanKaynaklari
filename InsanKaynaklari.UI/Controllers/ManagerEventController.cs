using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.ManagerDebit;
using InsanKaynaklari.UI.ViewModels.ManagerEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [NewAuthorization(Role = "Manager")]
    [LoggedUser]
    public class ManagerEventController : Controller
    {
        private readonly DatabaseContext _context;

        public ManagerEventController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult CreateEvent(string id)
        {
            IQueryable list = (from pd in _context.PersonelDetails
                               join p in _context.Personels on pd.ID equals p.ID
                               where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))
                               orderby pd.FirstName, pd.LastName
                               select new GetFullName { ID = pd.ID, FullName = $"{pd.FirstName} {pd.LastName}" });
            ViewData["PersonelList"] = new SelectList(list, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateEvent(ManagerEventMainPageVM model)
        {
            if (ModelState.IsValid)
            {
                List<PersonelEvent> personelEvents = new List<PersonelEvent>();
                var newEvent = new Event
                {
                    Color = model.Color,
                    TextColor = model.TextColor,
                    Title = model.Title,
                    Start = model.Start,
                    End = model.End
                };
                _context.Events.Add(newEvent);
                _context.SaveChanges();
                int id = Convert.ToInt32(_context.Events.Where(x => x.Title == model.Title && x.Start == model.Start && x.End == model.End).Select(x=>x.ID).FirstOrDefault());
                var assignedList = model.AssignedEmployees.ToList();            
                foreach (var item in assignedList)
                { 
                    var attendes = new PersonelEvent
                    {
                        EventID = id,
                        PersonelID = item
                    };
                    personelEvents.Add(attendes);
                }
                foreach (var item in personelEvents)
                {
                    _context.PersonelEvents.Add(item);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Manager", new { Id = HttpContext.Session.GetString("userId") });
            }
            else
            {
                return View();
            }
            


        }
    }
}
        