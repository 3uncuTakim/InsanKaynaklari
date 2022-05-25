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
    [NewAuthorization(Role = "Employee")]
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
                           ID=l.ID,
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
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes.OrderBy(x => x.TypeName), "ID", "TypeName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveCreateVM model) 
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
        public IActionResult Details(int id)
        {
            var leave = (from lt in _context.LeaveTypes
                         join l in _context.Leaves on lt.ID equals l.LeaveTypeID
                         where l.ID == id
                         select new LeaveDetailsVM
                         {
                             Description = l.Description,
                             StartLeaveDate = l.StartLeaveDate,
                             EndLeaveDate = l.EndLeaveDate,
                             LeaveTypeName = lt.TypeName,
                             ConfirmStatus = l.ConfirmStatus,
                             LeaveDocument = l.LeaveDocument,
                             TotalDaysOff = l.TotalDaysOff
                         }).FirstOrDefault();
            return View(leave);
        }
        public IActionResult Edit(int id)
        {
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes.OrderBy(x => x.TypeName), "ID", "TypeName");
            var editLeave = _context.Leaves.Find(id);
            if (editLeave is not null)
            {
                LeaveEditVM editVM = new()
                {
                    ID = editLeave.ID,
                    Description = editLeave.Description,
                    StartLeaveDate = editLeave.StartLeaveDate,
                    EndLeaveDate = editLeave.EndLeaveDate,
                    LeaveDocumentName=editLeave.LeaveDocument,
                    LeaveTypeID=editLeave.LeaveTypeID
                };
                return View(editVM);
            }
            else
            {
                TempData["error"] = "İzin bulunamadı";
                return RedirectToAction("Index", "Leaves", new { Id = HttpContext.Session.GetString("userId") });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(LeaveEditVM leave)
        {
            var newLeave = _context.Leaves.FirstOrDefault(x => x.ID.Equals(leave.ID));
            if (newLeave is null)
            {
                ViewData["error"] = "Edit fail";
                ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes.OrderBy(x => x.TypeName), "ID", "TypeName");
                return View(leave);
            }
            if (ModelState.IsValid)
            {
                newLeave.LeaveTypeID = leave.LeaveTypeID;
                newLeave.Description = leave.Description;
                newLeave.StartLeaveDate = leave.StartLeaveDate;
                newLeave.EndLeaveDate = leave.EndLeaveDate;
                newLeave.TotalDaysOff = Convert.ToInt32(GetBusinessDay.GetBusinessDays(leave.StartLeaveDate, leave.EndLeaveDate));
                if (leave.LeaveDocument is not null)
                {
                    newLeave.LeaveDocument = leave.LeaveDocument.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment);
                    FileManager.RemoveImageFromDisk(leave.LeaveDocumentName, _webHostEnvironment);
                }
                _context.SaveChanges();
                TempData["message"] = "İzin Güncellendi";
                return RedirectToAction("Index", "Leaves", new { Id = HttpContext.Session.GetString("userId") });
            }
            else
            {
                return View(leave);
            }
            

        }
        public IActionResult Delete(int id)
        {
            var deleted = _context.Leaves.FirstOrDefault(x => x.ID == id);
            if (deleted.ConfirmStatus==Entities.Enums.ConfirmStatus.OnHold)
            {
                _context.Leaves.Remove(deleted);
                _context.SaveChanges();
                return RedirectToAction("Index", "Leaves", new { Id = HttpContext.Session.GetString("userId") });
            }
            else 
            {
                //yöneticye email yollayacak izin iptali için (her işlem icin bir kere)
                TempData["message"] = $"{deleted.StartLeaveDate.ToString("dd MMMM")}tarihinde başlayan {deleted.ID} nolu iznin iptal talebi iletilmiştir.";
                return RedirectToAction("Index", "Leaves", new { Id = HttpContext.Session.GetString("userId") });
            }
            
        }
    }
}