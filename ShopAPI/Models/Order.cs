using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int? IdCustommer { get; set; }
        public int? IdPayment { get; set; }
        public int? IdCart { get; set; }
        public string? CreateAt { get; set; }

        public virtual Cart? IdCartNavigation { get; set; }
        public virtual User? IdCustommerNavigation { get; set; }
        public virtual Payment? IdPaymentNavigation { get; set; }
    }
}
