using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Category.Entities.Product;



namespace CategoryStaj.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        List<Category.Entities.Product> GetAllProducts();
        Category.Entities.Product GetProductById(int id);
        Category.Entities.Product CreateProduct(Category.Entities.Product product);
        Category.Entities.Product UpdateProduct(Category.Entities.Product product);
        void DeleteCategory(int id);
        List<Category.Entities.Category> GetAllCategories();
        Category.Entities.Category CreateCategory(Category.Entities.Category category);
        Category.Entities.Category GetCategoryById(int id);
        Category.Entities.Category UpdateCategory(Category.Entities.Category category);
    }

}
