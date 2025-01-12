using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YumBlazorClean.Application.Common.Interfaces;
using YumBlazorClean.Domain.Entities;
using YumBlazorClean.Infrastructure.Data;

namespace YumBlazorClean.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            try
            {
                await _dbSet.AddRangeAsync(entity);
                await SaveAsync();
                    // throw new Exception("custom error");
                await transaction.CommitAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                return entity;
            }
            catch (Exception)
            {
                // rollback transaction if exception occurs
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            /* https://learn.microsoft.com/en-us/ef/core/saving/transactions */

            //using var context1 = new BloggingContext(options);
            using (var transaction = await _db.Database.BeginTransactionAsync())
            try
            {
                _dbSet.Remove(entity);
                //_db.ChangeTracker.DetectChanges();
                await SaveAsync();

                // throw new Exception("custom error");
                await transaction.CommitAsync();
                return true;
                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
            }
            catch (Exception)
            {
                // rollback transaction if exception occurs
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                //var username = await _db.GetUserId();

                // Used for audit log
                //var audit = new Audit();
                //if (!string.IsNullOrEmpty(username))
                //{
                //    audit.CreatedBy = username;
                //}

                return await (_db.SaveChangesAsync())>0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }
    }
}
