using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> //where T : BaseEntity
    {
        //Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(string id);
        T GetSingleBySpec(ISpecification<T> spec);
        IQueryable<T> List();
        IQueryable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
