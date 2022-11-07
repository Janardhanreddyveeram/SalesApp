using Microsoft.EntityFrameworkCore;
using SalesApp.Core.Entities.Base;
using SalesApp.Core.Repositories.Base;
using SalesAppData.Data;
using System.Linq.Expressions;

namespace SalesAppData.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly SalesAppDbcontext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SalesAppDbcontext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> DeleteRangeAsync(IReadOnlyList<T> values)
        {
            _dbSet.RemoveRange(values);
            await _context.SaveChangesAsync();
            return values;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProp in properties)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProp in properties)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync<T>(T=>T.Id==id);
        }

        public async Task<IReadOnlyList<T>> SearchAsync(Expression<Func<T, bool>> Predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProp in properties)
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.Where(Predicate).ToListAsync();
        }
    }
}
