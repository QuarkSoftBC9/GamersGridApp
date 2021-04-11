using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Interfaces.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}