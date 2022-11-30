namespace ShopAPI.DTOs
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }
        public int? IdCustommer { get; set; }
        public int? IdPayment { get; set; }
        public int? IdCart { get; set; }
        public string? CreateAt { get; set; }
    }
}
