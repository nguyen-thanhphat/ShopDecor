using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Products = new HashSet<Product>();
        }

        public int IdOffer { get; set; }
        public string? Title { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
