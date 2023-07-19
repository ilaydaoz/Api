using Casgem.BusinessLayer.Abstract;
using Casgem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetList();
           return Ok(values);
        }

        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
           _productService.TInsert(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult ProductDelete(int id )
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult ProductUpdate(Product product)
        {
            _productService.TUpdate(product);
            return Ok();
        }
    }
}
