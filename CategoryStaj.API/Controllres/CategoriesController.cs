using CategoryStaj.Business.ViewModels;
using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryStaj.Business.ViewModels.Validations;

namespace CategoryStaj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryViewModelValidator _categoryValidator;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _categoryValidator = new CategoryViewModelValidator();
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryViewModel>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewModel>> UpdateCategoryAsync(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null || id != categoryViewModel.Id)
            {
                return BadRequest();
            }

            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryViewModel);
            return Ok(updatedCategory);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> CreateCategoryAsync([FromBody] CategoryViewModel categoryViewModel)
        {
            var validationResult = await _categoryValidator.ValidateAsync(categoryViewModel);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(categoryViewModel);
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
