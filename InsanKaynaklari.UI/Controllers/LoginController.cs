using InsanKaynaklari.UI.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Business.Mailing;

namespace InsanKaynaklari.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMailService _mailService;

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
