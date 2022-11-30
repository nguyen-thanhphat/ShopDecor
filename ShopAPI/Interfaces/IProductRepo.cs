using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IProductRepo
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int idProduct);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
    }
}
