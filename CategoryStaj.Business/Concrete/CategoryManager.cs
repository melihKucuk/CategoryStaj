using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;
using Microsoft.Extensions.Caching.Memory;
using CategoryStaj.Business.ViewModels;

namespace CategoryStaj.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _cache;

        public CategoryManager(ICategoryRepository categoryRepository, IMemoryCache cache)
        {
            _categoryRepository = categoryRepository;
            _cache = cache;
        }

        public async Task<List<Category.Entities.Category>> GetAllCategoriesAsync()
        {
            string cacheKey = "Categories";

            if (_cache.TryGetValue<List<Category.Entities.Category>>(cacheKey, out var categories))
            {
                return categories;
            }

            categories = await _categoryRepository.GetAllCategoriesAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); // Önbellekte 10 dakika kalacak

            _cache.Set(cacheKey, categories, cacheOptions);

            return categories;
        }

        public async Task<Category.Entities.Category> GetCategoryByIdAsync(int id)
        {
            string cacheKey = $"Category_{id}";

            if (_cache.TryGetValue<Category.Entities.Category>(cacheKey, out var category))
            {
                return category;
            }

            category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); // Önbellekte 10 dakika kalacak

                _cache.Set(cacheKey, category, cacheOptions);
            }

            return category;
        }

        public async Task<Category.Entities.Category> CreateCategoryAsync(Category.Entities.Category category)
        {
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);

            // Önbellekteki tüm kategorileri temizle
            _cache.Remove("Categories");

            return createdCategory;
        }

        public async Task<Category.Entities.Category> UpdateCategoryAsync(Category.Entities.Category category)
        {
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);

            // Güncellenen kategorinin önbelleğini temizle
            string cacheKey = $"Category_{category.Id}";
            _cache.Remove(cacheKey);

            // Önbellekteki tüm kategorileri temizle
            _cache.Remove("Categories");

            return updatedCategory;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);

            // Silinen kategorinin önbelleğini temizle
            string cacheKey = $"Category_{id}";
            _cache.Remove(cacheKey);

            // Önbellekteki tüm kategorileri temizle
            _cache.Remove("Categories");
        }

        public Task CreateCategoryAsync(CategoryCreateViewModel categoryViewModel)
        {
            throw new NotImplementedException();
        }
    }
}