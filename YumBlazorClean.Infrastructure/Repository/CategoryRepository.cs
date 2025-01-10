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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _db.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                return obj;
            }
            objFromDb.Name = obj.Name;
            using (var transaction = await _db.Database.BeginTransactionAsync())
            try
            {
                _db.Category.Update(objFromDb);
                await SaveAsync();
                await transaction.CommitAsync();
                return objFromDb;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            
        }

        public async Task<bool> SaveAsync()
        {
             return await (_db.SaveChangesAsync())>0;
        }
    }
}
