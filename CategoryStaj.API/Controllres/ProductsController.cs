using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CategoryStaj.API.Controllres
{
    [Route("api/[product]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController()
        {
            
            _productService = new ProductManager();
        }
        [HttpGet]
        public List<Category.Entities.Product> Get()
        {
            return _productService.GetAllProducts();
        }
        [HttpGet("{id}")]
        public Category.Entities.Product Get(int id)
        {
            return _productService. GetProductById(id);
        }
        [HttpPost]
        public Category.Entities.Product Post([FromBody] Category.Entities.Product product)
        {
            return _productService.CreateProduct(product);
        }
        [HttpPut]
        public Category.Entities.Product Put([FromBody] Category.Entities.Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
