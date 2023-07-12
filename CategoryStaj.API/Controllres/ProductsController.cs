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
        private readonly ProductCreateViewModelValidator _productValidator;


        public ProductController(IProductService productService)
        {
            _productService = productService;
            _productValidator = new ProductCreateViewModelValidator();
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1)
        {
            var products = await _productService.GetAllProductsAsync();

            var productViewModels = new List<ProductListViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductListViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = product.Category != null
                        ? new CategoryListViewModel
                        {
                            Id = product.Category.Id,
                            Name = product.Category.Name
                        }
                        : null
                };
                productViewModels.Add(productViewModel);
            }

            var pagedProducts = new PaginationResult<ProductListViewModel>(
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

            var productViewModel = new ProductListViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = product.Category != null ? new CategoryListViewModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                } : null
            };

            return Ok(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateViewModel productCreateViewModel)
        {
            if (productCreateViewModel == null)
            {
                productCreateViewModel = new ProductCreateViewModel();
            }

            var validationResult = await _productValidator.ValidateAsync(productCreateViewModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var product = new Product
            {
                Name = productCreateViewModel.Name,
                Price = productCreateViewModel.Price,
                CategoryId = productCreateViewModel.CategoryId
            };

            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.ProductId }, createdProduct);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductUpdateViewModel productUpdateViewModel)
        {
            if (productUpdateViewModel == null || id != productUpdateViewModel.ProductId)
            {
                return BadRequest();
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = productUpdateViewModel.Name;
            existingProduct.Price = productUpdateViewModel.Price;
            existingProduct.CategoryId = productUpdateViewModel.CategoryId;

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
