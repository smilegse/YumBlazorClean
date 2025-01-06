using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Domain.Entities;

namespace YumBlazorClean.Application.Common.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>>? filter = null, string? includeProperties = null);
        public Task<Category> GetAsync(Expression<Func<Category, bool>> filter, string? includeProperties = null);
        public Task<Category> CreateAsync(Category obj);
        public Task<Category> UpdateAsync(Category obj);
        public Task<bool> DeleteAsync(int id);
        Task Save();
    }
}
