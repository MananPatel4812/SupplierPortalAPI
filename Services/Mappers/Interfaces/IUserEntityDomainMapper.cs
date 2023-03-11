using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.Interfaces
{
    public interface IUserEntityDomainMapper
    {
        UserEntity ConvertUserToEntity(User user);
        User ConvertUserEntityToDomain(UserEntity userEntity);
    }
}
