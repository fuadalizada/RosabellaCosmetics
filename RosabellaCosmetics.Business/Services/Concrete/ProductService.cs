using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using RosabellaCosmetics.Business.ActionResult;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Business.Services.Abstract;
using RosabellaCosmetics.Dal.Repositories.Abstract;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Business.Services.Concrete
{
    public class ProductService : BaseService<ProductDto, Product, IProductRepository>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        //private readonly ProductValidator _validator;
        private readonly AbstractValidator<ProductDto> _validator;

        public ProductService(IProductRepository repository, IMapper mapper, AbstractValidator<ProductDto> validator) : base(repository, mapper, validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActionResult<IQueryable<ProductDto>>> GetActiveProductList()
        {
            try
            {
                var result = await _repository.GetActiveProductList();
                var response = _mapper.ProjectTo<ProductDto>(result);
                return ActionResult<IQueryable<ProductDto>>.Succeed(response);
            }
            catch (ApplicationException ex)
            {
                return ActionResult<IQueryable<ProductDto>>.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult<IQueryable<ProductDto>>.Failure(e.Message);
            }
        }
    }
}
