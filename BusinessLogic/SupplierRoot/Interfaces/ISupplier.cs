using BusinessLogic.ReferenceLookups;
using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;

namespace BusinessLogic.SupplierRoot.Interfaces
{
    public interface ISupplier
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Alias { get; set; }
        string Email { get; set; }
        string ContactNo { get; set; }
        bool IsActive { get; set; }

        IEnumerable<Facility> Facilities { get; }
        IEnumerable<Contact> Contacts { get; }

        Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage);
        Facility UpdateSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage);

        Contact AddSupplierContact(int contactId, Supplier supplier, UserVO userVO);
        Contact UpdateSupplierContact(int contactId, Supplier supplier, UserVO userVO);
        void ValidateUserContactNo(string contactNo);

    }
}
