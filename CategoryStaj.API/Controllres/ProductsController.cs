using Category.Entities;
using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryStaj.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            var updatedProduct = await _productService.UpdateProductAsync(product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
