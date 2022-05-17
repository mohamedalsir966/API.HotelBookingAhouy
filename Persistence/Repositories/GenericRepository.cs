using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> entity;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public async Task<List<T>> GetAllQuery(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdQuery(Guid? id)
        {
            return await entity.FindAsync(id);
        }
        public async Task<List<T>> GetWithIncludeAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = this.entity;
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
