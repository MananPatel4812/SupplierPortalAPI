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
    private readonly IReportingPeriodFactory _reportingPeriodFactory;
    private readonly ILogger _logger;
    private readonly IReportingPeriodDomainDtoMapper _reportingPeriodDomainMapper;
    private readonly IReportingPeriodEntityDomainMapper _reportingPeriodEntityDomainMapper;
    private readonly IReportingPeriodDataActions _reportingPeriodDataActions;
    
    public ReportingPeriodServices(IReportingPeriodFactory reportingPeriodFactory, ILoggerFactory loggerFactory, IReportingPeriodDomainDtoMapper reportingPeriodDomainMapper, IReportingPeriodEntityDomainMapper reportingPeriodEntityDomainMapper,IReportingPeriodDataActions reportingPeriodDataActions)
    {
        _reportingPeriodFactory = reportingPeriodFactory;
        _logger = loggerFactory.CreateLogger<SupplierServices>();
        _reportingPeriodDomainMapper = reportingPeriodDomainMapper;
        _reportingPeriodEntityDomainMapper = reportingPeriodEntityDomainMapper;
        _reportingPeriodDataActions= reportingPeriodDataActions;
    }

    public Task<string> UpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
    {

        if (reportingPeriodDto == null)
            throw new Exception("ReportingPeriod details can not be null !");

        //Fetch record by id
        var reportingPeriod = RetrieveAndConvertReportingPeriod(reportingPeriodDto.Id ?? 0);
        
        reportingPeriod.UpdateReportingPeriod(reportingPeriod);

        //Convert domain to entity
        var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
        return reportingPeriodEntity;
    }

    private ReportingPeriod RetrieveAndConvertReportingPeriod(int reportingPeriodId)
    {
        var reportingPeriodEntity = _persister.GetReportingPeriodById(reportingPeriodId);
        if (reportingPeriodEntity == null)
            throw new ArgumentNullException("ReportingPeriod not found !");

        return ConfigureReportingPeriod(reportingPeriodEntity);
    }

    private ReportingPeriod ConfigureReportingPeriod(ReportingPeriodEntity reportingPeriodEntity)
    {
        //Convert entity to domain
        var reportingPeriodDomain = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity);
        return reportingPeriodDomain;
    }

    public async Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto,ReportingPeriodType reportingPeriodType,ReportingPeriodStatus reportingPeriodStatus)
    {
        var types = RetrieveReportingPeriodTypes();
        var reportingPeriod = _reportingPeriodFactory.CreateNewReportingPeriod(reportingPeriodType, reportingPeriodDto.CollectionTimePeriod, reportingPeriodStatus, reportingPeriodDto.StartDate,reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);
        var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
        _reportingPeriodDataActions.AddReportingPeriod(reportingPeriodEntity);
        return "Success";

    }
  
}
