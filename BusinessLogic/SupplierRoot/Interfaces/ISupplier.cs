using DataAccess.Entities;

namespace BusinessLogic.SupplierRoot.Interfaces
{
    public interface ISupplier
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Alias { get; set; }
        string Email { get; set; }
        string ContactNo { get; set; }
        bool Active { get; set; }

        IEnumerable<Facility> Facility { get; }
        IEnumerable<Contact> Contact { get; }

        Facility AddSupplierFacility(int Id, string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage);
        Facility UpdateSupplierFacility(int Id,string name, string description, bool isPrimary, AssociatePipeline AssociatePipeline, ReportingType ReportingType, SupplyChainStage SupplyChainStage);

        Contact AddSupplierContact(int Id, Supplier Supplier, User User);
        Contact UpdateSupplierContact(int Id, Supplier Supplier, User User);

    }
}
