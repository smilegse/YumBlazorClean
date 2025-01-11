using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Domain.Entities;

namespace YumBlazorClean.Application.Common.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product obj);
        //Task<bool> SaveAsync();
    }
}
