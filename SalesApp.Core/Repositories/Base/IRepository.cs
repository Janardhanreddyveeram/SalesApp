using SalesApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Core.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync(string? includeProperties = null);
        Task<IReadOnlyList<T>> SearchAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        Task<T> GetByIdAsync(int id, string? includeProperties = null);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IReadOnlyList<T>> DeleteRangeAsync(IReadOnlyList<T> values);
    }
}
