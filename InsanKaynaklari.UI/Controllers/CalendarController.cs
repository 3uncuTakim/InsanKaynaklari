using BlogProject.Filters;
using InsanKaynaklari.DataAccess.Context;
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
