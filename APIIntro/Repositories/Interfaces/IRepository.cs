﻿using APIIntro.Entities;
using System.Linq.Expressions;

namespace APIIntro.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T,bool>> expression);

        public Task<T> GetAsync(Expression<Func<T, bool>> expression);

        public Task Update(T entity);

        public Task Remove(T entity);

        public Task<int> SaveAsync();

        public int Save();

        public Task<bool> IsExist(Expression<Func<T, bool>> expression);

    }
}
