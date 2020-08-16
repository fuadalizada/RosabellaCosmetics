using System;
using System.Linq;
using System.Threading.Tasks;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity,new()
    {
        Task<TEntity> GetById(Guid id);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Remove(Guid id);
    }
}
