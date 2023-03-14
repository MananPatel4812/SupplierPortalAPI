
using BusinessLogic.ReferenceLookups;

namespace BusinessLogic.SupplierRoot.DomainModels;

public class Facility
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsPrimary { get; private set; }

    /*public int? AssociatePipelineId { get; private set; }
    public int ReportingTypeId { get; private set; }
    public int SupplyChainStageId { get; private set; }*/

    public AssociatePipeline AssociatePipelines { get; private set; }
    public ReportingType ReportingTypes { get; private set; }
    public SupplyChainStage SupplyChainStages { get; private set; }

    internal Facility()
    { }

    internal Facility(string name, string description, bool isPrimary,
        AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage)
    {
        Name = name;
        Description = description;
        IsPrimary = isPrimary;
        AssociatePipelines = associatePipeline;
        ReportingTypes = reportingType;
        SupplyChainStages = supplyChainStage;
    }

    internal Facility(int id, string name, string description, bool isPrimary,
        AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage) : this(name, description, isPrimary, associatePipeline, reportingType, supplyChainStage)
    {
        Id = id;
    }

}
