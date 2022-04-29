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
            return View(personelLeave);
        }

    }
}