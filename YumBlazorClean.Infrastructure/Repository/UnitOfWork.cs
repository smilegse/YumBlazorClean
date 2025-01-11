using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Application.Common.Interfaces;
using YumBlazorClean.Infrastructure.Data;

namespace YumBlazorClean.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork( ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public async Task<bool> SaveAsync()
        {
            return await (_db.SaveChangesAsync()) > 0;
        }
    }
}
