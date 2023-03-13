using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class ReportingPeriodServices : IReportingPeriodServices
{
    private IReportingPeriodDataActions _persister;
    public ReportingPeriodServices(IReportingPeriodDataActions persister)
    {
        _persister = persister;
    }
    public Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto)
    {
        throw new NotImplementedException();
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
}
