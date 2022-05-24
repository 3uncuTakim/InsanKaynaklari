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
                    if (user.Activation!=true)
                    {
                        ModelState.AddModelError("", "Kullanici aktif değildir");
                        return View();
                    }
                    else
                    {
                        var name = _context.PersonelDetails.Where(x => x.ID == user.ID).FirstOrDefault();
                        var userRole = _context.Personels.Where(x => x.ID == user.ID).Select(x => x.Role).FirstOrDefault();
                        var company = _context.Companies.Where(x => x.ID == user.CompanyID).FirstOrDefault();
                        HttpContext.Session.SetString("userId", user.ID.ToString());
                        HttpContext.Session.SetString("username", name.FirstName.ToString());
                        HttpContext.Session.SetString("usercompany", company.CompanyName.ToString());
                        HttpContext.Session.SetString("usercompanyId", company.ID.ToString());
                        HttpContext.Session.SetString("userrole", userRole.ToString());
                        if (userRole == Entities.Enums.UserStatus.Employee)
                        {
                            return RedirectToAction("Index", "Employee", new { Id = HttpContext.Session.GetString("userId") });
                        }
                        else if (userRole == Entities.Enums.UserStatus.Manager)
                        {
                            return RedirectToAction("Index", "Manager", new { Id = HttpContext.Session.GetString("userId") });
                        }                       
                        
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı veya şifre hatalı");
                    return View();
                }
            }
           
            return View();

        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("usercompany");
            HttpContext.Session.Remove("usercompanyId");
            HttpContext.Session.Remove("userrole");
            return RedirectToAction("Index", "Home");
        }
    }
}
