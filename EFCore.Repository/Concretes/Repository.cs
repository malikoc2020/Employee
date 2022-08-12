using Domain.Base;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly IUnitOfWork unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return unitOfWork.Context.Set<T>().AsQueryable();
        }
        public DbSet<T> GetAllEntities()
        {
            return unitOfWork.Context.Set<T>();
        }
        public T? GetById(int Id)
        {
            return GetAllAsQueryable().Where(x => x.Id == Id).FirstOrDefault();
        }
        public async Task<T?> GetByIdAsync(int Id)
        {
            return await GetAllAsQueryable().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public void Add(T entity)
        {
            unitOfWork.Context.Set<T>().Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await unitOfWork.Context.Set<T>().AddAsync(entity);
        }
        public void AddRange(List<T> entities)
        {
            unitOfWork.Context.Set<T>().AddRange(entities);
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await unitOfWork.Context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateRange(List<T> entities)
        {
            unitOfWork.Context.Entry(entities).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
