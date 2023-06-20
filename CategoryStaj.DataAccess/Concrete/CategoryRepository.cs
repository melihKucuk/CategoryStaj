using CategoryStaj.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using Category.Entities;

namespace CategoryStaj.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _categoryDbContext;

        public CategoryRepository(CategoryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _categoryDbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _categoryDbContext.Products.Find(id);
        }

        public Product CreateProduct(Product product)
        {
            _categoryDbContext.Products.Add(product);
            _categoryDbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _categoryDbContext.Products.Update(product);
            _categoryDbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var deletedProduct = GetProductById(id);
            _categoryDbContext.Products.Remove(deletedProduct);
            _categoryDbContext.SaveChanges();
        }

        public Category.Entities.Category CreateCategory(Category.Entities.Category category)
        {
            _categoryDbContext.Categories.Add(category);
            _categoryDbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var deletedCategory = GetCategoryById(id);
            _categoryDbContext.Categories.Remove(deletedCategory);
            _categoryDbContext.SaveChanges();
        }

        public List<Category.Entities.Category> GetAllCategories()
        {
            return _categoryDbContext.Categories.ToList();
        }

        public Category.Entities.Category GetCategoryById(int id)
        {
            return _categoryDbContext.Categories.Find(id);
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            _categoryDbContext.Categories.Update(category);
            _categoryDbContext.SaveChanges();
            return category;
        }
    }
}
