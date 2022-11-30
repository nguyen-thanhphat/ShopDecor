namespace ShopAPI.DTOs
{
    public class PayMethodDTO
    {
        public int IdPayMethod { get; set; }
        public string? PayType { get; set; }
        public string? PayProvider { get; set; }
        public string? PayReason { get; set; }
        public bool? Available { get; set; }
    }
}
