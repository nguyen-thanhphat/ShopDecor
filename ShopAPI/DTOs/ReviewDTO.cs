namespace ShopAPI.DTOs
{
    public class ReviewDTO
    {
        public int IdReview { get; set; }
        public int? IdReviewer { get; set; }
        public int? IdProduct { get; set; }
        public string? Review1 { get; set; }
        public int? Rating { get; set; }
        public string? CreateAt { get; set; }
    }
}
