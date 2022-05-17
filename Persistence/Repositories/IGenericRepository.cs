using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
       
        Task<T> GetByIdQuery(Guid? id);
        //Task<T> DeleteByIdCommand(T hotel);
        //Task<T> UpdateByIdCommand(T hotel);
        //Task<T> CreateNewCommand(T hotel);
        Task<List<T>> GetAllQuery(int PageNumber, int PageSize);
        //Task<List<T>> GetSearchHotilQuery(string hotelname, int PageSize, int PageNumber);
        Task<List<T>> GetWithIncludeAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
    }
}
