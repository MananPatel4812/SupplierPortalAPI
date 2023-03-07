using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriodType
    {
        public ReportingPeriodType()
        {
            ReportingPeriods = new HashSet<ReportingPeriod>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<ReportingPeriod> ReportingPeriods { get; set; }
    }
}
