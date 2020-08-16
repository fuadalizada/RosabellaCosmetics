using System;
using System.Linq;
using System.Threading.Tasks;
using RosabellaCosmetics.Business.ActionResult;
using RosabellaCosmetics.Business.DTOs;

namespace RosabellaCosmetics.Business.Services.Abstract
{
    public interface IProductService:IBaseService<ProductDto>
    {
        Task<ActionResult<IQueryable<ProductDto>>> GetActiveProductList();
    }
}
