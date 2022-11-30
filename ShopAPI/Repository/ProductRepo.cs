using Microsoft.EntityFrameworkCore;
using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ShopDBContext _context;
        public ProductRepo(ShopDBContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int idProduct)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
