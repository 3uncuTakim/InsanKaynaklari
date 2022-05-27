using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.ManagerEvent
{
    public class ManagerEventMainPageVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public List<int> AssignedEmployees { get; set; }
    }
}
