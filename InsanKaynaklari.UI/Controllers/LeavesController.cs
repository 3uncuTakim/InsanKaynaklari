using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.Leaves;
using Microsoft.AspNetCore.Mvc;
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

        public LeavesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var personelLeave = _context.Leaves.Where(x => x.PersonelID == Convert.ToInt32(id)).ToList();
            LeaveMainPageVM lmp = new LeaveMainPageVM
            {
                Leaves = personelLeave
            };
            return View(lmp);
        }
        public IActionResult Create(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }
        [HttpPost]
        public IActionResult Create(LeaveCreateVM model,string yonlen) 
        { 
            var leave = new Leave
            {
                Description=model.Description,
                ConfirmStatus=Entities.Enums.ConfirmStatus.OnHold,
                LeaveTypeID=model.LeaveTypeID,
                StartLeaveDate=model.StartLeaveDate,
                EndLeaveDate=model.EndLeaveDate,
            }
        }
    }
}