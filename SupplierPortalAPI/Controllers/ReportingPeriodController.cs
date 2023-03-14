﻿using BusinessLogic.ReferenceLookups;
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
       
        [HttpPut("UpdateReportingPeriod")]
        public async Task<string> UpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)
        {
            return await _services.UpdateReportingPeriod(reportingPeriodDto);
        }
    }
}
