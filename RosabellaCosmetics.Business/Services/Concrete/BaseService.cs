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
    public class BaseService<TDto, TEntity, TRepository> : IBaseService<TDto>
        where TDto : BaseDto, new()
        where TEntity : BaseEntity, new()
        where TRepository : IBaseRepository<TEntity>
        //where TValidator : AbstractValidator<TDto>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;
        //private readonly TValidator _validator;
        private readonly AbstractValidator<TDto> _validator;

        protected BaseService(TRepository repository, IMapper mapper, AbstractValidator<TDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ActionResult<IQueryable<TDto>>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();
                var response = _mapper.ProjectTo<TDto>(result);
                return ActionResult<IQueryable<TDto>>.Succeed(response);
            }
            catch (ApplicationException ex)
            {

                return ActionResult<IQueryable<TDto>>.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult<IQueryable<TDto>>.Failure(e.Message);
            }
        }

        public async Task<ActionResult<TDto>> GetById(Guid id)
        {
            try
            {
                var result = await _repository.GetById(id);
                var response = _mapper.Map<TDto>(result);
                return ActionResult<TDto>.Succeed(response);
            }
            catch (ApplicationException ex)
            {
                return ActionResult<TDto>.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult<TDto>.Failure(e.Message);
            }
        }

        public async Task<ActionResult<TDto>> Add(TDto dto)
        {
            try
            {
                var valResult = await _validator.ValidateAsync(dto);
                var valErrors = valResult.Errors.Select(e => e.ErrorMessage).ToArray();
                if (valResult.IsValid)
                {
                    var entity = _mapper.Map<TEntity>(dto);
                    var response = await _repository.Add(entity);
                    var result = _mapper.Map<TDto>(response);
                    return ActionResult<TDto>.Succeed(result);
                }
                return ActionResult<TDto>.Failure(valErrors);
            }
            catch (ApplicationException ex)
            {
                return ActionResult<TDto>.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult<TDto>.Failure(e.Message);
            }
        }

        public async Task<ActionResult<TDto>> Update(TDto dto)
        {
            try
            {
                var valResult = _validator.Validate(dto);
                var valErrors = valResult.Errors.Select(x => x.ErrorMessage).ToArray();
                if (valResult.IsValid)
                {
                    var entity = _mapper.Map<TEntity>(dto);
                    var response = await _repository.Update(entity);
                    var result = _mapper.Map<TDto>(response);
                    return ActionResult<TDto>.Succeed(result);
                }
                return ActionResult<TDto>.Failure(valErrors);

            }
            catch (ApplicationException ex)
            {
                return ActionResult<TDto>.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult<TDto>.Failure(e.Message);
            }
        }

        public async Task<ActionResult.ActionResult> Remove(Guid id)
        {
            try
            {
                await _repository.Remove(id);
                return ActionResult.ActionResult.Succeed();
            }
            catch (ApplicationException ex)
            {
                return ActionResult.ActionResult.Failure(ex.ToString());
            }
            catch (Exception e)
            {
                return ActionResult.ActionResult.Failure(e.Message);
            }
        }
    }
}
