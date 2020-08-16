using RosabellaCosmetics.Dal.DbContext;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.Repositories.Concrete
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(RosabellaCosmeticsDbContext context) : base(context)
        {
        }
    }
}
