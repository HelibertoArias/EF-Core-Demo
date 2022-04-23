using System;
using System.Collections.Generic;

namespace Rocco.Domain.Entities
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            Customers = new HashSet<Customer>();
        }

        public string CustomerTypeID { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
