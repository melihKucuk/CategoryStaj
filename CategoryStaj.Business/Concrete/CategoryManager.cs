using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;

namespace CategoryStaj.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category.Entities.Category>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.ToList();
        }



        public async Task<Category.Entities.Category> GetCategoryByIdAsync(int id)
        {
            if (id > 0)
            {
                return await _categoryRepository.GetCategoryByIdAsync(id);
            }
            throw new Exception("id 1'den küçük olamaz");
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
