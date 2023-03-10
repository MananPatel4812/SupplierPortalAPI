using DataAccess.Entities;

namespace DataAccess.DataActions.Interfaces
{
    public interface ISupplierDataActions
    {
        //User
        Task<bool> AddUser(UserEntity user);
        Task<IEnumerable<UserEntity>> GetAllUsers();
        Task<IEnumerable<UserEntity>> GetAllUsersByRoleId(int RoleId);
        Task<UserEntity> GetUserById(int UserId);
        Task<bool> UpdateUser(UserEntity user, int UserId);

        //Supplier
        Task<bool> AddSupplier(SupplierEntity supplier);
        Task<IEnumerable<SupplierEntity>> GetAllSuppliers();
        Task<SupplierEntity> GetSupplierById(int SupplierId);
        Task<bool> UpdateSupplier(SupplierEntity supplier, int SupplierId);

        //Contact
        Task<bool> AddContact(ContactEntity contact);
        Task<IEnumerable<ContactEntity>> GetAllContacts();
        Task<IEnumerable<ContactEntity>> GetAllContactsBySupplier(int SupplierId);
        Task<bool> UpdateContact(ContactEntity contact, int ContactId);

        //SupplyChainStages
        Task<IEnumerable<SupplyChainStageEntity>> GetSupplyChainStages();

        //Facility
        Task<bool> AddFacility(FacilityEntity facility);
        Task<IEnumerable<FacilityEntity>> GetAllFacilities();
        Task<IEnumerable<FacilityEntity>> GetFacilitiesByReportingType(int ReportingTypeId);
        Task<FacilityEntity> GetFacilityById(int FacilityId);
        Task<bool> UpdateFacility(FacilityEntity facility, int FacilityId);

        //AssociatePipeline
        Task<bool> AddAssociatePipeline(AssociatePipelineEntity associatePipeline);
        Task<IEnumerable<AssociatePipelineEntity>> GetAllAssociatePipeline();
        Task<AssociatePipelineEntity> GetAssociatePipelineById(int AssociatePipelineId);
        Task<bool> UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int AssociatePipelineId);

    }
}
