using DataAccess.DataActionContext;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataActions
{
    public class SupplierDataActionsManager : ISupplierDataActions
    {
        private readonly SupplierPortalDBContext _context;

        public SupplierDataActionsManager(SupplierPortalDBContext context)
        {
            _context = context;
        }

        //Dispose Methods
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //User
        public int AddUser(UserEntity userEntity)
        {
            var IsUnique = IsUniqueEmail(userEntity.Email, "User");
            if (IsUnique == false)
            {
                throw new Exception("Email-Id is already exists !!");
            }
            else
            {
                var roles = _context.RoleEntities.Where(x => x.Name == "External").FirstOrDefault();
                userEntity.RoleId = roles.Id;
                userEntity.CreatedOn = DateTime.UtcNow;
                userEntity.CreatedBy = "System";

                _context.UserEntities.Add(userEntity);
                _context.SaveChanges();
                return userEntity.Id;
            }
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            var allUsers = _context.UserEntities.ToList();
            return allUsers;
        }

        public IEnumerable<UserEntity> GetAllUsersByRoleId(int roleId)
        {
            var allUsersByRole = _context.UserEntities.Where(x => x.RoleId == roleId).ToList();
            return allUsersByRole;
        }

        public UserEntity GetUserById(int userId)
        {
            var user = _context.UserEntities.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
                throw new Exception("User not found !");

            return user;
        }

        public int UpdateUser(UserEntity userEntity)
        {
            var entity = _context.UserEntities.FirstOrDefault(x => x.Id == userEntity.Id);

            var isUnique = IsUniqueEmail(userEntity.Email, "User");
            if (userEntity.Email != entity.Email)
            {
                if (isUnique == false)
                {
                    throw new Exception("Email-Id is already exists !!");
                }
                else
                    goto Case;
            }
            else
                goto Case;

            Case:
            {
                entity.Name = userEntity.Name;
                entity.Email = userEntity.Email;
                entity.ContactNo = userEntity.ContactNo;
                entity.RoleId = entity.RoleId;
                entity.IsActive = userEntity.IsActive;
                entity.UpdatedOn = DateTime.UtcNow;
                entity.UpdatedBy = "System";

                _context.UserEntities.Update(entity);
                _context.SaveChanges();
                return entity.Id;
            }
        }

        public bool IsUniqueEmail(string email, string entity)
        {
            if (entity == "User")
            {
                var allEmailId = _context.UserEntities.Where(x => x.Email == email).ToList();
                if (allEmailId.Count == 0)
                {
                    return true;
                }
            }

            if (entity == "Supplier")
            {
                var allEmailId = _context.SupplierEntities.Where(x => x.Email == email).ToList();
                if (allEmailId.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }


        //Supplier
        public bool AddSupplier(SupplierEntity supplier)
        {
            var isUnique = IsUniqueEmail(supplier.Email, "Supplier");
            if (isUnique == false)
            {
                throw new Exception("Email-Id is already exists !!");
            }
            else
            {
                supplier.CreatedOn = DateTime.UtcNow;
                supplier.CreatedBy = "System";
                _context.SupplierEntities.Add(supplier);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<SupplierEntity> GetAllSuppliers()
        {
            var allSuppliers = _context.SupplierEntities.Include(x => x.ContactEntities)
                                                            .ThenInclude(x => x.User)
                                                        .Include(x => x.FacilityEntities)
                                                        .ToList();
            return allSuppliers;
        }

        public SupplierEntity GetSupplierById(int supplierId)
        {
            var supplier =
                _context.SupplierEntities.Where(x => x.Id == supplierId)
                                         .Include(x => x.ContactEntities)
                                            .ThenInclude(x => x.User)
                                         .Include(x => x.FacilityEntities)
                                         .Include(x => x.ReportingPeriodSupplierEntities)
                                         .FirstOrDefault();
            return supplier;
        }

        public bool UpdateSupplier(SupplierEntity supplier)
        {
            var supplierEntity = _context.SupplierEntities.Where(x => x.Id == supplier.Id)
                                                    .FirstOrDefault();

            var isUnique = IsUniqueEmail(supplier.Email, "Supplier");

            if (supplier.Email != supplierEntity.Email)
            {
                if (isUnique == false)
                {
                    throw new Exception("Email-Id is already exists !!");
                }
                else
                    goto Case;
            }
            else
                goto Case;

            Case:
            {
                supplierEntity.Name = supplier.Name;
                supplierEntity.Alias = supplier.Alias;
                supplierEntity.Email = supplier.Email;
                supplierEntity.ContactNo = supplier.ContactNo;
                supplierEntity.IsActive = supplier.IsActive;
                supplierEntity.UpdatedOn = DateTime.UtcNow;
                supplierEntity.UpdatedBy = "System";

                _context.SupplierEntities.Update(supplierEntity);
                _context.SaveChanges();
                return true;
            }

        }

        //Contact
        public bool AddContact(ContactEntity contact)
        {
            contact.CreatedOn= DateTime.UtcNow;
            contact.CreatedBy = "System";
            contact.CreatedOn = DateTime.UtcNow;
            _context.ContactEntities.Add(contact);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ContactEntity> GetAllContacts()
        {
            var allContacts = _context.ContactEntities.Include(x => x.User).ToList();
            return allContacts;
        }

        public ContactEntity GetContactById(int contactId)
        {
            var contact = _context.ContactEntities.Include(x => x.Supplier)
                                                           .Include(x => x.User)
                                                           .Where(x => x.Id == contactId)
                                                           .FirstOrDefault();
            return contact;
        }

        public bool UpdateContact(ContactEntity contact)
        {
            var contactEntity = _context.ContactEntities.Where(x => x.Id == contact
            .Id).FirstOrDefault();
            contactEntity.SupplierId = contact.SupplierId;
            contactEntity.UserId = contact.UserId;
            contactEntity.UpdatedOn = DateTime.UtcNow;
            contactEntity.UpdatedBy = "System";

            _context.ContactEntities.Update(contactEntity);
            _context.SaveChanges();
            return true;
        }

        //SupplyChainStages
        public IEnumerable<SupplyChainStageEntity> GetSupplyChainStages()
        {
            var supplyChainStages = _context.SupplyChainStageEntities.ToList();
            return supplyChainStages;
        }

        //Facility
        public bool AddFacility(FacilityEntity facility)
        {
            _context.FacilityEntities.Add(facility);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<FacilityEntity> GetAllFacilities()
        {
            var allFacility = _context.FacilityEntities.Include(x => x.AssociatePipeline)
                                                       .Include(x => x.ReportingType)
                                                       .Include(x => x.SupplyChainStage)
                                                       .ToList();
            return allFacility;
        }

        public IEnumerable<FacilityEntity> GetFacilitiesByReportingType(int reportingTypeId)
        {
            var reportingPeriodFacility =
                _context.FacilityEntities.Include(x => x.AssociatePipeline)
                                         .Include(x => x.ReportingType)
                                         .Include(x => x.SupplyChainStage)
                                         .Where(x => x.ReportingTypeId == reportingTypeId)
                                         .ToList();

            return reportingPeriodFacility;
        }

        public FacilityEntity GetFacilityById(int facilityId)
        {
            var facility = _context.FacilityEntities.Include(x => x.AssociatePipeline)
                                                    .Include(x => x.ReportingType)
                                                    .Include(x => x.SupplyChainStage)
                                                    .FirstOrDefault(x => x.Id == facilityId);
            return facility;
        }

        public bool UpdateFacility(FacilityEntity facility, int facilityId)
        {
            var facilityEntity = _context.FacilityEntities.Where(x => x.Id == facilityId).FirstOrDefault();
            facilityEntity.Name = facility.Name;
            facilityEntity.Description = facility.Description;
            facilityEntity.IsPrimary = facility.IsPrimary;
            facilityEntity.AssociatePipelineId = facility.AssociatePipelineId;
            facilityEntity.ReportingTypeId = facility.ReportingTypeId;
            facilityEntity.SupplyChainStageId = facility.SupplyChainStageId;
            facilityEntity.UpdatedOn = DateTime.UtcNow;
            facilityEntity.UpdatedBy = "System";

            _context.FacilityEntities.Update(facilityEntity);
            _context.SaveChanges();
            return true;
        }

        //AssociatePipeline
        public bool AddAssociatePipeline(AssociatePipelineEntity associatePipeline)
        {
            associatePipeline.CreatedOn = DateTime.UtcNow;
            associatePipeline.CreatedBy = "System";
            _context.AssociatePipelineEntities.Add(associatePipeline);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<AssociatePipelineEntity> GetAllAssociatePipeline()
        {
            var allAssociatePipelines = _context.AssociatePipelineEntities.ToList();
            return allAssociatePipelines;
        }

        public AssociatePipelineEntity GetAssociatePipelineById(int associatePipelineId)
        {
            var associatePipeline = _context.AssociatePipelineEntities.FirstOrDefault(x => x.Id == associatePipelineId);
            return associatePipeline;
        }

        public bool UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int associatePipelineId)
        {
            var associatePipelineEntity = _context.AssociatePipelineEntities.Where(x => x.Id == associatePipelineId).FirstOrDefault();
            associatePipelineEntity.Name = associatePipeline.Name;
            associatePipelineEntity.UpdatedOn = DateTime.UtcNow;
            associatePipelineEntity.UpdatedBy = "System";

            _context.AssociatePipelineEntities.Update(associatePipelineEntity);
            _context.SaveChanges();
            return true;

        }

    }
}
