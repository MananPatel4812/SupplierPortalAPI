using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

namespace SupplierPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierServices _service;

        public SupplierController(ISupplierServices supplierServices)
        {
            _service= supplierServices;
        }

        /*[HttpPost("AddUpdateSupplier")]
        public string AddUpdateSupplier(SupplierDto supplierDto)
        {
            return _service.AddUpdateSupplier(supplierDto);
        }*/

        [HttpPost("AddUpdateUser")]
        public async Task<string> AddUpdateUser(UserDto userDto)
        {
            return await _service.AddUpdateUser(userDto);
        }
    }
}
