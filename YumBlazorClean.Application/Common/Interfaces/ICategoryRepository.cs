using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Domain.Entities;

namespace YumBlazorClean.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> UpdateAsync(Category obj);
        Task<bool> SaveAsync();
    }
}
