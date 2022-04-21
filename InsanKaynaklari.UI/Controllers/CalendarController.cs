using BlogProject.Filters;
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
    }
}
