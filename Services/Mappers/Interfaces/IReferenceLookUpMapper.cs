using BusinessLogic.ReferenceLookups;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.Interfaces;

public interface IReferenceLookUpMapper
{
    IEnumerable<ReportingPeriodType> GetReportingPeriodTypesLookUp(IEnumerable<ReportingPeriodTypeEntity> reportingPeriodTypeEntities);
    IEnumerable<ReportingPeriodStatus> GetReportingPeriodStatusesLookUp(IEnumerable<ReportingPeriodStatusEntity> reportingPeriodStatusEntities);
}
