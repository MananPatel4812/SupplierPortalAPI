using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodFRoot.DomainModels
{
    public class ReportingPeriodFacilityDomainModel
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int FacilityReportingPeriodDataStatusId { get; set; }
        public int ReportingTypeId { get; set; }
        public int ReportingPeriodSupplierId { get; set; }

        public ReportingPeriodFacilityDomainModel(int id,int facilityId,int facilityReportingPeriodDataStatusId,int reportingTypeId,int reportingPeriodSupplierId)
        {
            Id = id;
        }
    }
}
