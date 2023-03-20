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
        private ISupplierFactory _supplierFactory;
        private readonly ILogger _logger;
        private ISupplierEntityDomainMapper _supplierEntityDomainMapper;
        private ISupplierDomainDtoMapper _supplierDomainDtoMapper;
        private ISupplierDataActions _persister;

        public SupplierServices(ILoggerFactory loggerFactory, ISupplierFactory supplierFactory,
            ISupplierEntityDomainMapper supplierEntityDomainMapper,
            ISupplierDomainDtoMapper supplierDomainDtoMapper,
            ISupplierDataActions persister)
        {
            _logger = loggerFactory.CreateLogger<SupplierServices>();
            _supplierFactory = supplierFactory;
            _supplierEntityDomainMapper = supplierEntityDomainMapper;
            _supplierDomainDtoMapper = supplierDomainDtoMapper;
            _persister = persister;
        }

        //Supplier
        public string AddUpdateSupplier(SupplierDto supplierDto)
        {
            if (supplierDto.Id == 0)
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
            return "Supplier added successfully....";
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
            var supplierList = _persister.GetAllSuppliers().Where(x => x.IsActive == true);
            var allSuppliers = _supplierEntityDomainMapper.ConvertSuppliersListEntityToDomain(supplierList);
            var suppliers = _supplierDomainDtoMapper.ConvertSuppliersToDtos(allSuppliers);
            return suppliers;
        }

        public SupplierDto GetSupplierById(int supplierId)
        {
            var supplierEntity = _persister.GetSupplierById(supplierId);

            if(supplierEntity == null)
            {
                throw new Exception("Supplier not found !!");
            }

            var supplier = _supplierEntityDomainMapper.ConvertSupplierEntityToDomain(supplierEntity);
            var supplierDto = _supplierDomainDtoMapper.ConvertSupplierDomainToDto(supplier);
            return supplierDto;
        }

        //Contact
        public string AddUpdateContact(ContactDto contactDto)
        {
            var userId = 0;
            var supplierEntity = _persister.GetSupplierById(contactDto.SupplierId);

            if(supplierEntity == null)
            {
                throw new Exception("Supplier not found !!");
            }

            //Mapper
            var supplier = _supplierEntityDomainMapper.ConvertSupplierEntityToDomain(supplierEntity);

            if (contactDto.Id == 0)
            {
                if (contactDto.UserId == 0)
                {
                    supplier.ValidateUserContactNo(contactDto.UserContactNo);

                    //ADD User
                    userId = _persister.AddUser(new UserEntity
                    {
                        Id = contactDto.UserId,
                        Name = contactDto.UserName,
                        Email = contactDto.UserEmail,
                        ContactNo = contactDto.UserContactNo,
                        IsActive = contactDto.IsActive
                    });
                }
                else
                { throw new Exception("Please enter contactId for update user !!"); }

                var userVO = new UserVO(userId, contactDto.UserName, contactDto.UserEmail, contactDto.UserContactNo, contactDto.IsActive);

                var contact = supplier.AddSupplierContact(contactDto.Id, supplier, userVO);

                //Convert Domain to Entity
                var contactEntity = _supplierEntityDomainMapper.ConvertContactDomainToEntity(contact);
                _persister.AddContact(contactEntity);
            }
            else
            {
                var contactEntity = _persister.GetContactById(contactDto.Id);

                if(contactEntity == null)
                {
                    throw new Exception("Contact not found !!");
                }

                if (contactEntity.SupplierId != contactDto.SupplierId)
                {
                    throw new Exception("Supplier cannot be changed !!");
                }

                if (contactDto.UserId != 0)
                {
                    //UPDATE User Details
                    userId = _persister.UpdateUser(new UserEntity
                    {
                        Id = contactDto.UserId,
                        Name = contactDto.UserName,
                        Email = contactDto.UserEmail,
                        ContactNo = contactDto.UserContactNo,
                        IsActive = contactDto.IsActive
                    });
                }
                else
                { throw new Exception("Please enter userId for update !!"); }

                var userVO = new UserVO(userId, contactDto.UserName, contactDto.UserEmail, contactDto.UserContactNo, contactDto.IsActive);

                var contact = supplier.UpdateSupplierContact(contactDto.Id, supplier, userVO);

                //Convert Domain to Entity
                contactEntity = _supplierEntityDomainMapper.ConvertContactDomainToEntity(contact);
                _persister.UpdateContact(contactEntity);

            }

            return "Contact done Successfully";
        }
    }
}
