using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Supply
    {
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? DateSupply { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
