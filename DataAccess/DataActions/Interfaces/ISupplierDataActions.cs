using DataAccess.Entities;

namespace DataAccess.DataActions.Interfaces
{
    public interface ISupplierDataActions: IDisposable
    {
        //User
        int AddUser(UserEntity user);
        IEnumerable<UserEntity> GetAllUsers();
        IEnumerable<UserEntity> GetAllUsersByRoleId(int roleId);
        UserEntity GetUserById(int userId);
        bool UpdateUser(UserEntity user);
        bool IsUniqueEmail(string email, string entity);

        //Supplier
        bool AddSupplier(SupplierEntity supplier);
        IEnumerable<SupplierEntity> GetAllSuppliers();
        SupplierEntity GetSupplierById(int supplierId);
        bool UpdateSupplier(SupplierEntity supplier);

        //Contact
        bool AddContact(ContactEntity contact);
        IEnumerable<ContactEntity> GetAllContacts();
        IEnumerable<ContactEntity> GetAllContactsBySupplier(int supplierId);
        bool UpdateContact(ContactEntity contact, int contactId);

        //SupplyChainStages
        IEnumerable<SupplyChainStageEntity> GetSupplyChainStages();

        //Facility
        bool AddFacility(FacilityEntity facility);
        IEnumerable<FacilityEntity> GetAllFacilities();
        IEnumerable<FacilityEntity> GetFacilitiesByReportingType(int reportingTypeId);
        FacilityEntity GetFacilityById(int facilityId);
        bool UpdateFacility(FacilityEntity facility, int facilityId);

        //AssociatePipeline
        bool AddAssociatePipeline(AssociatePipelineEntity associatePipeline);
        IEnumerable<AssociatePipelineEntity> GetAllAssociatePipeline();
        AssociatePipelineEntity GetAssociatePipelineById(int associatePipelineId);
        bool UpdateAssociatePipeline(AssociatePipelineEntity associatePipeline, int associatePipelineId);

    }
}
