using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.Repositories.Abstract
{
   public interface IProductRepository:IBaseRepository<Product>
   {
       Task<IQueryable<Product>> GetActiveProductList();
   }
}
