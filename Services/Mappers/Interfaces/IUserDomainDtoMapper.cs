using BusinessLogic.SupplierRoot.DomainModels;
using Services.DTOs;

namespace Services.Mappers.Interfaces
{
    public interface IUserDomainDtoMapper
    {
        UserDto ConvertUserDomainToDto(User user);
        List<UserDto> ConvertUsersToDtos(IEnumerable<User> users);
    }
}
