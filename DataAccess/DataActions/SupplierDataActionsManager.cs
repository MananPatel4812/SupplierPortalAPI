using DataAccess.DataActions.Interfaces;
using DataAccess.DataActionContext;
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

        //User
        public async Task<bool> AddUser(UserEntity user)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.UpdatedOn = null;
            user.CreatedBy = "System";
            user.UpdatedBy = null;
            await _context.UserEntities.AddAsync(user);
            var Answer = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            var AllUsers = await _context.UserEntities.ToListAsync();
            return AllUsers;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersByRoleId(int RoleId)
        {
            var AllUsersByRole = await _context.UserEntities.Where(x => x.RoleId == RoleId).ToListAsync();
            return AllUsersByRole;
        }

        public async Task<UserEntity> GetUserById(int UserId)
        {
            var User = await _context.UserEntities.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == UserId);
            return User;
        }

        public async Task<bool> UpdateUser(UserEntity user, int UserId)
        {
            var User = await _context.UserEntities.Where(x => x.Id == UserId).FirstOrDefaultAsync();
            User.Name = user.Name;
            User.Email = user.Email;
            User.ContactNo = user.ContactNo;
            User.RoleId = user.RoleId;
            User.IsActive = user.IsActive;
            User.CreatedOn = User.CreatedOn;
            User.UpdatedOn = DateTime.UtcNow;
            User.CreatedBy = User.CreatedBy;
            User.UpdatedBy = "System";

            _context.UserEntities.Update(User);
            await _context.SaveChangesAsync();
            return true;
        }


        //Supplier
        public async Task<bool> AddSupplier(SupplierEntity supplier)
        {
            supplier.CreatedOn = DateTime.UtcNow;
            supplier.CreatedBy = "System";
            supplier.UpdatedOn = null;
            supplier.UpdatedBy = null;
            await _context.SupplierEntities.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SupplierEntity>> GetAllSuppliers()
        {
            var AllSuppliers = await _context.SupplierEntities.ToListAsync();
            return AllSuppliers;
        }

        public async Task<SupplierEntity> GetSupplierById(int SupplierId)
        {
            var Supplier = await _context.SupplierEntities.FirstOrDefaultAsync(x => x.Id == SupplierId);
            return Supplier;
        }

        public async Task<bool> UpdateSupplier(SupplierEntity supplier, int SupplierId)
        {
            var Supplier = await _context.SupplierEntities.Where(x => x.Id == SupplierId).FirstOrDefaultAsync();
            Supplier.Name = supplier.Name;
            Supplier.Alias = supplier.Alias;
            Supplier.Email = supplier.Email;
            Supplier.ContactNo = supplier.ContactNo;
            Supplier.IsActive = supplier.IsActive;
            Supplier.CreatedOn = Supplier.CreatedOn;
            Supplier.UpdatedOn = DateTime.UtcNow;
            Supplier.CreatedBy = Supplier.CreatedBy;
            Supplier.UpdatedBy = "System";

            _context.SupplierEntities.Update(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        //Contact
        public async Task<bool> AddContact(ContactEntity contact)
        {
            await _context.ContactEntities.AddAsync(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ContactEntity>> GetAllContacts()
        {
            var AllContacts = await _context.ContactEntities.ToListAsync();
            return AllContacts;
        }

        public async Task<IEnumerable<ContactEntity>> GetAllContactsBySupplier(int SupplierId)
        {
            var SupplierContacts = await _context.ContactEntities.Include(x => x.Supplier).Include(x => x.User).Where(x => x.SupplierId == SupplierId).ToListAsync();
            return SupplierContacts;
        }

        public async Task<bool> UpdateContact(ContactEntity contact, int ContactId)
        {
            var Contact = await _context.ContactEntities.Where(x => x.Id == ContactId).FirstOrDefaultAsync();
            Contact.SupplierId = contact.SupplierId;
            Contact.UserId = contact.UserId;

            _context.ContactEntities.Update(Contact);
            await _context.SaveChangesAsync();
            return true;
        }

        //SupplyChainStages
        public async Task<IEnumerable<SupplyChainStageEntity>> GetSupplyChainStages()
        {
            var SupplyChainStages = await _context.SupplyChainStageEntities.ToListAsync();
            return SupplyChainStages;
        }

        //Facility
        public async Task<bool> AddFacility(FacilityEntity facility)
        {
            await _context.FacilityEntities.AddAsync(facility);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FacilityEntity>> GetAllFacilities()
        {
            var AllFacility = await _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).ToListAsync();
            return AllFacility;
        }

        public async Task<IEnumerable<FacilityEntity>> GetFacilitiesByReportingType(int ReportingTypeId)
        {
            var ReportingPeriodFacility = await _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).Where(x => x.ReportingTypeId == ReportingTypeId).ToListAsync();
            return ReportingPeriodFacility;
        }

        public async Task<FacilityEntity> GetFacilityById(int FacilityId)
        {
            var Facility = await _context.FacilityEntities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).FirstOrDefaultAsync(x => x.Id == FacilityId);
            return Facility;
        }

        public async Task<bool> UpdateFacility(FacilityEntity facility, int FacilityId)
        {
            var Facility = await _context.FacilityEntities.Where(x => x.Id == FacilityId).FirstOrDefaultAsync();
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
            await _context.SaveChangesAsync();
            return true;
        }

        //AssociatePipeline
        public async Task<bool> AddAssociatePipeline(AssociatePipelineEntity associatePipeline)
        {
            associatePipeline.CreatedOn = DateTime.UtcNow;
            associatePipeline.CreatedBy = "System";
            associatePipeline.UpdatedOn = null;
            associatePipeline.UpdatedBy = null;
            await _context.AssociatePipelineEntities.AddAsync(associatePipeline);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AssociatePipelineEntity>> GetAllAssociatePipeline()
        {
            var AllAssociatePipelines = await _context.AssociatePipelineEntities.ToListAsync();
            return AllAssociatePipelines;
        }

        public async Task<AssociatePipelineEntity> GetAssociatePipelineById(int AssociatePipelineId)
        {
            var AssociatePipeline = await _context.AssociatePipelineEntities.FirstOrDefaultAsync(x => x.Id == AssociatePipelineId);
            return AssociatePipeline;
        }

        public async Task<bool> UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int AssociatePipelineId)
        {
            var AssociatePipeline = await _context.AssociatePipelineEntities.Where(x => x.Id == AssociatePipelineId).FirstOrDefaultAsync();
            AssociatePipeline.Name = associatePipeline.Name;
            AssociatePipeline.CreatedOn = AssociatePipeline.CreatedOn;
            AssociatePipeline.CreatedBy = AssociatePipeline.CreatedBy;
            AssociatePipeline.UpdatedOn = DateTime.UtcNow;
            AssociatePipeline.UpdatedBy = "System";

            _context.AssociatePipelineEntities.Update(AssociatePipeline);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
