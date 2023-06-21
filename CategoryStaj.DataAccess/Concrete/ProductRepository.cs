using Category.Entities;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CategoryStaj.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly CategoryDbContext _context;

        public ProductRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()  
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
