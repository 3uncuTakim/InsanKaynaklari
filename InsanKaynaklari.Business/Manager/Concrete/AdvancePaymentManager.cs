using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynaklari.Business.Manager.Base;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.DataAccess.Repository.IRepository;
using InsanKaynaklari.Entities.Concrete;

namespace InsanKaynaklari.Business.Repository.Concrete
{
    public class AdvancePaymentManager : BaseManager<AdvancePayment>
    {
        private readonly IGenericRepository<AdvancePayment> _genericRepository;

        public AdvancePaymentManager(IGenericRepository<AdvancePayment> genericRepository,DatabaseContext context):base(context)
        {
            _genericRepository = genericRepository;
        }
    }
}
