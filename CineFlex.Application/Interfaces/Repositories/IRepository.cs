using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void SaveChanges();
        Task SaveChangesAsync();


        //Modify Commands
        void Add(T item);
        Task AddAsync(T item);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);

        void Update(T item);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);

        void Delete(T item);
        void DeleteRange(List<T> list);

        void Destroy(T item);
        void DestoryRange(List<T> list);


        //List Commands
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetPassives();
        IQueryable<T> GetModifieds();


        //LINQ Commands
        IQueryable<T> Where(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);

        object Select (Expression<Func<T, object>> exp);
        Task<object> SelectAsync(Expression<Func<T, object>> exp);


        //Find Command
        T Find(int id);
        Task<T> FindAsync(int id);


        //First-Last Data Commands
        Task<T> GetFirstDataAsync();
        Task<T> GetLastDataAsync();
    }
}