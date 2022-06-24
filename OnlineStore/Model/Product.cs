using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
