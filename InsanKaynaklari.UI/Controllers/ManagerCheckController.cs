using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.ViewModels.ManagerCheck;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [NewAuthorization(Role = "Manager")]
    [LoggedUser]
    public class ManagerCheckController : Controller
    {
        private readonly DatabaseContext _context;

        public ManagerCheckController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var leaves = (from lt in _context.LeaveTypes
                        join l in _context.Leaves on lt.ID equals l.LeaveTypeID
                        join p in _context.Personels on l.PersonelID equals p.ID
                        join pd in _context.PersonelDetails on p.ID equals pd.ID
                        where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId")) && l.ConfirmStatus==Entities.Enums.ConfirmStatus.OnHold
                        select new ManagerLeaveList
                        {
                            ID = l.ID,
                            FirstName=pd.FirstName,
                            LastName=pd.LastName,
                            Description = l.Description,
                            LeaveTypeName = lt.TypeName,
                            TotalDaysOff = l.TotalDaysOff,
                            StartLeaveDate = l.StartLeaveDate,
                            EndLeaveDate = l.EndLeaveDate,
                            ConfirmStatus = l.ConfirmStatus,
                            LeaveDocument=l.LeaveDocument

                        }).ToList();
            var expenses = (from et in _context.ExpenseTypes
                        join e in _context.Expenses on et.ID equals e.ExpenseTypeID
                        join p in _context.Personels on e.PersonelID equals p.ID
                        join pd in _context.PersonelDetails on p.ID equals pd.ID
                        where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId")) && e.ConfirmStatus == Entities.Enums.ConfirmStatus.OnHold
                        select new ManagerExpenseList
                        {
                            ID = e.ID,
                            Amount = e.Amount,
                            FirstName = pd.FirstName,
                            LastName = pd.LastName,
                            CheckDocument =e.CheckDocument,
                            ConfirmStatus=e.ConfirmStatus,
                            DateOfExpense=e.DateOfExpense,
                            ExpenseTypeName=et.ExpenseTypeName,
                            Explanation=e.Explanation
                        }).ToList();
            var checkList = new ManagerCheckMainPageVM
            {
                Expenses = expenses,
                Leaves = leaves
            };
            return View(checkList);
        }
        public IActionResult AcceptLeave(int id)
        {
            var leave = _context.Leaves.Find(id);
            leave.ConfirmStatus = Entities.Enums.ConfirmStatus.Accepted;
            _context.SaveChanges();
            return RedirectToAction("Index", "ManagerCheck", new { Id = HttpContext.Session.GetString("userId") });
        }
        public IActionResult RejectLeave(int id)
        {
            var leave = _context.Leaves.Find(id);
            leave.ConfirmStatus = Entities.Enums.ConfirmStatus.Rejected;
            _context.SaveChanges();
            return RedirectToAction("Index", "ManagerCheck", new { Id = HttpContext.Session.GetString("userId") });
        }
        public IActionResult AcceptExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            expense.ConfirmStatus = Entities.Enums.ConfirmStatus.Accepted;
            _context.SaveChanges();
            return RedirectToAction("Index", "ManagerCheck", new { Id = HttpContext.Session.GetString("userId") });
        }
        public IActionResult RejectExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            expense.ConfirmStatus = Entities.Enums.ConfirmStatus.Rejected;
            _context.SaveChanges();
            return RedirectToAction("Index", "ManagerCheck", new { Id = HttpContext.Session.GetString("userId") });
        }
    }
}
