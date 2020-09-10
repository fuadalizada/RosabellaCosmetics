using AutoMapper;
using FluentValidation;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Business.Services.Abstract;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Business.Services.Concrete
{
    public class CustomerService : BaseService<CustomerDto, Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository, IMapper mapper, AbstractValidator<CustomerDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
