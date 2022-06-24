using System;
using System.Collections.Generic;

namespace OnlineStore.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Post { get; set; }
        public string? Email { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
