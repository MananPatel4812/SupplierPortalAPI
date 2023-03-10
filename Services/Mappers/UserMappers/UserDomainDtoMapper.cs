using BusinessLogic.SupplierRoot.DomainModels;
using Services.DTOs;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.UserMappers
{
    public class UserDomainDtoMapper : IUserDomainDtoMapper
    {
        public List<UserDto> ConvertUsersToDtos(IEnumerable<User> users)
        {
            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                userDtos.Add(ConvertUserToDto(user));
            }
            return userDtos;
        }

        public UserDto ConvertUserToDto(User user)
        {
            return new UserDto(user.Id, user.Name, user.Email, user.ContactNo, user.RoleId, user.IsActive);
        }
    }
}
