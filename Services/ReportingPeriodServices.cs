using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
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

    public ReportingPeriodServices(IReportingPeriodFactory reportingPeriodFactory, ILoggerFactory loggerFactory, IReportingPeriodDomainDtoMapper reportingPeriodDomainMapper, IReportingPeriodEntityDomainMapper reportingPeriodEntityDomainMapper, IReportingPeriodDataActions reportingPeriodDataActions, IReferenceLookUpMapper referenceLookUpMapper)
    {
        _reportingPeriodFactory = reportingPeriodFactory;
        _logger = loggerFactory.CreateLogger<SupplierServices>();
        _reportingPeriodDomainMapper = reportingPeriodDomainMapper;
        _reportingPeriodEntityDomainMapper = reportingPeriodEntityDomainMapper;
        _reportingPeriodDataActions = reportingPeriodDataActions;
        _referenceLookUpMapper = referenceLookUpMapper;

    }

    //public async Task<string> UpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
    //{

    //    if (reportingPeriodDto == null)
    //        throw new Exception("ReportingPeriod details can not be null !");

    //    //Fetch record by id
    //    var reportingPeriod = RetrieveAndConvertReportingPeriod(reportingPeriodDto.Id ?? 0);

    //    reportingPeriod.UpdateReportingPeriod(reportingPeriod);

    //    //Convert domain to entity
    //    var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
    //    return reportingPeriodEntity;
    //}

    private ReportingPeriod RetrieveAndConvertReportingPeriod(int reportingPeriodId)
    {
        var reportingPeriodEntity = _reportingPeriodDataActions.GetReportingPeriodById(reportingPeriodId);
        if (reportingPeriodEntity == null)
            throw new ArgumentNullException("ReportingPeriod not found !");

        return ConfigureReportingPeriod(reportingPeriodEntity);
    }

    private ReportingPeriod ConfigureReportingPeriod(ReportingPeriodEntity reportingPeriodEntity)
    {
        //Convert entity to domain
        //var reportingPeriodDomain = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity);
        //return reportingPeriodDomain;

        return null;
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

}
