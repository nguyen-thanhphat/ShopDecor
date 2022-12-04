using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCart { get; set; }
        public User User { get; set; } = new User();
        public List<CartItem> CartItems { get; set; } = new();
        public int? IdUser { get; set; }
        public string? Ordered { get; set; }
        public string? OrderedOn { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
