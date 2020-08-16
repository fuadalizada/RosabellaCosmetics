using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            var result = await _dbSet.ToListAsync();
            return result.AsQueryable();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            entity.Id = new Guid();
            entity.CreatedDate = DateTime.UtcNow;
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = await _dbSet.FindAsync(entity.Id);
            entity.UpdatedDate = DateTime.UtcNow;
            var entry = _context.Entry(updatedEntity);
            entry.CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(Guid id)
        {
            var removed = await _dbSet.FindAsync(id);
            removed.DeletedDate = DateTime.UtcNow;
            removed.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
