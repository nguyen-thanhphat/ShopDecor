using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
