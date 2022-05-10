using InsanKaynaklari.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Leaves
{
    public class LeaveCreateVM
    {
        public IFormFile LeaveDocument { get; set; }
        public DateTime StartLeaveDate { get; set; }
        public DateTime EndLeaveDate { get; set; }
        public string Description { get; set; }
        public int LeaveTypeID { get; set; }
        public string leaveTypeName { get; set; }
    }
}
