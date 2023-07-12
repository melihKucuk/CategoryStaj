using CategoryStaj.Business.ViewModels;
using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryStaj.Business.ViewModels;

namespace CategoryStaj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryCreateViewModelValidator _categoryValidator;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _categoryValidator = new CategoryCreateViewModelValidator();
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryListViewModel>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryListViewModel>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryListViewModel>> UpdateCategoryAsync(int id, [FromBody] CategoryUpdateViewModel categoryViewModel)
        {
            

            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = categoryViewModel.Name;

            var updatedCategory = await _categoryService.UpdateCategoryAsync(existingCategory);
            return Ok(updatedCategory);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCreateViewModel categoryCreateViewModel)
        {
            if (categoryCreateViewModel == null)
            {
                return BadRequest("Kategori bilgileri boş olamaz.");
            }

            var validationResult = await _categoryValidator.ValidateAsync(categoryCreateViewModel);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors.Select(error => new
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage,
                    AttemptedValue = error.AttemptedValue
                }).ToList();

                return BadRequest(validationErrors);
            }

            var category = new Category.Entities.Category
            {
                Name = categoryCreateViewModel.Name
            };

            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            if (createdCategory == null)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = createdCategory.Id }, createdCategory);
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
