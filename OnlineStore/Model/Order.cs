using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProductId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Product? Product { get; set; }
    }
}
