
using BusinessLogic.ReferenceLookups;
using BusinessLogic.SupplierRoot.ValueObjects;

namespace BusinessLogic.SupplierRoot.DomainModels;

public class Facility
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsPrimary { get; private set; }
    public int SupplierId { get; private set; }
    public string? GHGHRPFacilityId { get; private set; }
    public AssociatePipeline AssociatePipelines { get; private set; }
    public ReportingType ReportingTypes { get; private set; }
    public SupplyChainStage SupplyChainStages { get; private set; }

    internal Facility()
    { }

    internal Facility(string name, string description, bool isPrimary, int supplierId,
        AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage)
    {
        Name = name;
        Description = description;
        IsPrimary = isPrimary;
        SupplierId = supplierId;
        AssociatePipelines = associatePipeline;
        ReportingTypes = reportingType;
        SupplyChainStages = supplyChainStage;
    }

    internal Facility(int id, string name, string description, bool isPrimary, int supplierId,
        AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage) 
        : this(name, description, isPrimary, supplierId, associatePipeline, reportingType, supplyChainStage)
    {
        Id = id;
    }

}
