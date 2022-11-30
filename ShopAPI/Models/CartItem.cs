using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class CartItem
    {
        public int IdCartItem { get; set; }
        public int? IdCart { get; set; }
        public int? IdProduct { get; set; }
    }
}
