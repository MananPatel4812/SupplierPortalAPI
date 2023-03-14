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
    Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto);
    

}                   