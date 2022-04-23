using System;
using System.Collections.Generic;

namespace Rocco.Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int RegionID { get; set; }
        public string RegionDescription { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
