using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Room
    {
        public Room()
        {
            Products = new HashSet<Product>();
        }

        public int IdRoom { get; set; }
        public string? RoomName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
