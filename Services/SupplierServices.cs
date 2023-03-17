using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.Factories.Interface;
using Services.Factories.Interfaces;
using Services.Interfaces;
using Services.Mappers.Interfaces;

namespace Services
{
    public class SupplierServices : ISupplierServices
    {
        private IUserFactory _userFactory;
        private ISupplierFactory _supplierFactory;
        private readonly ILogger _logger;
        private IUserEntityDomainMapper _userEntityDomainMapper;
        private ISupplierEntityDomainMapper _supplierEntityDomainMapper;
        private ISupplierDomainDtoMapper _supplierDomainDtoMapper;
        private ISupplierDataActions _persister;

        public SupplierServices(ILoggerFactory loggerFactory, ISupplierFactory supplierFactory, 
            IUserFactory userFactory, IUserEntityDomainMapper userEntityDomainMapper,
            ISupplierEntityDomainMapper supplierEntityDomainMapper,
            ISupplierDomainDtoMapper supplierDomainDtoMapper,
            ISupplierDataActions persister) 
        { 
            _logger = loggerFactory.CreateLogger<SupplierServices>();
            _supplierFactory = supplierFactory;
            _userFactory= userFactory;
            _userEntityDomainMapper = userEntityDomainMapper;
            _supplierEntityDomainMapper = supplierEntityDomainMapper;
            _supplierDomainDtoMapper = supplierDomainDtoMapper;
            _persister = persister;
        }

        //User
        public string AddUpdateUser(UserDto userDto)
        {
            //add user
            if(userDto.Id == 0)
            {
                var user = _userFactory.CreateNewUser(userDto.Name, userDto.Email, userDto.ContactNo, userDto.RoleId, userDto.IsActive);

                var entity = _userEntityDomainMapper.ConvertUserDomainToEntity(user);
                _persister.AddUser(entity);
            }
            else
            {
                 //Fetch record by Id
                var user = RetrieveAndConvertUser(userDto.Id ?? 0);
                user.UpdateUser(userDto.Name, userDto.Email, userDto.ContactNo, userDto.RoleId, userDto.IsActive);
                //Convert Domain to Entity
                var entity = _userEntityDomainMapper.ConvertUserDomainToEntity(user);
                _persister.UpdateUser(entity);
            }

            return "success";
        }

        private User RetrieveAndConvertUser(int userId)
        {
            var userEntity = _persister.GetUserById(userId);
            if (userEntity == null)
            {
                throw new Exception("User not found !!");
            }
            return ConfigureUser(userEntity);
        }

        private User ConfigureUser(UserEntity userEntity)
        {
            //Convert Entity to Domain
            var userDomain = _userEntityDomainMapper.ConvertUserEntityToDomain(userEntity);
            return userDomain;
        }

        //Supplier
        public string AddUpdateSupplier(SupplierDto supplierDto)
        {
            if(supplierDto.Id == 0)
            {
                var supplier = _supplierFactory.CreateNewSupplier(supplierDto.Name, supplierDto.Alias, supplierDto.Email, supplierDto.ContactNo, supplierDto.IsActive);//, supplierDto.Facilities, supplierDto.Contacts);
                
                var entity = _supplierEntityDomainMapper.ConvertSupplierDomainToEntity(supplier);
                _persister.AddSupplier(entity);
            }
            else
            {
                //Fetch record by Id
                var supplier = RetrieveAndConvertSupplier(supplierDto.Id ?? 0);
                supplier.UpdateSupplier(supplierDto.Name, supplierDto.Alias, supplierDto.Email, supplierDto.ContactNo, supplierDto.IsActive);
                //Convert Domain to Entity
                var entity = _supplierEntityDomainMapper.ConvertSupplierDomainToEntity(supplier);
                _persister.UpdateSupplier(entity);

            }
            return "Success";
        }

        private Supplier RetrieveAndConvertSupplier(int supplierId)
        {
            var supplierEntity = _persister.GetSupplierById(supplierId);
            if (supplierEntity == null)
            {
                throw new Exception("Supplier not found !!");
            }
            return ConfigureSupplier(supplierEntity);
        }

        

        private Supplier ConfigureSupplier(SupplierEntity supplierEntity)
        {
            //Convert Entity to Domain
            var supplierDomain = _supplierEntityDomainMapper.ConvertSupplierEntityToDomain(supplierEntity);
            return supplierDomain;
        }

        public IEnumerable<SupplierDto> GetAllSuppliers()
        {
            var supplierList = _persister.GetAllSuppliers();
            var allSuppliers = _supplierEntityDomainMapper.ConvertSuppliersListEntityToDomain(supplierList);
            var Suppliers = _supplierDomainDtoMapper.ConvertSuppliersToDtos(allSuppliers);
            return Suppliers;
        }

        //Contact
        public string AddUpdateContact(ContactDto contactDto)
        {
            var message = "";
            
            var supplierEntity = _persister.GetSupplierById(contactDto.SupplierId);

            var userId = _persister.AddUser(new UserEntity
            {
                Id = contactDto.UserId,
                Name = contactDto.UserName,
                Email = contactDto.UserEmail,
                ContactNo = contactDto.UserContactNo,
                RoleId = contactDto.RoleId,
                IsActive = contactDto.IsActive
            });

            if (userId != null)
            { message = $"User {contactDto.UserName} added successfully... ";  }

            var userVO = new UserVO(userId, contactDto.UserName, contactDto.UserEmail, contactDto.UserContactNo, contactDto.RoleId, contactDto.IsActive);

            //Mapper
            var supplier = _supplierEntityDomainMapper.ConvertSupplierEntityToDomain(supplierEntity);

            if (contactDto.Id == 0)
            {
                var contact = supplier.AddSupplierContact(contactDto.Id, supplier, userVO);

                //Convert Domain to Entity
                var contactEntity = _supplierEntityDomainMapper.ConvertContactDomainToEntity(contact);
                _persister.AddContact(contactEntity);
            }
            else
            {

            }

            return message + "!! Contact done Successfully";
        }
    }
}
