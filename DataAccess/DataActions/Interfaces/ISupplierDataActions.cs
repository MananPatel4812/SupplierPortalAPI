using DataAccess.Entities;

namespace DataAccess.DataActions.Interfaces
{
    public interface ISupplierDataActions: IDisposable
    {
        //User
        int AddUser(UserEntity user);
        IEnumerable<UserEntity> GetAllUsers();
        IEnumerable<UserEntity> GetAllUsersByRoleId(int RoleId);
        UserEntity GetUserById(int userId);
        int UpdateUser(UserEntity user);
        bool IsUniqueUserEmail(string email);

        //Supplier
        bool AddSupplier(SupplierEntity supplier);
        IEnumerable<SupplierEntity> GetAllSuppliers();
        SupplierEntity GetSupplierById(int SupplierId);
        bool UpdateSupplier(SupplierEntity supplier);//, int SupplierId);

        //Contact
        bool AddContact(ContactEntity contact);
        IEnumerable<ContactEntity> GetAllContacts();
        IEnumerable<ContactEntity> GetAllContactsBySupplier(int SupplierId);
        bool UpdateContact(ContactEntity contact, int ContactId);

        //SupplyChainStages
        IEnumerable<SupplyChainStageEntity> GetSupplyChainStages();

        //Facility
        bool AddFacility(FacilityEntity facility);
        IEnumerable<FacilityEntity> GetAllFacilities();
        IEnumerable<FacilityEntity> GetFacilitiesByReportingType(int ReportingTypeId);
        FacilityEntity GetFacilityById(int FacilityId);
        bool UpdateFacility(FacilityEntity facility, int FacilityId);

        //AssociatePipeline
        bool AddAssociatePipeline(AssociatePipelineEntity associatePipeline);
        IEnumerable<AssociatePipelineEntity> GetAllAssociatePipeline();
        AssociatePipelineEntity GetAssociatePipelineById(int AssociatePipelineId);
        bool UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int AssociatePipelineId);

    }
}
