using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.Business.Concrete
{
    

    public class ProductManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public ProductManager()
        {
            _categoryRepository = new CategoryRepository();
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
            if (id>0)
            {
                return _categoryRepository.GetCategoryById(id);
            }
            throw new Exception("id 1 den kucuk olamaz");
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
