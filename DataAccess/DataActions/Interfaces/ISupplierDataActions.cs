using DataAccess.Entities;

namespace DataAccess.DataActions.Interfaces
{
    public interface ISupplierDataActions
    {
        //User
        Task<bool> AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersByRoleId(int RoleId);
        Task<User> GetUserById(int UserId);
        Task<bool> UpdateUser(User user, int UserId);

        //Supplier
        Task<bool> AddSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierById(int SupplierId);
        Task<bool> UpdateSupplier(Supplier supplier, int SupplierId);

        //Contact
        Task<bool> AddContact(Contact contact);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<IEnumerable<Contact>> GetAllContactsBySupplier(int SupplierId);
        Task<bool> UpdateContact(Contact contact, int ContactId);

        //SupplyChainStages
        Task<IEnumerable<SupplyChainStage>> GetSupplyChainStages();

        //Facility
        Task<bool> AddFacility(Facility facility);
        Task<IEnumerable<Facility>> GetAllFacilities();
        Task<IEnumerable<Facility>> GetFacilitiesByReportingType(int ReportingTypeId);
        Task<Facility> GetFacilityById(int FacilityId);
        Task<bool> UpdateFacility(Facility facility, int FacilityId);

        //AssociatePipeline
        Task<bool> AddAssociatePipeline(AssociatePipeline associatePipeline);
        Task<IEnumerable<AssociatePipeline>> GetAllAssociatePipeline();
        Task<AssociatePipeline> GetAssociatePipelineById(int AssociatePipelineId);
        Task<bool> UpdateAssociatePipeline(AssociatePipeline associatePipeline, int AssociatePipelineId);

    }
}
