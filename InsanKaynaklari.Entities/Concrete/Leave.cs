using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class Leave:BaseEntity
    {
        public string LeaveDocument { get; set; }
        public int TotalDaysOff { get; set; }
        public DateTime StartLeaveDate { get; set; }
        public DateTime EndLeaveDate { get; set; }
        public string Description { get; set; }
        public bool AcceptanceStatus { get; set; }
        public LeaveType leaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public virtual Personel personel { get; set; }
        public int PersonelID { get; set; }



    }
}
