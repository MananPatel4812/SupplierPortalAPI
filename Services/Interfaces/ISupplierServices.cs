using Services.DTOs;

namespace Services.Interfaces
{
    public interface ISupplierServices
    {
        string AddUpdateSupplier(SupplierDto supplierDto);
        IEnumerable<SupplierDto> GetAllSuppliers();
        SupplierDto GetSupplierById(int supplierId);
        string AddUpdateContact(ContactDto contactDto);
    }
}
