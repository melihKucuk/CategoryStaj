using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;

namespace CategoryStaj.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category.Entities.Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category.Entities.Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public Category.Entities.Category CreateCategory(Category.Entities.Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public async Task<List<Category.Entities.Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category.Entities.Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<Category.Entities.Category> CreateCategoryAsync(Category.Entities.Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<Category.Entities.Category> UpdateCategoryAsync(Category.Entities.Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
