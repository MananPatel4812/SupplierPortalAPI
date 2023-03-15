using BusinessLogic.ReferenceLookups;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces;

public interface IReportingPeriodServices
{

    /// <summary>
    /// Add Reporting Period
    /// </summary>
    /// <param name="reportingPeriodDto"></param>
    /// <returns></returns>
    Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto);

    /// <summary>
    /// Add Period Supplier
    /// </summary>
    /// <param name="reportingPeriodSupplierDto"></param>
    /// <returns></returns>
    Task<string> AddReportingPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto);
    




}                   