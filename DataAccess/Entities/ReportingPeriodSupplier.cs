using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriodSupplier
    {
        public ReportingPeriodSupplier()
        {
            ReportingPeriodFacilities = new HashSet<ReportingPeriodFacility>();
            ReportingPeriodSupplierDocuments = new HashSet<ReportingPeriodSupplierDocument>();
        }

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ReportingPeriodId { get; set; }
        public int SupplierReportingPeriodStatusId { get; set; }

        public virtual ReportingPeriod ReportingPeriod { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual SupplierReportingPeriodStatus SupplierReportingPeriodStatus { get; set; } = null!;
        public virtual ICollection<ReportingPeriodFacility> ReportingPeriodFacilities { get; set; }
        public virtual ICollection<ReportingPeriodSupplierDocument> ReportingPeriodSupplierDocuments { get; set; }
    }
}
