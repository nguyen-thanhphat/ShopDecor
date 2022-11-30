namespace ShopAPI.DTOs
{
    public class ProductDTO
    {
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
    }
}
