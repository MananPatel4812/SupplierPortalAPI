using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Facility
    {
        public Facility()
        {
            ReportingPeriodFacilities = new HashSet<ReportingPeriodFacility>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public int? AssociatePipelineId { get; set; }
        public int ReportingTypeId { get; set; }
        public int SupplyChainStageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public virtual AssociatePipeline? AssociatePipeline { get; set; }
        public virtual ReportingType ReportingType { get; set; } = null!;
        public virtual SupplyChainStage SupplyChainStage { get; set; } = null!;
        public virtual ICollection<ReportingPeriodFacility> ReportingPeriodFacilities { get; set; }
    }
}
