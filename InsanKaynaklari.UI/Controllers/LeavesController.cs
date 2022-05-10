using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.Managers;
using InsanKaynaklari.UI.ViewModels.Leaves;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class LeavesController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LeavesController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var lmp = (from lt in _context.LeaveTypes
                       join l in _context.Leaves on lt.ID equals l.LeaveTypeID
                       where l.PersonelID == Convert.ToInt32(id)
                       select new LeaveMainPageVM
                       {
                           Description = l.Description,
                           LeaveTypeName = lt.TypeName,
                           TotalDaysOff = l.TotalDaysOff,
                           StartLeaveDate = l.StartLeaveDate,
                           EndLeaveDate = l.EndLeaveDate,
                           ConfirmStatus=l.ConfirmStatus
                           
                       }).ToList();

            return View(lmp);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Create(string id)
        {
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes.OrderByDescending(x => x.TypeName), "ID", "TypeName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveCreateVM model,string yonlen) 
        {
            if (ModelState.IsValid)
            {
                var leave = new Leave
                {
                    LeaveDocument = model.LeaveDocument.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment),
                    Description = model.Description,
                    ConfirmStatus = Entities.Enums.ConfirmStatus.OnHold,
                    LeaveTypeID = model.LeaveTypeID,
                    StartLeaveDate = model.StartLeaveDate,
                    EndLeaveDate = model.EndLeaveDate,
                    PersonelID = int.Parse(HttpContext.Session.GetString("userId")),
                    TotalDaysOff = Convert.ToInt32(GetBusinessDay.GetBusinessDays(model.StartLeaveDate, model.EndLeaveDate))
                };
                _context.Leaves.Add(leave);
                _context.SaveChanges();
                return RedirectToAction("Index", "Leaves", new { Id = HttpContext.Session.GetString("userId") });
            }
            else
            {
                return View(model);
            }
        }
    }
}