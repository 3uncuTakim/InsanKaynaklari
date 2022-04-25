using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Auth.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly DatabaseContext _context;


        public SettingsController(DatabaseContext context)
        {
            _context = context;
        }
        [LoggedUser]
        public IActionResult Settings(SettingsViewModel settings)
        {

            if (ModelState.IsValid)
            {
                var user = _context.PersonelDetails.FirstOrDefault(p=>p.ID.Equals(settings.Id) &&
                    p.ID.ToString().Equals(HttpContext.Session.GetString("userId")));
                user.Personel.Email

            }
            return View();
        }
    }
}
