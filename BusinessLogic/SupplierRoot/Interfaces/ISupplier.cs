﻿using BusinessLogic.ReferenceLookups;
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

        Facility AddSupplierFacility(int facilityId, string name, string description, bool isPrimary, int supplierId, string? ghgrpFacilityId, AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage, bool isActive);
        Facility UpdateSupplierFacility(int facilityId, string name, string description, bool isPrimary, AssociatePipeline associatePipeline, ReportingType reportingType, SupplyChainStage supplyChainStage);

        Contact AddSupplierContact(int contactId, Supplier supplier, int userId, string userName, string email, string contactNo, bool isActive);
        Contact UpdateSupplierContact(int contactId, Supplier supplier, int userId, string userName, string email, string contactNo, bool isActive);
        void ValidateUserContactNo(string contactNo);

    }
}
