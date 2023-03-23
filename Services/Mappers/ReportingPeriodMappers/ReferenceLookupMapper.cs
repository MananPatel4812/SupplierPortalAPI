﻿using BusinessLogic.ReferenceLookups;
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
        public IEnumerable<FacilityReportingPeriodDataStatus> GetFacilityReportingPeriodDataStatusLookUp(IEnumerable<FacilityReportingPeriodDataStatusEntity> facilityReportingPeriodDataStatusEntities)
        {
            foreach (var item in facilityReportingPeriodDataStatusEntities)
            {
                yield return new FacilityReportingPeriodDataStatus(item.Id, item.Name);
            }
        }

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

        public IEnumerable<ReportingType> GetReportingTypeLookUp(IEnumerable<ReportingTypeEntity> reportingTypeEntities)
        {
            foreach (var item in reportingTypeEntities)
            {
                yield return new ReportingType(item.Id, item.Name);
            }
        }

        public IEnumerable<SupplierReportingPeriodStatus> GetSupplierReportingPeriodStatusesLookUp(IEnumerable<SupplierReportingPeriodStatusEntity> supplierReportingPeriodStatusEntities)
        {
            foreach (var item in supplierReportingPeriodStatusEntities)
            {
                yield return new SupplierReportingPeriodStatus(item.Id, item.Name);
            }
        }
    }
}
