using BusinessLogic.SupplierRoot.DomainModels;
using Services.DTOs;

namespace Services.Mappers.Interfaces
{
    public interface ISupplierDomainDtoMapper
    {
        SupplierDto ConvertSupplierDomainToDto(Supplier supplier);
        List<SupplierDto> ConvertSuppliersToDtos(IEnumerable<Supplier> suppliers);
    }
}
