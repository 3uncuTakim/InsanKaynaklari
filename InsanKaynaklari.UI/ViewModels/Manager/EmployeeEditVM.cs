using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Manager
{
    public class EmployeeEditVM
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureName { get; set; }
        public decimal Wage { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string WorkStyle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string GetPictureName()
        {
            if (string.IsNullOrEmpty(PictureName))
            {
                return default;
            }
            else
            {
                return PictureName.Substring(PictureName.IndexOf("_") + 1);
            }
        }
    }
}
