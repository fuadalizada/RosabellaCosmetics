using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RosabellaCosmetics.Dal.DbContext;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.Repositories.Concrete
{
   public class ProductRepository:BaseRepository<Product>,IProductRepository
   {
       private readonly Microsoft.EntityFrameworkCore.DbContext _context;

        public ProductRepository(RosabellaCosmeticsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Product>> GetActiveProductList()
        {
            var result = await _context.Set<Product>().Where(x => x.IsActive == true).ToListAsync();
            return result.AsQueryable();
        }
    }
}
