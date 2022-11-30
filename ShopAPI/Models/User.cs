using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Reviews = new HashSet<Review>();
        }

        public int IdUser { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? CreateAt { get; set; }
        public string? ModifieAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
