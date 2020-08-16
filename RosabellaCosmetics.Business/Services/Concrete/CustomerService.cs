using AutoMapper;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Business.FluentValidations;
using RosabellaCosmetics.Business.Services.Abstract;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Business.Services.Concrete
{
    public class CustomerService : BaseService<CustomerDto, Customer, ICustomerRepository, CustomerValidator>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository, IMapper mapper, CustomerValidator validator) : base(repository, mapper, validator)
        {
        }
    }
}
