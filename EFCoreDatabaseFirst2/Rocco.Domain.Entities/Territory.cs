using System;
using System.Collections.Generic;

namespace Rocco.Domain.Entities
{
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public string TerritoryID { get; set; } = null!;
        public string TerritoryDescription { get; set; } = null!;
        public int RegionID { get; set; }

        public virtual Region Region { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
