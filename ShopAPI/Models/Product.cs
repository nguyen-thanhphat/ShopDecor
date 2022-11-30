using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Reviews = new HashSet<Review>();
        }

        public int IdProduct { get; set; }
        public string? ProductTile { get; set; }
        public string? ProductDescription { get; set; }
        public int? IdCategory { get; set; }
        public int? IdOffer { get; set; }
        public int? IdRoom { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ImageName { get; set; }
        public string? Material { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public virtual Offer? IdOfferNavigation { get; set; }
        public virtual Room? IdRoomNavigation { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
