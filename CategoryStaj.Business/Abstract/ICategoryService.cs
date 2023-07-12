using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities;
using CategoryStaj.Business.ViewModels;

namespace CategoryStaj.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category.Entities.Category>> GetAllCategoriesAsync();
        Task<Category.Entities.Category> GetCategoryByIdAsync(int id);
        Task<Category.Entities.Category> CreateCategoryAsync(Category.Entities.Category category);
        Task<Category.Entities.Category> UpdateCategoryAsync(Category.Entities.Category category);
        Task DeleteCategoryAsync(int id);
        Task CreateCategoryAsync(CategoryCreateViewModel categoryViewModel);
    }

}
