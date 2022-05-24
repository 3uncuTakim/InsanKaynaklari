using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Http;
using InsanKaynaklari.UI.ViewModels.Expenses;
using Microsoft.AspNetCore.Hosting;
using InsanKaynaklari.UI.Managers;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    [NewAuthorization(Role = "Employee")]
    public class ExpensesController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExpensesController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes.OrderBy(x => x.ExpenseTypeName), "ID", "ExpenseTypeName");
            var databaseContext = _context.Expenses.Include(e => e.ExpenseType).Include(e => e.Personel);
            var vm = new IndexViewModel()
            {
                Expenses = await databaseContext.ToListAsync()
            };
            return View(vm);
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Personel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Create(string Id)
        {
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes.OrderBy(x => x.ExpenseTypeName), "ID", "ExpenseTypeName");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IndexViewModel expense)
        {
            if (ModelState.IsValid)
            {
                var newexpense = new Expense
                {
                    CheckDocument = expense.CheckDocument.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment),
                    ConfirmStatus = Entities.Enums.ConfirmStatus.OnHold,
                    PersonelID = Convert.ToInt32(HttpContext.Session.GetString("userId")),
                    ExpenseTypeID = expense.ExpenseTypeID,
                    Amount = expense.Amount,
                    DateOfExpense = expense.DateOfExpense,
                    Explanation = expense.Explanation,
                };
                _context.Add(newexpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }



            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ExpenseTypeName", expense.ExpenseTypeID);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            ExpenseEditVM editVM = new()
            {
                ID = expense.ID,
                Amount = expense.Amount,
                CheckDocumentName = expense.CheckDocument,
                DateOfExpense = expense.DateOfExpense,
                ExpenseTypeID = expense.ExpenseTypeID,
                Explanation = expense.Explanation,

            };
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ExpenseTypeName", expense.ExpenseTypeID);

            return View(editVM);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpenseEditVM editVM)
        {
            var newExpense = await _context.Expenses.FindAsync(id);
            if (id != editVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                newExpense.Amount = editVM.Amount;
                newExpense.DateOfExpense = editVM.DateOfExpense;
                newExpense.ExpenseTypeID = editVM.ExpenseTypeID;
                newExpense.Explanation = editVM.Explanation;

                if (editVM.CheckDocument is not null)
                {
                    newExpense.CheckDocument = editVM.CheckDocument.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment);
                    FileManager.RemoveImageFromDisk(editVM.CheckDocumentName, _webHostEnvironment);
                }
                _context.SaveChanges();
                TempData["message"] = "Harcama Güncellendi";
                return RedirectToAction("Index", "Expenses", new { Id = HttpContext.Session.GetString("userId") });


            }

            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ExpenseTypeName");


            return View(editVM);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deleted = _context.Expenses.FirstOrDefault(x => x.ID == id);
            
            if (deleted == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(deleted);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Expenses", new { Id = HttpContext.Session.GetString("userId") });
        }
            

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ID == id);
        }

    }
}
