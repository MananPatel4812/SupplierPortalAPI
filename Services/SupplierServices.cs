using BusinessLogic.SupplierRoot.DomainModels;
using DataAccess.DataActions.Interfaces;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.Factories.Interface;
using Services.Interfaces;
using Services.Mappers.Interfaces;

namespace Services
{
    public class SupplierServices : ISupplierServices
    {
        private IUserFactory _userFactory;
        private readonly ILogger _logger;
        private IUserEntityDomainMapper _userEntityDomainMapper;
        private IUserPersister _persister;

        public SupplierServices(ILoggerFactory loggerFactory, IUserFactory userFactory, IUserEntityDomainMapper userEntityDomainMapper, IUserPersister persister) 
        { 
            _logger = loggerFactory.CreateLogger<SupplierServices>();
            _userFactory= userFactory;
            _userEntityDomainMapper = userEntityDomainMapper;
            _persister = persister;
        }

        public async Task<string> AddUpdateUser(UserDto userDto)
        {
            if(userDto == null) throw new Exception("User details cannot be null !!");

            //add user
            if(userDto.Id == 0)
            {
                var user = _userFactory.CreateNewUser(userDto.Name, userDto.Email, userDto.ContactNo, userDto.RoleId, userDto.IsActive);
                var entity = _userEntityDomainMapper.ConvertUserToEntity(user);
                _persister.AddUser(entity);
            }
            /*else
            {
                //var user = Retrieve
                
            }*/

            return "success";
        }

       /* private User RetrieveAndConvertUser(int userId)
        {
            var userEntity = _persister.GetUserById(userId);
            *//*if(userEntity == null ) 
            {
                throw new Exception("User rec");
            }*//*

            return userEntity;
        }*/

        /*public string AddUpdateSupplier(SupplierDto supplierDto)
{
   throw new NotImplementedException();
}*/
    }
}
