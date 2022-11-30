using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }

        public int IdPayMethod { get; set; }
        public string? PayType { get; set; }
        public string? PayProvider { get; set; }
        public string? PayReason { get; set; }
        public bool? Available { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
