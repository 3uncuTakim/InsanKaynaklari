using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.Controllers
{
    [LoggedUser]
    public class ShiftController : Controller
    {
        private readonly DatabaseContext _context;

        public ShiftController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Shifts.ToList());
        }
    }
}
