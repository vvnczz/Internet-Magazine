using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
