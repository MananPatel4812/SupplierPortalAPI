using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.Factories.Interface;
using Services.Interfaces;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class ReportingPeriodServices : IReportingPeriodServices
{
    private IReportingPeriodFactory _reportingPeriodFactory;
    private readonly ILogger _logger;
    private IReportingPeriodDomainDtoMapper _reportingPeriodDomainMapper;
    private IReportingPeriodEntityDomainMapper _reportingPeriodEntityDomainMapper;
    private IReportingPeriodDataActions _reportingPeriodDataActions;
    private IReferenceLookUpMapper _referenceLookUpMapper;
    private IReportingPeriod _reportingPeriod;

    public ReportingPeriodServices(IReportingPeriodFactory reportingPeriodFactory, ILoggerFactory loggerFactory, IReportingPeriodDomainDtoMapper reportingPeriodDomainMapper, IReportingPeriodEntityDomainMapper reportingPeriodEntityDomainMapper, IReportingPeriodDataActions reportingPeriodDataActions, IReferenceLookUpMapper referenceLookUpMapper,IReportingPeriod reportingPeriod)
    {
        _reportingPeriodFactory = reportingPeriodFactory;
        _logger = loggerFactory.CreateLogger<SupplierServices>();
        _reportingPeriodDomainMapper = reportingPeriodDomainMapper;
        _reportingPeriodEntityDomainMapper = reportingPeriodEntityDomainMapper;
        _reportingPeriodDataActions = reportingPeriodDataActions;
        _referenceLookUpMapper = referenceLookUpMapper;
        _reportingPeriod = reportingPeriod;

    }
    private IEnumerable<ReportingPeriodType> GetAndConvertReportingPeriodType()
    {
        var reportingPeriodTypeEntity = _reportingPeriodDataActions.GetReportingPeriodTypes();

        return _referenceLookUpMapper.GetReportingPeriodTypesLookUp(reportingPeriodTypeEntity);
    }

    private IEnumerable<ReportingPeriodStatus> GetAndConvertReportingPeriodStatus()
    {
        var reportingPeriodStatusEntity = _reportingPeriodDataActions.GetReportingPeriodStatus();

        return _referenceLookUpMapper.GetReportingPeriodStatusesLookUp(reportingPeriodStatusEntity);
    }

    private IEnumerable<SupplierReportingPeriodStatus> GetAndConvertSupplierPeriodStatus()
    {
        var supplierPeriodStatusEntity = _reportingPeriodDataActions.GetSupplierReportingPeriodStatus();

        return _referenceLookUpMapper.GetSupplierReportingPeriodStatusesLookUp(supplierPeriodStatusEntity);
    }
    public async Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto)
    {

        var reportingPeriodTypes = GetAndConvertReportingPeriodType().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodTypeId);
        var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodStatusId);

        if (reportingPeriodStatuses is null)
            throw new Exception("Unable to retrieve reporting period Status for the identifier");

        if (reportingPeriodTypes is null)
            throw new Exception("Unable to retrieve reporting period Status for the identifier");

        var reportingPeriod = _reportingPeriodFactory.CreateNewReportingPeriod(reportingPeriodTypes, reportingPeriodDto.CollectionTimePeriod, reportingPeriodStatuses, reportingPeriodDto.StartDate, reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);

        var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
        await _reportingPeriodDataActions.AddReportingPeriod(reportingPeriodEntity);
        return "Success";
    }

    public async Task<string> AddReportingPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto)
    {
        var reportingPeriodSupplierStatus = GetAndConvertSupplierPeriodStatus().FirstOrDefault(x => x.Id == reportingPeriodSupplierDto.SupplierReportingPeriodStatusId);

        if (reportingPeriodSupplierStatus is null)
            throw new Exception("Unable to retrieve reporting period supplier status for the identifier");

        var periodSupplier = _reportingPeriod.AddPeriodSupplier();


        return "Success";
    }
}
