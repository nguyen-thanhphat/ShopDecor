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
        public int? IdUser { get; set; }
        public string? Ordered { get; set; }
        public string? OrderedOn { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
