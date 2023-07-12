using Category.Entities;
using CategoryStaj.Business.Abstract;
using CategoryStaj.DataAccess.Abstract;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CategoryStaj.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        private IMemoryCache _cache;

        public ProductManager(IProductRepository productRepository, IMemoryCache cache)
        {
            _productRepository = productRepository;
            _cache = cache;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            // Tüm ürünleri veritabanından al
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            // İlgili ID'ye sahip ürünü veritabanından al

            // Önbellekten kontrol et
            // Eğer önbellekte varsa, önbellekten döndür
            // Eğer önbellekte yoksa, veritabanından al ve önbelleğe ekle

            string cacheKey = $"Product_{id}";

            if (_cache.TryGetValue<Product>(cacheKey, out var product))
            {
                // Önbellekte veri bulundu
                return product;
            }
            else
            {
                // Önbellekte veri bulunamadı, veritabanından al ve önbelleğe ekle
                product = await _productRepository.GetByIdAsync(id);

                if (product != null)
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); // Önbellekte 10 dakika kalacak

                    _cache.Set(cacheKey, product, cacheOptions);
                }

                return product;
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // Yeni ürünü veritabanına ekle

            // Önbellekteki tüm ürünleri temizle

            return await _productRepository.CreateAsync(product);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            // Ürünü güncelle

            // Güncellenen ürünün önbelleğini temizle

            // Önbellekteki tüm ürünleri temizle

            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            // Silinen ürünün önbelleğini temizle
            _cache.Remove($"Product_{id}");

            // Önbellekteki tüm öğeleri temizle
            var cacheKeys = new List<string>();
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;

            foreach (var cacheItem in cacheEntriesCollection)
            {
                var key = cacheItem.GetType().GetProperty("Key").GetValue(cacheItem) as string;
                cacheKeys.Add(key);
            }

            foreach (var cacheKey in cacheKeys)
            {
                _cache.Remove(cacheKey);
            }

            // tüm cacheyi boşaltmaya gerek var mı bilmiyorum???????????


            await _productRepository.DeleteAsync(id);
        }

    }
}
