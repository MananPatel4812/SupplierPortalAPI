using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriodFacility
    {
        public ReportingPeriodFacility()
        {
            ReportingPeriodFacilityDocuments = new HashSet<ReportingPeriodFacilityDocument>();
        }

        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int FacilityReportingPeriodDataStatusId { get; set; }
        public int ReportingTypeId { get; set; }
        public int ReportingPeriodSupplierId { get; set; }

        public virtual Facility Facility { get; set; } = null!;
        public virtual FacilityReportingPeriodDataStatus FacilityReportingPeriodDataStatus { get; set; } = null!;
        public virtual ReportingPeriodSupplier ReportingPeriodSupplier { get; set; } = null!;
        public virtual ReportingType ReportingType { get; set; } = null!;
        public virtual ICollection<ReportingPeriodFacilityDocument> ReportingPeriodFacilityDocuments { get; set; }
    }
}
