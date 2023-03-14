using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using Services.Mappers.Interfaces;

namespace Services.Mappers.SupplierMappers
{
    public class SupplierEntityDomainMapper : ISupplierEntityDomainMapper
    {
        public SupplierEntity ConvertSupplierDomainToEntity(Supplier supplier)
        {
            return new SupplierEntity()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Alias = supplier.Alias,
                Email = supplier.Email,
                ContactNo = supplier.ContactNo,
                IsActive = supplier.IsActive
            };

            /*
             * var Facs = new List<FacEnt>();
             * foreach(var x in supplier.SupFacs)
             * {
             * }
             */
        }

        public Supplier ConvertSupplierEntityToDomain(SupplierEntity supplierEntity)
        {
            var supplier = new Supplier(supplierEntity.Id, supplierEntity.Name, supplierEntity.Alias, supplierEntity.Email, supplierEntity.ContactNo, supplierEntity.IsActive);
            return supplier;
        }
    }
}
