using Category.Entities;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Abstract.Generic;

namespace CategoryStaj.DataAccess.Concrete
{
    public class CategoryRepository : Repository<Category.Entities.Category>, ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext categoryDbContext) : base(categoryDbContext)
        {
            _context = categoryDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var deletedProduct = GetProductById(id);
            _context.Products.Remove(deletedProduct);
            _context.SaveChanges();
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
    }
}
