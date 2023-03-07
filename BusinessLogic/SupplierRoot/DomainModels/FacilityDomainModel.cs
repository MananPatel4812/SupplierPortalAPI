using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.DomainModels
{
    public class FacilityDomainModel
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Description { get; set; }
         public bool IsPrimary { get; set; }
         public int? AssociatePipelineId { get; set; }
         public int ReportingTypeId { get; set; }
         public int SupplyChainStageId { get; set; }

        AssociatePipeline AssociatePipelines { get; set; }
        ReportingType ReportingTypes { get; set; }
        SupplyChainStage SupplyChainStages { get; set; }


        public FacilityDomainModel()
        {   }

        public FacilityDomainModel(string name, string description, bool isPrimary,
            int? associatePipelineId, int reportingTypeId, int supplyChainStageId )
        {
            Name = name;
            Description = description;
            IsPrimary = isPrimary;
            AssociatePipelineId = associatePipelineId;
            ReportingTypeId = reportingTypeId;
            SupplyChainStageId = supplyChainStageId;
        }

        public FacilityDomainModel(int id, string name, string description, bool isPrimary,
            int? associatePipelineId, int reportingTypeId, int supplyChainStageId): this(name, description,isPrimary,associatePipelineId,reportingTypeId,supplyChainStageId)
        {
            Id = id;   
        }

    }

    
}
