using BusinessLogic.ReferenceLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects;

public class FacilityVO
{
    public FacilityVO(int id,int supplierid,string facilityname,string? GHGRPFacilityid,bool active,SupplyChainStage supplyChainStage=null, ReportingType reportingType=null) {
        
        Id = id;
        SupplierId= supplierid;
        FacilityName= facilityname;
        GHGRPFacilityId = GHGRPFacilityid;
        IsActive= active;
        SupplyChainStage = supplyChainStage ?? null;
        ReportingType = reportingType ?? null;
    
    }

    public int Id { get; private set; }

    public int SupplierId { get; private set; }

    public string FacilityName { get; private set; }

    public string? GHGRPFacilityId { get;private set; }

    public bool IsActive { get; private set; }

    public SupplyChainStage? SupplyChainStage { get; private set;}

    public  ReportingType? ReportingType { get;private set; }
}
