using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface ISupplierServices
    {
        string AddUpdateSupplier(SupplierDto supplierDto);
        IEnumerable<SupplierDto> GetAllSuppliers();
        /*
         * SupplierUserResultDto getSupplierDataForUsername();
         * SupplierDto GetSupplier(int sid)
         */

        string AddUpdateContact(ContactDto contactDto);
    }
}
