using BusinessLogic.SupplierRoot.DomainModels;
using Services.DTOs;
using Services.Mappers.Interfaces;

namespace Services.Mappers.SupplierMappers
{
    public class SupplierDomainDtoMapper : ISupplierDomainDtoMapper
    {
        public SupplierDto ConvertSupplierDomainToDto(Supplier supplier)
        {
            var contactDtos = new List<ContactDto>();
            var facilityDtos = new List<FacilityDto>();
            foreach (var item in supplier.Contacts)
            {
                contactDtos.Add(new ContactDto(item.Id, item.SupplierId, item.UserVO.Id, item.UserVO.Name));
            }
            foreach (var item in supplier.Facilities)
            {
                facilityDtos.Add(new FacilityDto(item.Id, item.Name, item.Description, item.IsPrimary, item.AssociatePipelines.Id, item.AssociatePipelines.Name,item.ReportingTypes.Id, item.ReportingTypes.Name, item.SupplyChainStages.Id, item.SupplyChainStages.Name));
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

        /*
         * 
         * 
         */

    }
}
