using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.Manager.Abstract
{
    public interface IGeneralService<T> where T :class
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
