using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.Entities;
using Services.DTOs;
using Services.Mappers.Interfaces;

namespace Services.Mappers.SupplierMappers
{
    public class SupplierEntityDomainMapper : ISupplierEntityDomainMapper
    {
        public ContactEntity ConvertContactDomainToEntity(Contact contact)
        {
            return new ContactEntity 
            { 
                Id = contact.Id, 
                SupplierId =  contact.SupplierId, 
                UserId = contact.UserVO.Id 
            };
        }

        public SupplierEntity ConvertSupplierDomainToEntity(Supplier supplier)
        {
            var entity = new SupplierEntity()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Alias = supplier.Alias,
                Email = supplier.Email,
                ContactNo = supplier.ContactNo,
                IsActive = supplier.IsActive
            };

            var supplierContacts = new List<ContactEntity>();
            foreach(var contact in supplier.Contacts ) 
            {
                var contactEntity = new ContactEntity();
                contactEntity.Id = contact.Id;
                contactEntity.SupplierId = contact.SupplierId;
                contactEntity.UserId = contact.UserVO.Id;

                supplierContacts.Add(contactEntity);
            }

            entity.ContactEntities = supplierContacts;

            return entity;
        }

        public Supplier ConvertSupplierEntityToDomain(SupplierEntity supplierEntity)
        {
            var supplier = new Supplier(supplierEntity.Id, supplierEntity.Name, supplierEntity.Alias, supplierEntity.Email, supplierEntity.ContactNo, supplierEntity.IsActive);

            foreach (var contact in supplierEntity.ContactEntities)
            {
                var userVO = new UserVO(contact.User.Id, contact.User.Name, contact.User.Email, contact.User.ContactNo, contact.User.RoleId, contact.User.IsActive);

                supplier.AddSupplierContact(contact.Id, supplier, userVO);
            }

            return supplier;

        }


        public IEnumerable<Supplier> ConvertSuppliersListEntityToDomain(IEnumerable<SupplierEntity> supplierEntities)
        {
            var list = new List<Supplier>();
            foreach (var entity in supplierEntities)
            {
                list.Add(ConvertSupplierEntityToDomain(entity));
            }

            return list;
        }
    }
}
