using System.Collections.Generic;
using Category.Entities;
using CategoryStaj.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryStaj.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category.Entities.Category>> Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category.Entities.Category> Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category.Entities.Category> Post([FromBody] Category.Entities.Category category)
        {
            var createdCategory = _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(Get), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category.Entities.Category category)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            category.Id = id; // Ensure the ID is set correctly
            _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
