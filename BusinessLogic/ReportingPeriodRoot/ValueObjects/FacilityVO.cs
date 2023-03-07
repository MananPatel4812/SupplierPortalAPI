using BusinessLogic.ReferenceLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects;

public class FacilityVO
{
    public FacilityVO(int id,int supllierid,string facilityname,string? GHGRPFacilityid,bool active,SupplyChainStage supplyChainStage=null, ReportingType reportingType=null) {
        
        Id = id;
        SupplierId= supllierid;
        Facilityname= facilityname;
        GHGRPFacilityid = GHGRPFacilityid;
        Isactive= active;
        SupplyChainStage = supplyChainStage ?? null;
        ReportingType = reportingType ?? null;
    
    }

    public int Id { get; private set; }

    public int SupplierId { get; private set; }

    public string Facilityname { get; private set; }

    public string? GHGRPFacilityid { get;private set; }

    public bool Isactive { get; private set; }

    public SupplyChainStage? SupplyChainStage { get; private set;}

    public  ReportingType? ReportingType { get;private set; }
}
