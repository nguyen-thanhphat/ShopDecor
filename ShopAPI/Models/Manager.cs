using System;
using System.Collections.Generic;

namespace ShopAPI.Models
{
    public partial class Manager
    {
        public int IdAdmin { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
