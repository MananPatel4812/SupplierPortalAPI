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

        #region Add-Update Methods

        [HttpPost("AddReportingPeriod")]
        public async Task<string> AddUpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
        {
            return await _services.AddUpdateReportingPeriod(reportingPeriodDto);
        }
        [HttpPost("AddPeriodSupplier")]
        public async Task<string> SetPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto)
        {
            return await _services.SetPeriodSupplier(reportingPeriodSupplierDto);
        }
        #endregion

        #region Get All Methods

        /*[HttpGet("GetActiveReportingPeriod")]
        public IEnumerable<InternalReportingPeriodDTO> GetActiveReportingPeriod()
        {
            return _services.GetActiveReportingPeriod();
        }*/

        #endregion



    }
}
