using Category.Entities;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Abstract.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryStaj.DataAccess.Concrete
{
    public class CategoryRepository : Repository<Category.Entities.Category>, ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext categoryDbContext) : base(categoryDbContext)
        {
            _context = categoryDbContext;
        }

        public async Task<List<Category.Entities.Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category.Entities.Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category.Entities.Category> CreateCategoryAsync(Category.Entities.Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category.Entities.Category> UpdateCategoryAsync(Category.Entities.Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
