using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using Services.Mappers.Interfaces;

namespace Services.Mappers.UserMappers
{
    public class UserEntityDomainMapper: IUserEntityDomainMapper
    {
        public User ConvertUserEntityToDomain(UserEntity userEntity)
        {
            var user = new User(userEntity.Id, userEntity.Name, userEntity.Email, userEntity.ContactNo, userEntity.RoleId, userEntity.IsActive);
            return user;
        }

        public UserEntity ConvertUserToEntity(User user)
        {
            var entity = new UserEntity();
            entity.Id = user.Id;
            entity.Name = user.Name;
            entity.Email = user.Email;
            entity.ContactNo = user.ContactNo;
            entity.RoleId = user.RoleId;
            entity.IsActive= user.IsActive;

            return entity;
        }
    }
}
