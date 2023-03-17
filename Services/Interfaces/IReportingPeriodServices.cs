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
    /// Add PeriodSupplier
    /// </summary>
    /// <param name="reportingPeriodSupplierDto"></param>
    /// <returns></returns>
    Task<string> SetPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto);

    /// <summary>
    /// Add Reporting Period
    /// </summary>
    /// <param name="reportingPeriodDto"></param>
    /// <returns></returns>
    Task<string> AddUpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto);
}                   