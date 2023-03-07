using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class SupplierReportingPeriodStatus
    {
        public SupplierReportingPeriodStatus()
        {
            ReportingPeriodSuppliers = new HashSet<ReportingPeriodSupplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<ReportingPeriodSupplier> ReportingPeriodSuppliers { get; set; }
    }
}
