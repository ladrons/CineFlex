using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Common;
using CineFlex.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace CineFlex.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CineFlexDbContext _context;

        public BaseRepository(CineFlexDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();


        public void SaveChanges() => _context.SaveChanges();
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        //----------//

        public void Add(T item) => Table.Add(item);
        public async Task AddAsync(T item) => await Table.AddAsync(item);
        public void AddRange(List<T> list) => Table.AddRange(list);
        public async Task AddRangeAsync(List<T> list) => await Table.AddRangeAsync(list);

        public void Update(T item)
        {
            item.Status = Domain.Enums.DataStatus.Modified;
            item.ModifiedDate = DateTime.Now;

            T toBeUpdated = Table.FirstOrDefault(data => data.Id == item.Id);
            Table.Entry(toBeUpdated).CurrentValues.SetValues(item);
        }
        public async Task UpdateAsync(T item)
        {
            item.Status = Domain.Enums.DataStatus.Modified;
            item.ModifiedDate = DateTime.Now;

            T toBeUpdated = await Table.FirstOrDefaultAsync(data => data.Id == item.Id);
            Table.Entry(toBeUpdated).CurrentValues.SetValues(item);
        }
        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list)
            {
                await UpdateAsync(item);
            }
        }

        public void Delete(T item)
        {
            item.Status = Domain.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
        }
        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item) => Table.Remove(item);
        public void DestoryRange(List<T> list) => Table.RemoveRange(list);

        //----------//

        public IQueryable<T> GetAll() => Table.AsQueryable();
        public IQueryable<T> GetActives() => Table.Where(item => item.Status != Domain.Enums.DataStatus.Deleted).AsQueryable();
        public IQueryable<T> GetModifieds() => Table.Where(item => item.Status == Domain.Enums.DataStatus.Modified).AsQueryable();
        public IQueryable<T> GetPassives() => Table.Where(item => item.Status == Domain.Enums.DataStatus.Deleted).AsQueryable();

        //----------//

        public IQueryable<T> Where(Expression<Func<T, bool>> exp) => Table.Where(exp);

        public T FirstOrDefault(Expression<Func<T, bool>> exp) => Table.FirstOrDefault(exp);
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp) => await FirstOrDefaultAsync(exp);

        public bool Any(Expression<Func<T, bool>> exp) => Table.Any(exp);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp) => Table.AnyAsync(exp);

        public object Select(Expression<Func<T, object>> exp) => Table.Select(exp);
        public async Task<object> SelectAsync(Expression<Func<T, object>> exp) => await SelectAsync(exp);

        //----------//

        public T Find(int id) => Table.Find(id);
        public async Task<T> FindAsync(int id) => await Table.FindAsync(id);

        //----------//

        public async Task<T> GetFirstDataAsync() => await Table.OrderBy(item => item.CreatedDate).FirstOrDefaultAsync();
        public async Task<T> GetLastDataAsync() => await Table.OrderByDescending(item => item.CreatedDate).FirstOrDefaultAsync();
    }
}