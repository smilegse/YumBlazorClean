using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Domain.Entities;

namespace YumBlazorClean.Application.Common.Interfaces
{
    public interface IRepository<T> where T: class
    {

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true, string? includeProperties = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> SaveAsync();

    }
}
