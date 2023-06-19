using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryStaj.Business.Concrete
{


    public class ProductManager : IProductService
    {
        private ICategoryRepository _productRepository;
        public ProductManager()
        {
            _productRepository = new CategoryRepository();
        }

        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
