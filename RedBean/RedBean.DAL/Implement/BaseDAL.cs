using Microsoft.EntityFrameworkCore;
using RedBean.DAL.Interface;
using RedBean.Model;
using RedBean.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedBean.DAL.Implement
{
    public class BaseDAL : IBaseDAL
    {
        public DataContext db;
        public BaseDAL(DataContext db)
        {
            this.db = db;
        }
        public async Task<int> AddAsync<T>(T model) where T : BaseEntity
        {
            await db.Set<T>().AddAsync(model);
            return await db.SaveChangesAsync();
        }
        public int Add<T>(ref T model) where T : BaseEntity
        {
            db.Set<T>().AddAsync(model);
            return db.SaveChanges();
        }
        public async Task<int> AddRangeAsync<T>(List<T> model) where T : BaseEntity
        {
            await db.Set<T>().AddRangeAsync(model);
            return await db.SaveChangesAsync();
        }
        public async Task<int> RemoveAsync<T>(T model) where T : BaseEntity
        {
            model.IsRemoved = true;
            db.Set<T>().Update(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync<T>(List<T> model) where T : BaseEntity
        {
            model.ForEach(p => {
                p.IsRemoved = false;
            });
            db.Set<T>().UpdateRange(model);
            return await db.SaveChangesAsync();
        }
        public async Task<int> RemoveRangeAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var model = ListWhere(predicate).ToList();
            model.ForEach(p =>
            {
                p.IsRemoved = false;
            });
            db.Set<T>().UpdateRange(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<T>(T model) where T : BaseEntity
        {
            db.Set<T>().Update(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync<T>(List<T> model) where T : BaseEntity
        {
            db.Set<T>().UpdateRange(model);
            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateRangeAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var model = ListWhere(predicate).ToList();
            db.Set<T>().UpdateRange(model);
            return await db.SaveChangesAsync();
        }
        public IQueryable<T> List<T>() where T : BaseEntity
        {
            return db.Set<T>().Where(p => !p.IsRemoved).AsNoTracking();
        }
        public IQueryable<T> ListWhere<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return List<T>().Where(predicate);
        }
        public IQueryable<T> ListByPage<T>(IQueryable<T> queryable, int pageSize = 10, int pageIndex = 0) where T : BaseEntity
        {
            return queryable.Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> ListByPage<T>(Expression<Func<T, bool>> predicate, int pageSize = 10, int pageIndex = 0) where T : BaseEntity
        {
            return ListWhere(predicate).Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> ListByPage<T>(int pageSize = 10, int pageIndex = 0) where T : BaseEntity
        {
            return List<T>().Skip(pageSize * pageIndex).Take(pageSize);
        }
        public IQueryable<T> Get<T>(Guid id) where T : BaseEntity
        {
            return List<T>().Where(p => p.Id == id);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
