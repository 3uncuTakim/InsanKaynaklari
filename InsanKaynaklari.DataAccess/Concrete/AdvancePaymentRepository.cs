using InsanKaynaklari.DataAccess.Abstract;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Concrete
{
    public class AdvancePaymentRepository : IGeneralRepository<AdvancePayment>
    {
        private readonly DatabaseContext _context;

        public AdvancePaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        
    }
}
