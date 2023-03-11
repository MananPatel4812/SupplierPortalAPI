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
        public async Task<string> AddReportingPeriod(ReportingPeriodDto reportingPeriodDto)
        {

            return await _services.AddReportingPeriod(reportingPeriodDto);
        }
    }
}
