using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Customers = new List<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
