using Microsoft.AspNetCore.Mvc;

namespace InsanKaynaklari.UI.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
