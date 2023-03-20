namespace Services.DTOs.ReadOnlyDTOs;

public class ReportingPeriodActiveSupplierDTO
{
    public int ReportingPeriodSupplierId { get; set; }

    public int SupplierId { get; set; }

    public string SupplierName { get; set; }

    public int ReportingPeriodId { get; set; }

    public string ReportingPeriod { get; set; }

    public int SupplierReportingPeriodStatusId { get; set; }

    public string SupplierReportingPeriodStatus { get; set; }

    public ReportingPeriodActiveSupplierDTO(int reportingPeriodSupplierId, int supplierId,
        string supplierName, int reportingPeriodId, string reportingPeriod, int supplierReportingPeriodStatusId, string supplierReportingPeriodStatus)
    {
        ReportingPeriodSupplierId = reportingPeriodSupplierId;
        SupplierId = supplierId;
        SupplierName = supplierName;
        ReportingPeriodId = reportingPeriodId;
        ReportingPeriod= reportingPeriod;
        SupplierReportingPeriodStatusId = supplierReportingPeriodStatusId;
        SupplierReportingPeriodStatus = supplierReportingPeriodStatus;
    }


}
