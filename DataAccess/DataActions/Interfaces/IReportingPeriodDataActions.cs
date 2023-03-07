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
        Task<IEnumerable<ReportingPeriod>> GetReportingPeriods(int ReportingPeriodId);

        Task<IEnumerable<ReportingPeriodType>> GetReportingPeriodTypes();

        Task<IEnumerable<ReportingPeriodStatus>> GetReportingPeriodStatus();

        Task<bool> AddReportingPeriod(ReportingPeriod reportingPeriod);

        Task<bool> UpdateReportingPeriod(ReportingPeriod reportingPeriod);//

        Task<bool> AddReportingPeriodFacilityDocument(ReportingPeriodFacilityDocument reportingPeriodFacilityDocument);

        Task<bool> UpdateReportingPeriodFacilityDocument(ReportingPeriodFacilityDocument reportingPeriodFacilityDocument);

        Task<bool> AddReportingPeriodSupplierDocument(ReportingPeriodSupplierDocument reportingPeriodSupplierDocument);

        Task<bool> UpdateReportingPeriodSupplierDocument(ReportingPeriodSupplierDocument reportingPeriodSupplierDocument);

        Task<IEnumerable<ReportingPeriodFacility>> GetReportingPeriodFacilities(int SupplierId,int ReportingPeriodId);

        Task<IEnumerable<ReportingPeriodFacilityDocument>> GetReportingPeriodFacilitiesDocument(int DocumentId);

        Task<IEnumerable<ReportingPeriodSupplierDocument>> GetReportingPeriodSuppliersDocument(int DocumentId);

        Task<IEnumerable<ReportingPeriodSupplier>> GetReportingPeriodSuppliers(int ReportingPeriodId);

        Task<IEnumerable<SupplierReportingPeriodStatus>> GetSupplierReportingPeriodStatus();

        Task<IEnumerable<FacilityReportingPeriodDataStatus>> GetFacilityReportingPeriodDataStatus();

        Task<IEnumerable<DocumentRequiredStatus>> GetDocumentRequiredStatus();

        Task<IEnumerable<DocumentStatus>> GetDocumentStatus();

        Task<IEnumerable<DocumentType>> GetDocumentType();

        Task<IEnumerable<FacilityRequiredDocumentType>> GetFacilityRequiredDocumentType();
    }
}
