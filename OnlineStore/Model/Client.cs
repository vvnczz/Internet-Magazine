using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? Discount { get; set; }
    }
}
