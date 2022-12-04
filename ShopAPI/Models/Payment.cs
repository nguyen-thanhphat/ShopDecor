using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPayment { get; set; }
        public int? IdUser { get; set; }
        public int? IdPayMethod { get; set; }
        public int? TotalAmount { get; set; }
        public int? ShippingCharges { get; set; }
        public int? AmountReduced { get; set; }
        public int? AmountPaid { get; set; }
        public string? CreateAt { get; set; }

        public virtual PaymentMethod? IdPayMethodNavigation { get; set; } = new PaymentMethod(); 
        public virtual User? IdUserNavigation { get; set; } = new User();
        public virtual ICollection<Order> Orders { get; set; }
    }
}
