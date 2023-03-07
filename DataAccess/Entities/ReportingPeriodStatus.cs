using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriodStatus
    {
        public ReportingPeriodStatus()
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
