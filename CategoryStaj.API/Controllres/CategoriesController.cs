using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoryStaj.API.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService=new CategoryManager();
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
    }
}
