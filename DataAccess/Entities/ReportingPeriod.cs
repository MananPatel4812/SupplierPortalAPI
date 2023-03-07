using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriod
    {
        public ReportingPeriod()
        {
            ReportingPeriodSuppliers = new HashSet<ReportingPeriodSupplier>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public int ReportingPeriodTypeId { get; set; }
        public string CollectionTimePeriod { get; set; } = null!;
        public int ReportingPeriodStatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public virtual ReportingPeriodStatus ReportingPeriodStatus { get; set; } = null!;
        public virtual ReportingPeriodType ReportingPeriodType { get; set; } = null!;
        public virtual ICollection<ReportingPeriodSupplier> ReportingPeriodSuppliers { get; set; }
    }
}
