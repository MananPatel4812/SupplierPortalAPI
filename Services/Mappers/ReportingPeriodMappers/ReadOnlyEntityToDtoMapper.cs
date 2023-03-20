using DataAccess.Entities;
using Services.DTOs.ReadOnlyDTOs;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.ReportingPeriodMappers
{
    public class ReadOnlyEntityToDtoMapper : IReadOnlyEntityToDtoMapper
    {
        public SupplierReportingPeriodDTO ConvertReportingPeriodSupplierEntityToSupplierReportingPeriodDTO(ReportingPeriodSupplierEntity reportingPeriodSupplierEntity)
        {
            return new SupplierReportingPeriodDTO(
                reportingPeriodSupplierEntity.Id,
                reportingPeriodSupplierEntity.SupplierId,
                reportingPeriodSupplierEntity.Supplier.Name,
                reportingPeriodSupplierEntity.ReportingPeriodId,
                reportingPeriodSupplierEntity.ReportingPeriod.DisplayName,
                reportingPeriodSupplierEntity.SupplierReportingPeriodStatusId,
                reportingPeriodSupplierEntity.SupplierReportingPeriodStatus.Name
                ) ;
        }
    }
}
