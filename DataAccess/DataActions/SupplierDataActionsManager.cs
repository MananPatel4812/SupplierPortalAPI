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
        public async Task<bool> AddUser(User user)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.UpdatedOn = null;
            user.CreatedBy = "System";
            user.UpdatedBy = null;
            await _context.Users.AddAsync(user);
            var Answer = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var AllUsers = await _context.Users.ToListAsync();
            return AllUsers;
        }

        public async Task<IEnumerable<User>> GetAllUsersByRoleId(int RoleId)
        {
            var AllUsersByRole = await _context.Users.Where(x => x.RoleId == RoleId).ToListAsync();
            return AllUsersByRole;
        }

        public async Task<User> GetUserById(int UserId)
        {
            var User = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == UserId);
            return User;
        }

        public async Task<bool> UpdateUser(User user, int UserId)
        {
            var User = await _context.Users.Where(x => x.Id == UserId).FirstOrDefaultAsync();
            User.Name = user.Name;
            User.Email = user.Email;
            User.ContactNo = user.ContactNo;
            User.RoleId = user.RoleId;
            User.Active = user.Active;
            User.CreatedOn = User.CreatedOn;
            User.UpdatedOn = DateTime.UtcNow;
            User.CreatedBy = User.CreatedBy;
            User.UpdatedBy = "System";

            _context.Users.Update(User);
            await _context.SaveChangesAsync();
            return true;
        }


        //Supplier
        public async Task<bool> AddSupplier(Supplier supplier)
        {
            supplier.CreatedOn = DateTime.UtcNow;
            supplier.CreatedBy = "System";
            supplier.UpdatedOn = null;
            supplier.UpdatedBy = null;
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var AllSuppliers = await _context.Suppliers.ToListAsync();
            return AllSuppliers;
        }

        public async Task<Supplier> GetSupplierById(int SupplierId)
        {
            var Supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == SupplierId);
            return Supplier;
        }

        public async Task<bool> UpdateSupplier(Supplier supplier, int SupplierId)
        {
            var Supplier = await _context.Suppliers.Where(x => x.Id == SupplierId).FirstOrDefaultAsync();
            Supplier.Name = supplier.Name;
            Supplier.Alias = supplier.Alias;
            Supplier.Email = supplier.Email;
            Supplier.ContactNo = supplier.ContactNo;
            Supplier.Active = supplier.Active;
            Supplier.CreatedOn = Supplier.CreatedOn;
            Supplier.UpdatedOn = DateTime.UtcNow;
            Supplier.CreatedBy = Supplier.CreatedBy;
            Supplier.UpdatedBy = "System";

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        //Contact
        public async Task<bool> AddContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var AllContacts = await _context.Contacts.ToListAsync();
            return AllContacts;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsBySupplier(int SupplierId)
        {
            var SupplierContacts = await _context.Contacts.Include(x => x.Supplier).Include(x => x.User).Where(x => x.SupplierId == SupplierId).ToListAsync();
            return SupplierContacts;
        }

        public async Task<bool> UpdateContact(Contact contact, int ContactId)
        {
            var Contact = await _context.Contacts.Where(x => x.Id == ContactId).FirstOrDefaultAsync();
            Contact.SupplierId = contact.SupplierId;
            Contact.UserId = contact.UserId;

            _context.Contacts.Update(Contact);
            await _context.SaveChangesAsync();
            return true;
        }

        //SupplyChainStages
        public async Task<IEnumerable<SupplyChainStage>> GetSupplyChainStages()
        {
            var SupplyChainStages = await _context.SupplyChainStages.ToListAsync();
            return SupplyChainStages;
        }

        //Facility
        public async Task<bool> AddFacility(Facility facility)
        {
            await _context.Facilities.AddAsync(facility);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Facility>> GetAllFacilities()
        {
            var AllFacility = await _context.Facilities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).ToListAsync();
            return AllFacility;
        }

        public async Task<IEnumerable<Facility>> GetFacilitiesByReportingType(int ReportingTypeId)
        {
            var ReportingPeriodFacility = await _context.Facilities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).Where(x => x.ReportingTypeId == ReportingTypeId).ToListAsync();
            return ReportingPeriodFacility;
        }

        public async Task<Facility> GetFacilityById(int FacilityId)
        {
            var Facility = await _context.Facilities.Include(x => x.AssociatePipeline).Include(x => x.ReportingType).Include(x => x.SupplyChainStage).FirstOrDefaultAsync(x => x.Id == FacilityId);
            return Facility;
        }

        public async Task<bool> UpdateFacility(Facility facility, int FacilityId)
        {
            var Facility = await _context.Facilities.Where(x => x.Id == FacilityId).FirstOrDefaultAsync();
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

            _context.Facilities.Update(Facility);
            await _context.SaveChangesAsync();
            return true;
        }

        //AssociatePipeline
        public async Task<bool> AddAssociatePipeline(AssociatePipeline associatePipeline)
        {
            associatePipeline.CreatedOn = DateTime.UtcNow;
            associatePipeline.CreatedBy = "System";
            associatePipeline.UpdatedOn = null;
            associatePipeline.UpdatedBy = null;
            await _context.AssociatePipelines.AddAsync(associatePipeline);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AssociatePipeline>> GetAllAssociatePipeline()
        {
            var AllAssociatePipelines = await _context.AssociatePipelines.ToListAsync();
            return AllAssociatePipelines;
        }

        public async Task<AssociatePipeline> GetAssociatePipelineById(int AssociatePipelineId)
        {
            var AssociatePipeline = await _context.AssociatePipelines.FirstOrDefaultAsync(x => x.Id == AssociatePipelineId);
            return AssociatePipeline;
        }

        public async Task<bool> UpdateAssociatePipeline(AssociatePipeline associatePipeline, int AssociatePipelineId)
        {
            var AssociatePipeline = await _context.AssociatePipelines.Where(x => x.Id == AssociatePipelineId).FirstOrDefaultAsync();
            AssociatePipeline.Name = associatePipeline.Name;
            AssociatePipeline.CreatedOn = AssociatePipeline.CreatedOn;
            AssociatePipeline.CreatedBy = AssociatePipeline.CreatedBy;
            AssociatePipeline.UpdatedOn = DateTime.UtcNow;
            AssociatePipeline.UpdatedBy = "System";

            _context.AssociatePipelines.Update(AssociatePipeline);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
