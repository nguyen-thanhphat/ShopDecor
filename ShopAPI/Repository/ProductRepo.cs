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

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(e => e.IdProduct == id).FirstOrDefault();
        }

        public async Task<Product> GetProductById(int idProduct)
        {
            try
            {
                Product? productFound = new Product();
                productFound = await _context.Products.Include(cat => cat.IdCategoryNavigation)
                                                      .Include(rom => rom.IdRoomNavigation)
                                                      .Include(ofe => ofe.IdOfferNavigation)
                    .Where(e => e.IdProduct == idProduct)
                    .FirstOrDefaultAsync();

                return productFound;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                List<Product> productList = new List<Product>();
                productList = await _context.Products.Include(cat => cat.IdCategoryNavigation)
                                                     .Include(rom => rom.IdRoomNavigation)
                                                     .Include(ofe => ofe.IdOfferNavigation)
                    .ToListAsync();

                return productList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(c => c.IdProduct == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
