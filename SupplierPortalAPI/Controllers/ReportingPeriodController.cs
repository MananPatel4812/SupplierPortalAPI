using BusinessLogic.ReferenceLookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.DTOs.ReadOnlyDTOs;
using Services.Interfaces;

namespace SupplierPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingPeriodController : ControllerBase
    {
        private IReportingPeriodServices _services;

        public ReportingPeriodController(IReportingPeriodServices services)
        {
            _services = services;
        }
        [HttpPost("AddReportingPeriod")]
        public async Task<string> AddReportingPeriod([FromForm]ReportingPeriodDto reportingPeriodDto, ReportingPeriodType reportingPeriodType, ReportingPeriodStatus reportingPeriodStatus)
        {
            //var reportingPeriodType = new ReportingPeriodType();
            //var reportingPeriodStatus = new ReportingPeriodStatus();
            return await _services.AddReportingPeriod(reportingPeriodDto,reportingPeriodType,reportingPeriodStatus);
        }

        [HttpPut("UpdateReportingPeriod")]
        public async Task<string> UpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
        {
            return await _services.UpdateReportingPeriod(reportingPeriodDto);
        }
    }
}
