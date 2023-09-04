using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        protected IRepository<T> _iRep;

        public BaseManager(IRepository<T> iRep)
        {
            _iRep = iRep;
        }


        public void SaveChanges() => _iRep.SaveChanges();
        public async Task SaveChangesAsync() => await _iRep.SaveChangesAsync();

        //----------//

        public void Add(T item) => _iRep.Add(item);
        public async Task AddAsync(T item) => await _iRep.AddAsync(item);
        public void AddRange(List<T> list) => _iRep.AddRange(list);
        public async Task AddRangeAsync(List<T> list) => await _iRep.AddRangeAsync(list);

        //----------//

        public void Update(T item) => _iRep.Update(item);
        public async Task UpdateAsync(T item) => await _iRep.UpdateAsync(item);
        public async Task UpdateRangeAsync(List<T> list) => await _iRep.UpdateRangeAsync(list);

        //----------//

        public void Delete(T item) => _iRep.Delete(item);
        public void DeleteRange(List<T> list) => _iRep.DeleteRange(list);

        //----------//

        public void Destroy(T item) => _iRep.Destroy(item);
        public void DestoryRange(List<T> list) => _iRep.DestoryRange(list);

        //----------//

        public IQueryable<T> GetAll() => _iRep.GetAll();
        public IQueryable<T> GetActives() => _iRep.GetActives();
        public IQueryable<T> GetModifieds() => _iRep.GetModifieds();
        public IQueryable<T> GetPassives() => _iRep.GetPassives();

        //----------//

        public IQueryable<T> Where(Expression<Func<T, bool>> exp) => _iRep.Where(exp);

        public T FirstOrDefault(Expression<Func<T, bool>> exp) => _iRep.FirstOrDefault(exp);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp) => _iRep.FirstOrDefaultAsync(exp);

        public bool Any(Expression<Func<T, bool>> exp) => _iRep.Any(exp);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp) => _iRep.AnyAsync(exp);

        public object Select(Expression<Func<T, object>> exp) => _iRep.Select(exp);
        public Task<object> SelectAsync(Expression<Func<T, object>> exp) => _iRep.SelectAsync(exp);

        //----------//

        public T Find(int id) => _iRep.Find(id);
        public Task<T> FindAsync(int id) => _iRep.FindAsync(id);

        //----------//

        public Task<T> GetFirstDataAsync() => _iRep.GetFirstDataAsync();
        public Task<T> GetLastDataAsync() => _iRep.GetLastDataAsync();
    }
}