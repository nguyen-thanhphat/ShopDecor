using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        public ShopDBContext _context;
        public CategoryRepo(ShopDBContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categorys.Any(c => c.IdCategory == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categorys.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categorys.Where(e => e.IdCategory == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
