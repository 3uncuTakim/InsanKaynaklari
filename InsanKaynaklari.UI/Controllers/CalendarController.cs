using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Mvc;
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
            var Event = _context.Events.ToList();
            return new JsonResult(Event);
        }
    }
}
