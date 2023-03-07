using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.Interfaces
{
    public interface IReportingPeriod
    {
        int Id { get; set; }
        string DisplayName { get; set; }
        string CollectionTimePeriod { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        bool Active { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        string? UpdatedBy { get; set; }

        IEnumerable<ReportingPeriodType> ReportingPeriodType { get; }
        IEnumerable<ReportingPeriodStatus> ReportingPeriodStatus { get; }
        ReportingPeriodSupplier AddReportingPeriodSupplier(int id,int supplierId,int reportingPeriodId,int supplierReportingPeriodStatusId);
        ReportingPeriodFacility AddReportingPeriodFacility(int id,int facilityId,int facilityReportingPeriodDataStatusId,int reportingTypeId,int reportingPeriodSupplierId);

    }
}
