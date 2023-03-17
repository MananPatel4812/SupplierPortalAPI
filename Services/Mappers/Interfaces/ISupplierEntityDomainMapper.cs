using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.Entities;
using Services.DTOs;

namespace Services.Mappers.Interfaces
{
    public interface ISupplierEntityDomainMapper
    {
        SupplierEntity ConvertSupplierDomainToEntity(Supplier supplier);
        Supplier ConvertSupplierEntityToDomain(SupplierEntity supplierEntity);
        ContactEntity ConvertContactDomainToEntity(Contact contact);
        IEnumerable<Supplier> ConvertSuppliersListEntityToDomain(IEnumerable<SupplierEntity> supplierEntities);

    }
}
