using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosabellaCosmetics.Business.ActionResult;
using RosabellaCosmetics.Business.DTOs;

namespace RosabellaCosmetics.Business.Services.Abstract
{
    public interface IBaseService<TDto> where TDto:BaseDto,new()
    {
        Task <ActionResult<TDto>> GetById(Guid id);
        Task <ActionResult<IQueryable<TDto>>> GetAll();
        Task<ActionResult<TDto>> Add(TDto dto);
        Task<ActionResult<TDto>> Update(TDto dto);
        Task<ActionResult.ActionResult> Remove(Guid id);
    }
}
