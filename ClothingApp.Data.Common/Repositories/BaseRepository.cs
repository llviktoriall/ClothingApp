﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingApp.Data.Common.Interfaces;

namespace ClothingApp.Data.Common.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(long id)
        {
            var dbSet = _context.Set<T>();
            var item = await dbSet.FindAsync(id);

            if (item == null)
            {
                return false;

            }

            _context.Entry(item).State = EntityState.Detached;

            return true;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(long id)
        {
            var dbSet = _context.Set<T>();
            var item = await dbSet.FindAsync(id);

            if (item != null)
            {
                _context.Remove(item);
            }
        }
    }
}
