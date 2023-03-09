using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.Interfaces
{
    public interface IReportingPeriod
    {
        int Id { get; set; }
        string DisplayName { get; set; }
        string CollectionTimePeriod { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        bool Active { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        string? UpdatedBy { get; set; }

        IEnumerable<ReportingPeriodType> ReportingPeriodType { get; }
        IEnumerable<ReportingPeriodStatus> ReportingPeriodStatus { get; }
        
        IEnumerable<PeriodSupplier> PeriodSuppliers { get; }

        void AddPeriodSupplier(int id, int supplierId, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus);
        void AddPeriodFacilityToPeriodSupplier(int supplierId,FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus,ReportingType reportingType,int reportingPeriodSupplierId);
        void AddDocumentToPeriodSupplierFacility(DocumentType documentType,DocumentStatus documentStatus);
        PeriodFacilityDocument RemoveDocumentFromPeriodSupplierFacility(int supplierId,int periodFacilityId,int documentId);
        PeriodFacilityDocument AddDataSubmissionDocumentForReportingPeriod(int supplierId,int periodFacilityId, DataAccess.Entities.FacilityRequiredDocumentType facilityRequiredDocumentType,IEnumerable<DocumentRequirementStatus> documentRequirementStatus);
        PeriodSupplierDocument AddSupplementalDataDocumentToReportingPeriodSupplier(int supplierId,string documentName,DocumentType documentType,IEnumerable<DocumentStatus> documentStatus);
        PeriodSupplierDocument RemoveSupplementalDataDocumentToReportingPeriodSupplier(int supplierId,int documentId);
        IEnumerable<PeriodFacility> UpdateDataStatusToSubmittedForCompletePeriodFacility(int supplierId,FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus);


    }
}
