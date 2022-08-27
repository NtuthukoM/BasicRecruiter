using BasicRecruiter.Application.Contracts;
using BasicRecruiter.Domain;
using BasicRecruiter.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T:BaseEntity
    {
        private readonly BasicRecruiterDbContext context;

        public GenericRepository(BasicRecruiterDbContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            bool response = false;
            if (entity != null)
            {
                entity.Deleted = true;
                context.Entry(entity).State = EntityState.Modified;
                response = await context.SaveChangesAsync() > 0;
            }
            return response;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync() > 0;
        }
    }
}
