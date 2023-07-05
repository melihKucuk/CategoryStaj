using Category.Entities;
using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities.Pagination;
using Microsoft.EntityFrameworkCore;
using CategoryStaj.Business.ViewModels;


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
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1)
        {
            var products = await _productService.GetAllProductsAsync();

            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = product.Category != null
            ? new CategoryViewModel
            {
                Id = product.Category.Id,
                Name = product.Category.Name
            }
            : null
                };
                productViewModels.Add(productViewModel);
            }

            var pagedProducts = new PaginationResult<ProductViewModel>(
                productViewModels, productViewModels.Count, pageNumber, pageSize);

            return Ok(pagedProducts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = new ProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = new CategoryViewModel
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                }
            };

            return Ok(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
        {
            if (productViewModel == null)
            {
                return BadRequest();
            }

            var product = new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                CategoryId = productViewModel.CategoryId
            };

            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductViewModel productViewModel)
        {
            if (productViewModel == null || id != productViewModel.ProductId)
            {
                return BadRequest();
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = productViewModel.Name;
            existingProduct.Price = productViewModel.Price;
            existingProduct.CategoryId = productViewModel.CategoryId;

            var updatedProduct = await _productService.UpdateProductAsync(existingProduct);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
