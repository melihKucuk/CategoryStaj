using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities;

namespace CategoryStaj.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Category.Entities.Category> GetAllCategories();
        Category.Entities.Category GetCategoryById(int id);
        Category.Entities.Category CreateCategory(Category.Entities.Category category);
        Category.Entities.Category UpdateCategory(Category.Entities.Category category);
        void DeleteCategory(int id);

        // Asenkron işlemler
        Task<List<Category.Entities.Category>> GetAllCategoriesAsync();
        Task<Category.Entities.Category> GetCategoryByIdAsync(int id);
        Task<Category.Entities.Category> CreateCategoryAsync(Category.Entities.Category category);
        Task<Category.Entities.Category> UpdateCategoryAsync(Category.Entities.Category category);
        Task DeleteCategoryAsync(int id);
    }
}
