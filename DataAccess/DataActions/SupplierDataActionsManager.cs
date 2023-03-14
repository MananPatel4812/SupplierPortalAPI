using DataAccess.DataActions.Interfaces;
using DataAccess.DataActionContext;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.DataActions
{
    public class SupplierDataActionsManager : ISupplierDataActions
    {
        private readonly SupplierPortalDBContext _context;

        public SupplierDataActionsManager(SupplierPortalDBContext context)
        {
            _context = context;
        }

        //User
        public int AddUser(UserEntity userEntity)
        {
            var IsUniqueEmail = IsUniqueUserEmail(userEntity.Email);
            if (IsUniqueEmail == false)
            {
                throw new Exception("Email-Id is already exists !!");
            }
            else
            {
                userEntity.CreatedOn = DateTime.UtcNow;
                userEntity.CreatedBy = "System";
                _context.UserEntities.Add(userEntity);
                _context.SaveChanges();
                return userEntity.Id;
            }
        }


        public IEnumerable<UserEntity> GetAllUsers()
        {
            var AllUsers = _context.UserEntities.ToList();
            return AllUsers;
        }

        public IEnumerable<UserEntity> GetAllUsersByRoleId(int RoleId)
        {
            var AllUsersByRole =  _context.UserEntities.Where(x => x.RoleId == RoleId).ToList();
            return AllUsersByRole;
        }

        public UserEntity GetUserById(int userId)
        {
            var user = _context.UserEntities.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
                throw new Exception("User not found !");

            return user;
        }

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

        public int UpdateUser(UserEntity userEntity)
        {
            var entity = _context.UserEntities.FirstOrDefault(x => x.Id == userEntity.Id);

            var IsUniqueEmail = IsUniqueUserEmail(userEntity.Email);
            if (userEntity.Email != entity.Email)
            {
                if (IsUniqueEmail == false)
                {
                    throw new Exception("Email-Id is already exists !!");
                }
            }
            else
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
                return userEntity.Id;
            }
            return 0;

        }

        public bool IsUniqueUserEmail(string email)
        {
            var AllEmailId = _context.UserEntities.Where(x => x.Email == email).ToList();
            if (AllEmailId.Count == 0)
            {
                return true;
            }
            else
                return false;
        }


        //Supplier
        public bool AddSupplier(SupplierEntity supplier)
        {
            supplier.CreatedOn = DateTime.UtcNow;
            supplier.CreatedBy = "System";
             _context.SupplierEntities.Add(supplier);
             _context.SaveChanges();
            return true;
        }

        /*
         * 
         */

        public IEnumerable<SupplierEntity> GetAllSuppliers()
        {
            var AllSuppliers = _context.SupplierEntities.ToList();
            return AllSuppliers;
        }

        public SupplierEntity GetSupplierById(int SupplierId)
        {
            var Supplier = _context.SupplierEntities.FirstOrDefault(x => x.Id == SupplierId);
            return Supplier;
        }

        public bool UpdateSupplier(SupplierEntity supplier)
        {
            var Supplier = _context.SupplierEntities.Where(x => x.Id == supplier.Id).FirstOrDefault();
            Supplier.Name = supplier.Name;
            Supplier.Alias = supplier.Alias;
            Supplier.Email = supplier.Email;
            Supplier.ContactNo = supplier.ContactNo;
            Supplier.IsActive = supplier.IsActive;
            Supplier.UpdatedOn = DateTime.UtcNow;
            Supplier.UpdatedBy = "System";

            _context.SupplierEntities.Update(Supplier);
            _context.SaveChanges();
            return true;
        }

        //Contact
        public bool AddContact(ContactEntity contact)
        {
             _context.ContactEntities.Add(contact);
             _context.SaveChanges();
            return true;
        }

        public IEnumerable<ContactEntity> GetAllContacts()
        {
            var AllContacts = _context.ContactEntities.ToList();
            return AllContacts;
        }

        public IEnumerable<ContactEntity> GetAllContactsBySupplier(int SupplierId)
        {
            var SupplierContacts = _context.ContactEntities.Include(x => x.Supplier).Include(x => x.User).Where(x => x.SupplierId == SupplierId).ToList();
            return SupplierContacts;
        }

        public bool UpdateContact(ContactEntity contact, int ContactId)
        {
            var Contact = _context.ContactEntities.Where(x => x.Id == ContactId).FirstOrDefault();
            Contact.SupplierId = contact.SupplierId;
            Contact.UserId = contact.UserId;

            _context.ContactEntities.Update(Contact);
             _context.SaveChanges();
            return true;
        }

        //SupplyChainStages
        public IEnumerable<SupplyChainStageEntity> GetSupplyChainStages()
        {
            var SupplyChainStages = _context.SupplyChainStageEntities.ToList();
            return SupplyChainStages;
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
            var AllFacility = _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).ToList();
            return AllFacility;
        }

        public IEnumerable<FacilityEntity> GetFacilitiesByReportingType(int ReportingTypeId)
        {
            var ReportingPeriodFacility = _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).Where(x => x.ReportingTypeId == ReportingTypeId).ToList();
            return ReportingPeriodFacility;
        }

        public FacilityEntity GetFacilityById(int FacilityId)
        {
            var Facility =  _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).FirstOrDefault(x => x.Id == FacilityId);
            return Facility;
        }

        public bool UpdateFacility(FacilityEntity facility, int FacilityId)
        {
            var Facility = _context.FacilityEntities.Where(x => x.Id == FacilityId).FirstOrDefault();
            Facility.Name = facility.Name;
            Facility.Description = facility.Description;
            Facility.IsPrimary = facility.IsPrimary;
            Facility.AssociatePipelineId = facility.AssociatePipelineId;
            Facility.ReportingTypeId = facility.ReportingTypeId;
            Facility.SupplyChainStageId = facility.SupplyChainStageId;
            Facility.CreatedOn = Facility.CreatedOn;
            Facility.CreatedBy = Facility.CreatedBy;
            Facility.UpdatedOn = DateTime.UtcNow;
            Facility.UpdatedBy = "System";

            _context.FacilityEntities.Update(Facility);
            _context.SaveChanges();
            return true;
        }

        //AssociatePipeline
        public bool AddAssociatePipeline(AssociatePipelineEntity associatePipeline)
        {
            associatePipeline.CreatedOn = DateTime.UtcNow;
            associatePipeline.CreatedBy = "System";
            associatePipeline.UpdatedOn = null;
            associatePipeline.UpdatedBy = null;
             _context.AssociatePipelineEntities.Add(associatePipeline);
             _context.SaveChanges();
            return true;
        }

        public IEnumerable<AssociatePipelineEntity> GetAllAssociatePipeline()
        {
            var AllAssociatePipelines = _context.AssociatePipelineEntities.ToList();
            return AllAssociatePipelines;
        }

        public AssociatePipelineEntity GetAssociatePipelineById(int AssociatePipelineId)
        {
            var AssociatePipeline = _context.AssociatePipelineEntities.FirstOrDefault(x => x.Id == AssociatePipelineId);
            return AssociatePipeline;
        }

        public bool UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int AssociatePipelineId)
        {
            var AssociatePipeline = _context.AssociatePipelineEntities.Where(x => x.Id == AssociatePipelineId).FirstOrDefault();
            AssociatePipeline.Name = associatePipeline.Name;
            AssociatePipeline.CreatedOn = AssociatePipeline.CreatedOn;
            AssociatePipeline.CreatedBy = AssociatePipeline.CreatedBy;
            AssociatePipeline.UpdatedOn = DateTime.UtcNow;
            AssociatePipeline.UpdatedBy = "System";

            _context.AssociatePipelineEntities.Update(AssociatePipeline);
             _context.SaveChanges();
            return true;

        }

    }
}
