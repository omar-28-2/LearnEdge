using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace StudentVoiceNU.Infrastructure.Repositories
{
    public class BaseRepository<T>(LearnEdgeDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly LearnEdgeDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly DbSet<T> _table = context.Set<T>();

        public async Task<T> Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var  entity = await _table.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            _table.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetbyId(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return entity;
            
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _table.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
