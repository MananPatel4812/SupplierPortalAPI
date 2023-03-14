using BusinessLogic.SupplierRoot.DomainModels;
using Services.DTOs;
using Services.Factories.Interfaces;

namespace Services.Factories
{
    public class SupplierFactory : ISupplierFactory
    {
        public Supplier CreateNewSupplier(string name, string alias, string email, string contactNo, bool isActive)//, IEnumerable<FacilityDto> facilityDtos, IEnumerable<ContactDto> contactDtos)
        {
            var Supplier = new Supplier(name, alias, email, contactNo, isActive);//, facilityDtos, contactDtos);
            return Supplier;
        }
    }
}
