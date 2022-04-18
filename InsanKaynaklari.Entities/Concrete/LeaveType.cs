using InsanKaynaklari.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Entities.Concrete
{
    public class LeaveType:BaseEntity
    {
        public string TypeName { get; set; }

        public virtual List<Leave> Leave { get; set; }
    }
}
