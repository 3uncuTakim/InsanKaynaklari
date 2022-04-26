using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.DataAccess.Abstract
{
    public interface IGeneralRepository<T>where T:class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
