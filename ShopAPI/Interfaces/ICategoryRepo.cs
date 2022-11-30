using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface ICategoryRepo
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool CategoryExists(int id);
        bool Save();
    }
}
