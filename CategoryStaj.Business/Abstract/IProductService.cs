using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Category.Entities.Product>> GetAllProductsAsync();
        Task<Category.Entities.Product> GetProductByIdAsync(int id);
        Task<Category.Entities.Product> CreateProductAsync(Category.Entities.Product product);

        Task<Category.Entities.Product> UpdateProductAsync(Category.Entities.Product product);
        Task DeleteProductAsync(int id);
    }
}
