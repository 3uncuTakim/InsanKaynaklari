using Microsoft.AspNetCore.Mvc;

namespace InsanKaynaklari.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
