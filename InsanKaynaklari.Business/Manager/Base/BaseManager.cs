using InsanKaynaklari.Business.Manager.Abstract;
using InsanKaynaklari.DataAccess.Context;
using InsanKaynaklari.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.Manager.Base
{
    public class BaseManager<T> : IGeneralService<T> where T : class
    {
        //private readonly IGenericRepository<T> _context;
        //public BaseManager(IGenericRepository<T> context)
        //{
        //    _context=context;
        //}

        //public async Task Add(T entity)
        //{
        //    await _context.Add(entity);
        //    await _context.SaveChanges();
        //}

        //public async Task Delete(int id)
        //{
        //    var entity = await GetById(id);
        //    _context.Set<T>().Remove(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    return await query.ToListAsync();
        //}

        //public Task<T> GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task Update(int id, T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //    await _context.SaveChangesAsync();
        //}
        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
