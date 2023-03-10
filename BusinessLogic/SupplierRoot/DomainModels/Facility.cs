
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SupplierRoot.DomainModels;

public class Facility
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsPrimary { get; private set; }
    public int? AssociatePipelineId { get; private set; }
    public int ReportingTypeId { get; private set; }
    public int SupplyChainStageId { get; private set; }
    /*
            AssociatePipeline AssociatePipelines { get; set; }
            ReportingType ReportingTypes { get; set; }
            SupplyChainStage SupplyChainStages { get; set; }*/


    internal Facility()
    { }

    internal Facility(string name, string description, bool isPrimary,
        int? associatePipelineId, int reportingTypeId, int supplyChainStageId)
    {
        Name = name;
        Description = description;
        IsPrimary = isPrimary;
        AssociatePipelineId = associatePipelineId;
        ReportingTypeId = reportingTypeId;
        SupplyChainStageId = supplyChainStageId;
    }

    internal Facility(int id, string name, string description, bool isPrimary,
        int? associatePipelineId, int reportingTypeId, int supplyChainStageId) : this(name, description, isPrimary, associatePipelineId, reportingTypeId, supplyChainStageId)
    {
        Id = id;
    }

}
