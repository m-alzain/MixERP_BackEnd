﻿using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using ApplicationCore.Entities.Accounts;

namespace Infrastructure.Data
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : class //BaseEntity
    {
        protected readonly SqlserverContext _dbContext;

        public EfRepository(SqlserverContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async virtual Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        public async virtual Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async virtual Task<T> GetByIdAsync(string id)
        {
            return await GetByIdAsync(Guid.Parse(id));
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IQueryable<T> List()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            // https://docs.microsoft.com/en-us/dotnet/api/system.data.objects.objectquery-1.include?view=netframework-4.7.2&viewFallbackFrom=netcore-2.2
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria);
        }

        public T Add(T entity)
        {
            if (entity is IEntity)  // the current user may add himself for the first time
            {
                var e = entity as IEntity;
                e.Id = Guid.NewGuid();               
            }
            if (entity is IAuditable && !(entity is User))  // the current user may add himself for the first time
            {
                var auditable = entity as IAuditable;
                auditable.CreatedByUserId = Guid.Parse("FDDFF607-9C87-4CBC-93F9-8544D4B04B62"); //from the context
                auditable.UpdatedByUserId = Guid.Parse("FDDFF607-9C87-4CBC-93F9-8544D4B04B62"); //from the context
                auditable.CreatedOn = DateTime.Now;
                auditable.UpdatedOn = DateTime.Now;
            }

            _dbContext.Set<T>().Add(entity);               
            return entity;
        }

        public void Update(T entity)
        {
            if (entity is IAuditable)
            {
                var auditable = entity as IAuditable;
                auditable.UpdatedByUserId = Guid.Parse("FDDFF607-9C87-4CBC-93F9-8544D4B04B62"); //from the context
                auditable.UpdatedOn = DateTime.Now;
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
              
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
