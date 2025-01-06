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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Category.AddRangeAsync(obj);
            //await Save();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return false;
            }
            _db.Category.Remove(obj);
            return (await _db.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Category> query = _db.Set<Category>();
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            if(!string.IsNullOrEmpty(includeProperties))
            {
                //Category -- case sensitive
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Category> query = _db.Set<Category>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                //Category -- case sensitive
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _db.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                return obj;
            }
            objFromDb.Name = obj.Name;
            _db.Category.Update(objFromDb);
            //await _db.SaveChangesAsync();
            return objFromDb;
        }
    }
}
