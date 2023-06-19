using CategoryStaj.DataAccess.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category.Entities;


namespace CategoryStaj.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {

        public Category.Entities.Category CreateCategory(Category.Entities.Category category)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
               categoryDbContext.Categories.Add(category);
                categoryDbContext.SaveChanges();
                return category;
            }
        }

        public void DeleteCategory(int id)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                var deletedCategory = GetCategoryById(id);
                categoryDbContext.Categories.Remove(deletedCategory);
                categoryDbContext.SaveChanges();
            }
        }

        public List<Category.Entities.Category> GetAllCategories()
        {
            using(var categoryDbContext=new CategoryDbContext())
            {
                return  categoryDbContext.Categories.ToList();
            }
            
        }

        public Category.Entities.Category GetCategoryById(int id)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                return categoryDbContext.Categories.Find(id);
            }
        }

        public Category.Entities.Category UpdateCategory(Category.Entities.Category category)
        {
            using (var categoryDbContext = new CategoryDbContext())
            {
                categoryDbContext.Categories.Update(category);
                return category;
            }
        }
    }
}

