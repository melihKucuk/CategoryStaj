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

        public Category.Entities.Category CreateCategory(Category.Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var deletedCategory = GetCategoryById(id);
            _context.Categories.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public List<Category.Entities.Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category.Entities.Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
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
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deletedCategory = await GetCategoryByIdAsync(id);
            _context.Categories.Remove(deletedCategory);
            await _context.SaveChangesAsync();
        }
    }
}
