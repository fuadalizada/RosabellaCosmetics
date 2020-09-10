using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RosabellaCosmetics.Business.Services.Abstract;

namespace RosabellaCosmetics.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetActiveProductList();
            return View(model.Data);
        }
    }
}
