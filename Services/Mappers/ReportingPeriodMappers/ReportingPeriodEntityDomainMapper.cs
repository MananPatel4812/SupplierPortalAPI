using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using DataAccess.Entities;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.ReportingPeriodMappers;

public class ReportingPeriodEntityDomainMapper : IReportingPeriodEntityDomainMapper
{
    public ReportingPeriodEntity ConvertReportingPeriodDomainToEntity(ReportingPeriod reportingPeriod)
    {

        var reportingPeriodSupplier = ConvertReportingPeriodSuppliersDomainToEntity(reportingPeriod.PeriodSuppliers ?? new List<PeriodSupplier>());

        return new ReportingPeriodEntity() {

            Id = reportingPeriod.Id,
            DisplayName = reportingPeriod.DisplayName,
            ReportingPeriodTypeId = reportingPeriod.ReportingPeriodType.Id,
            CollectionTimePeriod = reportingPeriod.CollectionTimePeriod,
            ReportingPeriodStatusId = reportingPeriod.ReportingPeriodStatus.Id,
            StartDate = reportingPeriod.StartDate,
            EndDate = reportingPeriod.EndDate,
            IsActive = reportingPeriod.IsActive,
            ReportingPeriodSupplierEntities = reportingPeriodSupplier.ToList(),
        };
    }

    public ReportingPeriod ConvertReportingPeriodEntityToDomain(ReportingPeriodEntity reportingPeriodEntity, IEnumerable<ReportingPeriodType> reportingPeriodTypes, IEnumerable<ReportingPeriodStatus> reportingPeriodStatuses)
    {
        var reportingPeriodSelectedType = reportingPeriodTypes.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodTypeId).FirstOrDefault();
        var reportingPeriodSelectedStatus = reportingPeriodStatuses.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodStatusId).FirstOrDefault();

        var reportingPeriod = new ReportingPeriod(reportingPeriodEntity.Id, reportingPeriodEntity.DisplayName, reportingPeriodSelectedType, reportingPeriodEntity.CollectionTimePeriod, reportingPeriodSelectedStatus, reportingPeriodEntity.StartDate, reportingPeriodEntity.EndDate, reportingPeriodEntity.IsActive);
        return reportingPeriod;

    }

    public ReportingPeriodSupplierEntity ConvertReportingPeriodSupplierDomainToEntity(PeriodSupplier periodSupplier)
    {
        return new ReportingPeriodSupplierEntity()
        {
            Id = periodSupplier.Id,
            SupplierId = periodSupplier.SupplierVO.Id,
            ReportingPeriodId = periodSupplier.ReportingPeriodId,
            SupplierReportingPeriodStatusId = periodSupplier.SupplierReportingPeriodStatusId
        };
    }

    public IEnumerable<ReportingPeriodSupplierEntity> ConvertReportingPeriodSuppliersDomainToEntity(IEnumerable<PeriodSupplier> periodSuppliers)
    {
        var suppliers = new List<ReportingPeriodSupplierEntity>();
        foreach (var periodSupplier in periodSuppliers)
        {
            suppliers.Add(ConvertReportingPeriodSupplierDomainToEntity(periodSupplier));
        }
        return suppliers;
    }
}
