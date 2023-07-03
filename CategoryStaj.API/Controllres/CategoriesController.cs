using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryStaj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<Category.Entities.Category>> CreateCategoryAsync([FromBody] Category.Entities.Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            if (createdCategory == null)
            {
                return Conflict();
            }

            return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category.Entities.Category>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category.Entities.Category>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category.Entities.Category>> UpdateCategoryAsync(int id, [FromBody] Category.Entities.Category category)
        {
            if (category == null || id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(category);
            return Ok(updatedCategory);
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
