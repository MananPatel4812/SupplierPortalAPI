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
    public async Task<string> AddUpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
    {
        if(reportingPeriodDto.Id == 0)
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
        }
        else
        {
            //Fetch record by id
            var reportingPeriod = RetrieveAndConvertReportingPeriod(reportingPeriodDto.Id ?? 0);
            reportingPeriod.UpdateReportingPeriod(reportingPeriodDto.ReportingPeriodTypeId,reportingPeriodDto.CollectionTimePeriod,reportingPeriodDto.ReportingPeriodStatusId,reportingPeriodDto.StartDate,reportingPeriodDto.EndDate,reportingPeriodDto.IsActive);

            //Convert domain to entity
            var entity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
            await _reportingPeriodDataActions.UpdateReportingPeriod(entity);
        }
        
        return "Success";
    }

    private ReportingPeriod RetrieveAndConvertReportingPeriod(int reportingPeriodId)
    {
        var reportingPeriodEntity = _reportingPeriodDataActions.GetReportingPeriodById(reportingPeriodId);
        var reportingPeriodTypes = GetAndConvertReportingPeriodType();
        var reportingPeriodStatus = GetAndConvertReportingPeriodStatus();

        if (reportingPeriodEntity is null)
            throw new ArgumentNullException("Unable to retrieve reporting period entity");

        return ConfigureReportingPeriod(reportingPeriodEntity,reportingPeriodTypes,reportingPeriodStatus);

    }

    private ReportingPeriod ConfigureReportingPeriod(ReportingPeriodEntity reportingPeriodEntity,IEnumerable<ReportingPeriodType> reportingPeriodTypes,IEnumerable<ReportingPeriodStatus> reportingPeriodStatuses)
    {
        var reportingPeriodType = reportingPeriodTypes.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodTypeId).ToList();
        var reportingPeriodStatus = reportingPeriodStatuses.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodStatusId).ToList();

        //Convert entity to domain
        var reportingPeriodDomain = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity, reportingPeriodType, reportingPeriodStatus);
        return reportingPeriodDomain;
    }
}
