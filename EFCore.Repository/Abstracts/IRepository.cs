using Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsQueryable();
        DbSet<T> GetAllEntities();
        T? GetById(int Id);
        Task<T?> GetByIdAsync(int Id);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(List<T> entities);
        Task AddRangeAsync(List<T> entities);
        void Update(T entity);
        //Task UpdateAsync(T entity);
        void UpdateRange(List<T> entities);
        //Task UpdateRangeAsync(List<T> entities);
        void Delete(T entity);
        //Task DeleteAsync(T entity);
    }
}
