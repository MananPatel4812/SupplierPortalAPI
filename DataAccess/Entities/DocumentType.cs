using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            FacilityRequiredDocumentTypes = new HashSet<FacilityRequiredDocumentType>();
            ReportingPeriodFacilityDocuments = new HashSet<ReportingPeriodFacilityDocument>();
            ReportingPeriodSupplierDocuments = new HashSet<ReportingPeriodSupplierDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<FacilityRequiredDocumentType> FacilityRequiredDocumentTypes { get; set; }
        public virtual ICollection<ReportingPeriodFacilityDocument> ReportingPeriodFacilityDocuments { get; set; }
        public virtual ICollection<ReportingPeriodSupplierDocument> ReportingPeriodSupplierDocuments { get; set; }
    }
}
