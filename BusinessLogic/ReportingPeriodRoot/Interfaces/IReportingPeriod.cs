﻿using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.Interfaces
{
    public interface IReportingPeriod
    {
        int Id { get; }
        string DisplayName { get; }
        string CollectionTimePeriod { get; }
        DateTime StartDate { get; }
        DateTime? EndDate { get; }
        bool IsActive { get; }
        DateTime CreatedOn { get; }
        DateTime? UpdatedOn { get; }
        string CreatedBy { get; }
        string? UpdatedBy { get; }

        ReportingPeriodType ReportingPeriodType { get; }
        ReportingPeriodStatus ReportingPeriodStatus { get;}
        
        IEnumerable<PeriodSupplier> PeriodSuppliers { get; }

        void AddPeriodSupplier(int id, int supplierId, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus);
        void AddPeriodFacilityToPeriodSupplier(int supplierId,FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus,ReportingType reportingType,int reportingPeriodSupplierId);
        void AddDocumentToPeriodSupplierFacility(DocumentType documentType,DocumentStatus documentStatus);
        PeriodFacilityDocument RemoveDocumentFromPeriodSupplierFacility(int supplierId,int periodFacilityId,int documentId);
        PeriodFacilityDocument AddDataSubmissionDocumentForReportingPeriod(int supplierId,int periodFacilityId, FacilityRequiredDocumentTypeEntity facilityRequiredDocumentType,IEnumerable<DocumentRequirementStatus> documentRequirementStatus);
        PeriodSupplierDocument AddSupplementalDataDocumentToReportingPeriodSupplier(int supplierId,string documentName,DocumentType documentType,IEnumerable<DocumentStatus> documentStatus);
        PeriodSupplierDocument RemoveSupplementalDataDocumentToReportingPeriodSupplier(int supplierId,int documentId);
        IEnumerable<PeriodFacility> UpdateDataStatusToSubmittedForCompletePeriodFacility(int supplierId,FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus);

        //IEnumerable<ReportingPeriodTypeEntity> RetrieveReportingPeriodType(ReportingPeriodType reportingPeriodType);

    }
}
