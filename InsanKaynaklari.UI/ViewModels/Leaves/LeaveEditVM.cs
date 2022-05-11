using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.UI.ViewModels.Leaves
{
    public class LeaveEditVM
    {
        public int ID { get; set; }
        public IFormFile LeaveDocument { get; set; }
        public DateTime StartLeaveDate { get; set; }
        public DateTime EndLeaveDate { get; set; }
        public string Description { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveDocumentName { get; set; }

        public string GetLeaveDocumentName()
        {
            if (string.IsNullOrEmpty(LeaveDocumentName))
            {
                return default;
            }
            else
            {
                return LeaveDocumentName.Substring(LeaveDocumentName.IndexOf("_") + 1);
            }
        }
    }
}
