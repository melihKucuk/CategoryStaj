using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Category.Entities;

namespace CategoryStaj.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category.Entities.Category CreateCategory(Category.Entities.Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Category.Entities.Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category.Entities.Category GetCategoryById(int id)
        {
            if (id > 0)
            {
                return _categoryRepository.GetCategoryById(id);
            }
            throw new Exception("id 1'den küçük olamaz");
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
