using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.DataAccess.Abstract
{
    public interface IProductRepository
    {
       
            List<Category.Entities.Product> GetAllCategories();
            Category.Entities.Product GetCategoryById(int id);
            Category.Entities.Category CreateCategory(Category.Entities.Product product);
            Category.Entities.Product UpdateCategory(Category.Entities.Product product);
            void DeleteProduct(int id);
        
    }
}
