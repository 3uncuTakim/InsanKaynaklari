using InsanKaynaklari.UI.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Business.Mailing;
using Microsoft.AspNetCore.Http;

namespace InsanKaynaklari.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMailService _mailService;

        public LoginController(DatabaseContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
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
            if (ModelState.IsValid)
            {
                var user = _context.Personels.FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
                if (user is not null)
                {
                    var name = _context.PersonelDetails.Where(x => x.ID == user.ID).FirstOrDefault();
                    var company = _context.Companies.Where(x => x.ID == user.CompanyID).FirstOrDefault();
                    HttpContext.Session.SetString("userId", user.ID.ToString());
                    HttpContext.Session.SetString("username", name.FirstName.ToString());
                    HttpContext.Session.SetString("usercompany", company.CompanyName.ToString());
                    return RedirectToAction("Index", "Employee");
                }
            }
            else
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");
            }
            return View();
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("companyname");
            return RedirectToAction("Index", "Home");
        }
    }
}
