using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllEvent()
        {
            DatabaseContext db = new DatabaseContext();
        }
    }
}
