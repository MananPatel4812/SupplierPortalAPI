using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class FacilityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
        public int? AssociatePipelineId { get; set; }
        public string? AssociatePipelineName { get; set; }
        public int ReportingTypeId { get; set; }
        public string ReportingTypeName { get; set; }
        public int SupplyChainStageId { get; set; }
        public string SupplyChainStageName { get; set; }
        public FacilityDto(int id, string name, string description, bool isPrimary,
            int? associatePipelineId, string? associatePipelineName,
            int reportingTypeId, string reportingTypeName,
            int supplyChainStageId, string supplyChainStageName ) 
        { 
            Id = id;
            Name = name;
            Description = description;
            IsPrimary = isPrimary;
            AssociatePipelineId = associatePipelineId;
            AssociatePipelineName = associatePipelineName;
            ReportingTypeId = reportingTypeId;
            ReportingTypeName = reportingTypeName;
            SupplyChainStageId = supplyChainStageId;
            SupplyChainStageName = supplyChainStageName;
        }
    }
}
