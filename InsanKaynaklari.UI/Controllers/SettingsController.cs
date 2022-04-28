using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class SettingsController : Controller
    {
        private readonly DatabaseContext _context;


        public SettingsController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Profile(string id)
        {
            var profile = _context.PersonelDetails.Where(x => x.ID == Convert.ToInt32(id)).Select(x => new EmployeeProfileVM
            {
                ID=x.ID,
                Email=x.Personel.Email,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Birthday=x.Birthday,
                Address=x.Address,
                Department=x.Department,
                StartDate=x.StartDate,
                Title=x.Title,
                WorkStyle=x.WorkStyle,
                Picture= string.IsNullOrEmpty(x.Picture) ? "null.png" : x.Picture
            }).FirstOrDefault();
            
            return View(profile);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult ChangePassword(string id)
        {
            var personelPassword = _context.Personels.Where(x => x.ID == Convert.ToInt32(id)).Select(x => new ChangePasswordVM
            {
                ID = x.ID,
                Password = x.Password
            }).FirstOrDefault();
            return View(personelPassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM change)
        {
            if (ModelState.IsValid)
            {
                if (change.Password == change.PasswordControl)
                {
                    var oldPassword = _context.Personels.FirstOrDefault(x => x.ID.ToString().Equals(HttpContext.Session.GetString("userId")));
                    oldPassword.Password = change.Password;
                    _context.SaveChanges();
                    return RedirectToAction("Profile", "Settings", new { Id = HttpContext.Session.GetString("userId") });
                }
                else
                {
                    return View(change);
                }
                
            }
            return View();
        }
    }
}
