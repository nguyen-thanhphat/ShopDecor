using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Review
    {
        public int IdReview { get; set; }
        public int? IdReviewer { get; set; }
        public int? IdProduct { get; set; }
        public string? Review1 { get; set; }
        public int? Rating { get; set; }
        public string? CreateAt { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual User? IdReviewerNavigation { get; set; }
    }
}
