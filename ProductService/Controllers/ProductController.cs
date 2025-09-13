using Microsoft.AspNetCore.Mvc;
using ProductService.Common_Repository;
using ProductService.DTO;
using ProductService.Models;
using ProductService.Return_Data;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CommonProductInterface<Productscs, ProductDTO> productInterface;
        public ProductController(CommonProductInterface<Productscs, ProductDTO> _productInterface)
        {
            productInterface = _productInterface;
        }
        [HttpPost]
        public async Task<CommonReturn> InsertProduct(ProductDTO DTO)
        {
            var data = await productInterface.AddProduct(DTO);
            return data;
        }
        [HttpGet("AllUser")]
        public async Task<CommonReturn> GetAllProduct()
        {
            var data = await productInterface.GetAllProduct();
            return data;
        }
    }
}
