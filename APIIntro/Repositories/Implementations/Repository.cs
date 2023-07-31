﻿using APIIntro.Contexts;
using APIIntro.Entities;
using APIIntro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIIntro.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly ApiDbContext _context;

        public Repository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).Count() > 0;
        }

        public async Task Remove(T entity)
        {
            _context.Remove(entity);    
        }

        public int Save()
        {
           return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
           return _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
