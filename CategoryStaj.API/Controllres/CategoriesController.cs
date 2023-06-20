using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CategoryStaj.API.Controllers
{
    [Route("api/categories")]

    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category.Entities.Category> Get()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("{id}")]
        public Category.Entities.Category Get(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        public Category.Entities.Category Post([FromBody] Category.Entities.Category category)
        {
            return _categoryService.CreateCategory(category);
        }

        [HttpPut]
        public Category.Entities.Category Put([FromBody] Category.Entities.Category category)
        {
            return _categoryService.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
