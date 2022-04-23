using System;
using System.Collections.Generic;

namespace Rocco.Domain.Entities
{
    public partial class Order_Subtotal
    {
        public int OrderID { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
