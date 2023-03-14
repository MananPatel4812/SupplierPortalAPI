using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.Entities;

namespace Services.Mappers.Interfaces
{
    public interface IUserEntityDomainMapper
    {
        UserEntity ConvertUserDomainToEntity(User user);
        User ConvertUserEntityToDomain(UserEntity userEntity);

    }
}
