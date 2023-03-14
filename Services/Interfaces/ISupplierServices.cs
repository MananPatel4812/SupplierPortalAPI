using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISupplierServices
    {
        string AddUpdateSupplier(SupplierDto supplierDto);
        /*
         * SupplierUserResultDto getSupplierDataForUsername();
         * SupplierDto GetSupplier(int sid)
         */
        string AddUpdateUser(UserDto userDto);
    }
}
