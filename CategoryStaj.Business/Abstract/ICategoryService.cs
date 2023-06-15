using Category.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CategoryStaj.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category.Entities.Category> GetAllCategories();
        Category.Entities.Category GetCategoryById(int id);
        Category.Entities.Category CreateCategory(Category.Entities.Category category);

        Category.Entities.Category UpdateCategory(Category.Entities.Category category);
        void DeleteCategory(int id);
    }
}
