using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class FacilityRequiredDocumentType
    {
        public int Id { get; set; }
        public int ReportingTypeId { get; set; }
        public int SupplyChainStageId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentRequiredStatusId { get; set; }

        public virtual DocumentRequiredStatus DocumentRequiredStatus { get; set; } = null!;
        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual ReportingType ReportingType { get; set; } = null!;
        public virtual SupplyChainStage SupplyChainStage { get; set; } = null!;
    }
}
