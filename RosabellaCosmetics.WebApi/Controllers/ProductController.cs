using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Business.Services.Abstract;

namespace RosabellaCosmetics.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductList()
        {
           var allProductList = await _productService.GetAll();
           return Ok(allProductList);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetActiveProductList()
        {
            var activeProductList = await _productService.GetActiveProductList();
            return Ok(activeProductList);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] ProductDto product)
        {
            await _productService.Add(product);
            return CreatedAtAction("GetById", new {id = product.Id}, product);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
            if (await _productService.GetById(product.Id) != null)
            {
                return Ok(await _productService.Update(product));
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            if (await _productService.GetById(id) != null)
            {
                return Ok(_productService.Remove(id));
            }

            return NotFound();

        }
    }
}
