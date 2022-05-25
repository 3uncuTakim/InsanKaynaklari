using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using InsanKaynaklari.Entities.Enums;
using InsanKaynaklari.UI.Filters;
using InsanKaynaklari.UI.Managers;
using InsanKaynaklari.UI.ViewModels.Employee;
using InsanKaynaklari.UI.ViewModels.Manager;
using InsanKaynaklari.UI.ViewModels.Settings;
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
    [NewAuthorization(Role = "Manager")]
    [LoggedUser]
    public class ManagerController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManagerController(DatabaseContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult Index(string id)
        {
            var now = DateTime.Now;
            var birthday = (from c in _context.Companies
                            join p in _context.Personels on c.ID equals p.CompanyID
                            join pd in _context.PersonelDetails on p.ID equals pd.ID
                            where c.CompanyName == HttpContext.Session.GetString("usercompany")
                            select new BirthDays { Firstname = pd.FirstName, Lastname = pd.LastName, Birthday = pd.Birthday }).ToList();
            var orderBirthday = (from dt in birthday
                                 orderby BirthdayControl.IsBeforeNow(DateTime.Now, dt.Birthday), dt.Birthday.Month, dt.Birthday.Day
                                 select dt).Take(5).ToList();
            var empCount = _context.Personels.Where(x => x.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))).Count();
            ManagerMainPageVM main = new ManagerMainPageVM()
            {
                EmployeeCount=empCount,
                BirthDays=orderBirthday
            };
            return View(main);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult EmployeeList(string id)
        {
            var empList = (from p in _context.Personels
                           join pd in _context.PersonelDetails on p.ID equals pd.ID
                           where p.CompanyID == Convert.ToInt32(HttpContext.Session.GetString("usercompanyId"))
                           orderby pd.FirstName
                           select new EmployeeListVM 
                           { 
                               ID=pd.ID,
                               FirstName = pd.FirstName, 
                               LastName = pd.LastName, 
                               Photo = string.IsNullOrEmpty(pd.Picture) ? "null.png" : pd.Picture
                           }).ToList();
            
            return View(empList);
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var profile = _context.PersonelDetails.Where(x => x.ID == id).Select(x => new EmployeeDetailVM
            {
                Activation=x.Personel.Activation,
                ID = x.ID,
                Email = x.Personel.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Birthday = x.Birthday,
                Address = x.Address,
                Department = x.Department,
                Wage=x.Wage,
                StartDate = x.StartDate,
                Title = x.Title,
                WorkStyle = x.WorkStyle,
                Picture = string.IsNullOrEmpty(x.Picture) ? "null.png" : x.Picture
            }).FirstOrDefault();

            return View(profile);

        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult DeactiveEmployee(int id)
        {
            var employee = _context.Personels.FirstOrDefault(x => x.ID == id);
            employee.Activation = false;
            _context.SaveChanges();
            return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });
    
        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult ActiveEmployee(int id)
        {
            var employee = _context.Personels.FirstOrDefault(x => x.ID == id);
            employee.Activation = true;
            _context.SaveChanges();
            return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });


        }
        [HttpGet("[controller]/[action]/{Id}")]
        public IActionResult CreateEmployee(string id)
        {         
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateVM model)
        {
            Random rnd = new Random();
            if (ModelState.IsValid)
            {
                var personel = new Personel
                {
                    CompanyID = Convert.ToInt32(HttpContext.Session.GetString("usercompanyId")),
                    Activation = true,
                    Email = model.Email,
                    Role = UserStatus.Employee,
                    Password = rnd.Next(100000, 999999).ToString(),                   
                };
                _context.Personels.Add(personel);
                _context.SaveChanges();
                int id = _context.Personels.Where(x => x.Email == personel.Email).Select(x => x.ID).FirstOrDefault();
                var personelDetail = new PersonelDetail
                {
                    ID = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Birthday = model.Birthday,
                    Department = model.Department,
                    Title = model.Title,
                    StartDate = model.StartDate,
                    Wage = model.Wage,
                    WorkStyle = model.WorkStyle,
                    Picture = model.Picture.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment)

                };
                _context.PersonelDetails.Add(personelDetail);
                _context.SaveChanges();
            }
            return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });
        }
        public IActionResult EditEmployee(int id)
        {
            var edit = _context.Personels.Find(id);
            var editDetail = _context.PersonelDetails.Find(id);
            EmployeeEditVM model = new EmployeeEditVM()
            {
                ID = edit.ID,
                Email = edit.Email,
                Address = editDetail.Address,
                Birthday = editDetail.Birthday,
                Department = editDetail.Department,
                FirstName = editDetail.FirstName,
                LastName = editDetail.LastName,
                EndDate = editDetail.EndDate,
                StartDate = editDetail.StartDate,
                Title = editDetail.Title,
                Wage = editDetail.Wage,
                WorkStyle = editDetail.WorkStyle,
                PictureName = editDetail.Picture
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeEditVM model)
        {
            var edit = _context.Personels.FirstOrDefault(x => x.ID == model.ID);
            var editDetail = _context.PersonelDetails.FirstOrDefault(x=>x.ID==model.ID);

            if (ModelState.IsValid)
            {

                edit.Email = model.Email;
                editDetail.Address = model.Address;
                editDetail.Birthday = model.Birthday;
                editDetail.Department = model.Department;
                editDetail.FirstName = model.FirstName;
                editDetail.LastName = model.LastName;
                editDetail.EndDate = model.EndDate;
                editDetail.StartDate = model.StartDate;
                editDetail.Title = model.Title;
                editDetail.Wage = model.Wage;
                editDetail.WorkStyle = model.WorkStyle;
                if (model.Picture is not null)
                {
                    editDetail.Picture = model.Picture.GetUniqueNameAndSavePhotoToDisk(_webHostEnvironment);
                    FileManager.RemoveImageFromDisk(model.PictureName, _webHostEnvironment);
                }
                _context.SaveChanges();
                return RedirectToAction("EmployeeList", "Manager", new { Id = HttpContext.Session.GetString("userId") });
            }
            else
            {
                return View(model);
            }

        }
    }
    
}
