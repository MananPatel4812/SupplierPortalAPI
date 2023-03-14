using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;

namespace Services.Mappers.Interfaces
{
    public interface ISupplierEntityDomainMapper
    {
        SupplierEntity ConvertSupplierDomainToEntity(Supplier supplier);
        Supplier ConvertSupplierEntityToDomain(SupplierEntity supplierEntity);

        /*
         * 
         */

    }
}
