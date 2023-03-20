using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using Services.DTOs;
using Services.Mappers.Interfaces;

namespace Services.Mappers.SupplierMappers
{
    public class SupplierDomainDtoMapper : ISupplierDomainDtoMapper
    {
        /* public Contact ConvertContactDtoToDomain(ContactDto contactDto)
            {
                var userVO = new UserVO(contactDto.UserId, contactDto.UserName, contactDto.UserEmail, contactDto.UserContactNo, contactDto.RoleId, contactDto.IsActive);
                var contact = new Contact(contactDto.Id, contactDto.SupplierId, userVO);
            }
        */
        public SupplierDto ConvertSupplierDomainToDto(Supplier supplier)
        {
            var contactDtos = new List<ContactDto>();
            var facilityDtos = new List<FacilityDto>();
            foreach (var item in supplier.Contacts)
            {
                contactDtos.Add(new ContactDto(item.Id, item.SupplierId, supplier.Name, item.UserVO.Id, item.UserVO.Name, item.UserVO.Email, item.UserVO.ContactNo,  item.UserVO.IsActive));
            }
            foreach (var item in supplier.Facilities)
            {
                facilityDtos.Add(new FacilityDto(item.Id, item.Name, item.Description, item.IsPrimary, item.SupplierId, supplier.Name,item.GHGHRPFacilityId, item.AssociatePipelines.Id, item.AssociatePipelines.Name,item.ReportingTypes.Id, item.ReportingTypes.Name, item.SupplyChainStages.Id, item.SupplyChainStages.Name));
            }
            return new SupplierDto(supplier.Id, supplier.Name, supplier.Alias, supplier.Email, supplier.ContactNo, supplier.IsActive, facilityDtos, contactDtos);
        }

        public List<SupplierDto> ConvertSuppliersToDtos(IEnumerable<Supplier> suppliers)
        {
            var supplierDtos = new List<SupplierDto>();
            foreach (var supplier in suppliers)
            {
                supplierDtos.Add(ConvertSupplierDomainToDto(supplier));
            }
            return supplierDtos;
        }

    }
}
