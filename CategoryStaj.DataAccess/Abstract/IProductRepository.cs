using Category.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryStaj.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(Product product);
    }
}
