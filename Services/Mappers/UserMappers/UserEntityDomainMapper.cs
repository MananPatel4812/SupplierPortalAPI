using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.Entities;
using Services.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers.UserMappers
{
    public class UserEntityDomainMapper: IUserEntityDomainMapper
    {
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
