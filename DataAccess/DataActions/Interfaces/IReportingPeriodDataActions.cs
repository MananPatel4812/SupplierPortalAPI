using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions.Interfaces
{
    public interface IReportingPeriodDataActions : IDisposable
    {
        Task<IEnumerable<ReportingPeriodEntity>> GetReportingPeriods(int ReportingPeriodId);

        IEnumerable<ReportingPeriodTypeEntity> GetReportingPeriodTypes();

        IEnumerable<ReportingPeriodStatusEntity> GetReportingPeriodStatus();

        Task<bool> AddReportingPeriod(ReportingPeriodEntity reportingPeriodEntity);

        Task<bool> AddPeriodSupplier(ReportingPeriodSupplierEntity reportingPeriodSupplierEntity);

        Task<ReportingPeriodSupplierEntity> RemovePeriodSupplier(int reportingPeriodSupplierId);
        Task<bool> UpdateReportingPeriod(ReportingPeriodEntity reportingPeriod);
        ReportingPeriodEntity GetReportingPeriodById(int reportingPeriodId);
        IEnumerable<ReportingPeriodTypeEntity> GetReportingPeriodTypeById(int reportingPeriodTypeId);
        IEnumerable<ReportingPeriodStatusEntity> GetReportingPeriodStatusById(int reportingPeriodStatusId);
        
        Task<bool> AddReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument);

        Task<bool> UpdateReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument);

        Task<bool> AddReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument);

        Task<bool> UpdateReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument);

        Task<IEnumerable<ReportingPeriodFacilityEntity>> GetReportingPeriodFacilities(int SupplierId,int ReportingPeriodId);

        Task<IEnumerable<ReportingPeriodFacilityDocumentEntity>> GetReportingPeriodFacilitiesDocument(int DocumentId);

        Task<IEnumerable<ReportingPeriodSupplierDocumentEntity>> GetReportingPeriodSuppliersDocument(int DocumentId);

        IEnumerable<ReportingPeriodSupplierEntity> GetReportingPeriodSuppliers(int ReportingPeriodId);

        IEnumerable<SupplierReportingPeriodStatusEntity> GetSupplierReportingPeriodStatus();

        Task<IEnumerable<FacilityReportingPeriodDataStatusEntity>> GetFacilityReportingPeriodDataStatus();

        Task<IEnumerable<DocumentRequiredStatusEntity>> GetDocumentRequiredStatus();

        Task<IEnumerable<DocumentStatusEntity>> GetDocumentStatus();

        Task<IEnumerable<DocumentTypeEntity>> GetDocumentType();

        Task<IEnumerable<FacilityRequiredDocumentTypeEntity>> GetFacilityRequiredDocumentType();
    }
}
