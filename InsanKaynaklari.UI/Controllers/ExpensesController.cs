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

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class ExpensesController : Controller
    {
        private readonly DatabaseContext _context;
        
        public ExpensesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes.OrderBy(x => x.ExpenseTypeName), "ID", "ExpenseTypeName");
            var databaseContext = _context.Expenses.Include(e => e.ExpenseType).Include(e => e.Personel);
            var vm = new IndexViewModel() { 
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
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes.OrderBy(x=>x.ExpenseTypeName), "ID", "ExpenseTypeName");          
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckDocument,Amount,Explanation,ExpenseTypeID")] Expense expense)
        {
            if (ModelState.IsValid)
            {               
                expense.ConfirmStatus = Entities.Enums.ConfirmStatus.OnHold;
                expense.PersonelID = Convert.ToInt32(HttpContext.Session.GetString("userId"));
                _context.Add(expense);
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
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ExpenseTypeName", expense.ExpenseTypeID);
            ViewData["PersonelID"] = new SelectList(_context.Personels, "ID", "Email", expense.PersonelID);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckDocument,Amount,Explanation,ConfirmStatus,ExpenseTypeID,PersonelID,ID")] Expense expense)
        {
            if (id != expense.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ExpenseTypeName", expense.ExpenseTypeID);
            ViewData["PersonelID"] = new SelectList(_context.Personels, "ID", "Email", expense.PersonelID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ID == id);
        }
       
    }
}
