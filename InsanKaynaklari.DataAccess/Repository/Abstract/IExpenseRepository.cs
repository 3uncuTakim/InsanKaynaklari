using InsanKaynaklari.DataAccess.Repository.IRepository;
using InsanKaynaklari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Repository.Abstract
{
    public interface IExpenseRepository:IGenericRepository<Expense>
    {
    }
}
