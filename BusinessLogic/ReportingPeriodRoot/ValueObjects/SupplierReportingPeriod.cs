using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects;

public class SupplierReportingPeriod
{
    public int ReportingPeriodSupplierId { get; set; }

    public SupplierVO SupplierVO { get; set; }

    public SupplierReportingPeriodStatus SupplierPeriodStatus { get; set;}

    public bool IsActive { get; set; }

    public int PeriodId { get; set; }

    public string PeriodName { get; set; }

    public DateTime OpenDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public string CollectionTimePeriod { get; set; }

    public bool PeriodIsActive { get; set; }    

    public ReportingPeriodType PeriodType { get; set; }

    public ReportingPeriodStatus PeriodStatus { get; set; }

    public PeriodSupplierDocument SupplementDataDocument { get; set; }

    public SupplierReportingPeriod(int reportingPeriodSupplierId, SupplierVO supplierVO, SupplierReportingPeriodStatus supplierPeriodStatus, bool isActive, int periodId, string periodName, DateTime openDate, DateTime? closeDate, string collectionTimePeriod, bool periodIsActive, ReportingPeriodType periodType, ReportingPeriodStatus periodStatus, PeriodSupplierDocument supplementDataDocument)
    {
        ReportingPeriodSupplierId = reportingPeriodSupplierId;
        SupplierVO = supplierVO;
        SupplierPeriodStatus = supplierPeriodStatus;
        IsActive = isActive;
        PeriodId = periodId;
        PeriodName = periodName;
        OpenDate = openDate;
        CloseDate = closeDate;
        CollectionTimePeriod = collectionTimePeriod;
        PeriodIsActive = periodIsActive;
        PeriodType = periodType;
        PeriodStatus = periodStatus;
        SupplementDataDocument = supplementDataDocument;
    }
}
