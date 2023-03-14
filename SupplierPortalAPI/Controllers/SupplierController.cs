﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace SupplierPortalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierServices _service;

        public SupplierController(ISupplierServices supplierServices)
        {
            _service= supplierServices;
        }

        [HttpPost("AddUpdateSupplier")]
        public string AddUpdateSupplier(SupplierDto supplierDto)
        {
            return _service.AddUpdateSupplier(supplierDto);
        }

        /*
         * 
         */

        [HttpPost("AddUpdateUser")]
        public string AddUpdateUser(UserDto userDto)
        {
            return _service.AddUpdateUser(userDto);
        }
    }
}
