using InsanKaynaklari.DataAccess.Repository.BaseRepository;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Repository.Concrete
{
    public class AdvancePaymentRepository :BaseRepository<AdvancePayment>
    {
        public AdvancePaymentRepository(DatabaseContext context):base(context)
        {

        }
        
    }
}
