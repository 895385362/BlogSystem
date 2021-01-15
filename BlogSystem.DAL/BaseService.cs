using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Model;

namespace BlogSystem.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly BlogContext _db;

        public BaseService(Model.BlogContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(T model , bool saved = true)
        {
            _db.Set<T>().Add(model);

            if (saved)
            {
                await _db.SaveChangesAsync();
            }

        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
        /// <summary>
        /// 返回所有未被删除的数据（没有真的执行）
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllAsync()
        {
            return _db.Set<T>().Where(m => !m.IsRemoved).AsNoTracking();
        }

        public IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            //Take 连续获取 刨除了前面的数据在剩余的数据里取前十个
            return GetAllAsync().Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = false)
        {
            return GetAllOrderAsync(asc).Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllOrderAsync(bool asc = true)
        {
            var datas = GetAllAsync();
            datas = asc? datas.OrderBy(m => m.CreateTime) : datas.OrderByDescending(m => m.CreateTime);
            return datas;
           
        }

        public async Task<T> GetOneByIDAsync(Guid ID)
        {
            return await GetAllAsync().FirstAsync(m => m.ID == ID);
        }

        public async Task RemoveAsync(Guid ID, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            var t = new T() { ID = ID };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.ID, saved);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
