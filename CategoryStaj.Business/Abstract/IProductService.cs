using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.Business.Abstract
{
    public  interface IProductService
    {
        List<Category.Entities.Product> GetAllProducts();
        Category.Entities.Product GetProductById(int id);
        Category.Entities.Product CreateProduct(Category.Entities.Product product);

        Category.Entities.Product UpdateProduct(Category.Entities.Product product);
        void DeleteProduct(int id);
    }
}
