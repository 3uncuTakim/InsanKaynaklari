using InsanKaynaklari.UI.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    public class LoginController : Controller
    {
       

        public LoginController()
        {

        }
        [HttpGet]
        public IActionResult LogIn(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInViewModel model, string yonlen)
        {
            /*if (!ModelState.IsValid)*/ return View();
            


        }
    }
}
