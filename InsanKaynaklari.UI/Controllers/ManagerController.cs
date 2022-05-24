using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [NewAuthorization(Role = "Manager")]
    [LoggedUser]
    public class ManagerController : Controller
    {
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            return View();
        }
    }
}
