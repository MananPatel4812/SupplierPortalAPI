using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.Interfaces
{
    public interface IUserDomainDtoMapper
    {
        UserDto ConvertUserToDto(User user);
        List<UserDto> ConvertUsersToDtos(IEnumerable<User> users);
    }
}
