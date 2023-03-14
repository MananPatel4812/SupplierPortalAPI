using BusinessLogic.ReferenceLookups;
using DataAccess.Entities;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.ReportingPeriodMappers
{
    public class ReferenceLookupMapper : IReferenceLookUpMapper
    {
        public IEnumerable<ReportingPeriodStatus> GetReportingPeriodStatusesLookUp(IEnumerable<ReportingPeriodStatusEntity> reportingPeriodStatusEntities)
        {
            foreach (var item in reportingPeriodStatusEntities)
            {
                yield return new ReportingPeriodStatus(item.Id, item.Name);
            }
        }

        public IEnumerable<ReportingPeriodType> GetReportingPeriodTypesLookUp(IEnumerable<ReportingPeriodTypeEntity> reportingPeriodTypeEntities)
        {
            foreach (var item in reportingPeriodTypeEntities)
            {
                yield return new ReportingPeriodType(item.Id, item.Name);
            }
        }
    }
}
                