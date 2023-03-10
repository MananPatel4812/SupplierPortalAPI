using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions.Interfaces
{
    public interface IReportingPeriodDataActions
    {
        Task<IEnumerable<ReportingPeriodEntity>> GetReportingPeriods(int ReportingPeriodId);

        Task<IEnumerable<ReportingPeriodTypeEntity>> GetReportingPeriodTypes();

        Task<IEnumerable<ReportingPeriodStatusEntity>> GetReportingPeriodStatus();

        Task<bool> AddReportingPeriod(ReportingPeriodEntity reportingPeriod);

        Task<bool> UpdateReportingPeriod(ReportingPeriodEntity reportingPeriod);

        Task<bool> AddReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument);

        Task<bool> UpdateReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument);

        Task<bool> AddReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument);

        Task<bool> UpdateReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument);

        Task<IEnumerable<ReportingPeriodFacilityEntity>> GetReportingPeriodFacilities(int SupplierId,int ReportingPeriodId);

        Task<IEnumerable<ReportingPeriodFacilityDocumentEntity>> GetReportingPeriodFacilitiesDocument(int DocumentId);

        Task<IEnumerable<ReportingPeriodSupplierDocumentEntity>> GetReportingPeriodSuppliersDocument(int DocumentId);

        Task<IEnumerable<ReportingPeriodSupplierEntity>> GetReportingPeriodSuppliers(int ReportingPeriodId);

        Task<IEnumerable<SupplierReportingPeriodStatusEntity>> GetSupplierReportingPeriodStatus();

        Task<IEnumerable<FacilityReportingPeriodDataStatusEntity>> GetFacilityReportingPeriodDataStatus();

        Task<IEnumerable<DocumentRequiredStatusEntity>> GetDocumentRequiredStatus();

        Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatus();

        Task<IEnumerable<DocumentTypeEntity>> GetDocumentType();

        Task<IEnumerable<FacilityRequiredDocumentTypeEntity>> GetFacilityRequiredDocumentType();
    }
}
