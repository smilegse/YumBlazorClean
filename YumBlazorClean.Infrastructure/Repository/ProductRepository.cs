using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YumBlazorClean.Application.Common.Interfaces;
using YumBlazorClean.Domain.Entities;
using YumBlazorClean.Infrastructure.Data;

namespace YumBlazorClean.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Product> UpdateAsync(Product entity)
        {
            _db.Product.Update(entity);
            return entity;
        }

        //public async Task<Product> UpdateAsync(Product obj)
        //{
        //    var objFromDb = await _db.Product.FirstOrDefaultAsync(u => u.Id == obj.Id);
        //    if (objFromDb == null)
        //    {
        //        return obj;
        //    }
        //    objFromDb.Name = obj.Name;
        //    using (var transaction = await _db.Database.BeginTransactionAsync())
        //    try
        //    {
        //        _db.Product.Update(objFromDb);
        //        //await SaveAsync();
        //        await transaction.CommitAsync();
        //        return objFromDb;
        //    }
        //    catch (Exception)
        //    {
        //        await transaction.RollbackAsync();
        //        throw;
        //    }            
        //}

        //public async Task<bool> SaveAsync()
        //{
        //     return await (_db.SaveChangesAsync())>0;
        //}
    }
}
