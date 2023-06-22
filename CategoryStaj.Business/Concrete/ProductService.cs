using Category.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess;

namespace CategoryStaj.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly CategoryDbContext _context;

        public ProductService(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category.Entities.Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Category.Entities.Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Category.Entities.Product> CreateProductAsync(Category.Entities.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Category.Entities.Product> UpdateProductAsync(Category.Entities.Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
