using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class ReportingPeriod : IReportingPeriod
    {
        private HashSet<PeriodSupplier> periodSupplier;
        private HashSet<ReportingPeriodType> reportingPeriodTypes;
        private HashSet<ReportingPeriodStatus> reportingPeriodStatus;

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string CollectionTimePeriod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public IEnumerable<ReportingPeriodType> ReportingPeriodType
        {
            get
            {
                if(reportingPeriodTypes == null)
                {
                    return new List<ReportingPeriodType>();
                }
                return reportingPeriodTypes.ToList();
            }
        }

        public IEnumerable<ReportingPeriodStatus> ReportingPeriodStatus
        {
            get
            {
                if(reportingPeriodStatus == null)
                {
                    return new List<ReportingPeriodStatus>();
                }
                return reportingPeriodStatus.ToList();
            }
        }

        public IEnumerable<PeriodSupplier> PeriodSuppliers
        {
            get
            {
                if(periodSupplier == null)
                {
                    return new List<PeriodSupplier>();
                }
                return periodSupplier.ToList();
            }
        }

        public PeriodFacilityDocument AddDataSubmissionDocumentForReportingPeriod(int supplierId, int periodFacilityId, DataAccess.Entities.FacilityRequiredDocumentType facilityRequiredDocumentType, IEnumerable<DocumentRequirementStatus> documentRequirementStatus)
        {
            throw new NotImplementedException();
        }

        public void AddDocumentToPeriodSupplierFacility(DocumentType documentType, DocumentStatus documentStatus)
        {
            throw new NotImplementedException();
        }

        public void AddPeriodFacilityToPeriodSupplier(int supplierId, FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus, ReportingType reportingType, int reportingPeriodSupplierId)
        {
            throw new NotImplementedException();
        }

        public void AddPeriodSupplier(int id, int supplierId, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus)
        {
            throw new NotImplementedException();
        }

        public PeriodSupplierDocument AddSupplementalDataDocumentToReportingPeriodSupplier(int supplierId, string documentName, DocumentType documentType, IEnumerable<DocumentStatus> documentStatus)
        {
            throw new NotImplementedException();
        }

        public PeriodFacilityDocument RemoveDocumentFromPeriodSupplierFacility(int supplierId, int periodFacilityId, int documentId)
        {
            throw new NotImplementedException();
        }

        public PeriodSupplierDocument RemoveSupplementalDataDocumentToReportingPeriodSupplier(int supplierId, int documentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PeriodFacility> UpdateDataStatusToSubmittedForCompletePeriodFacility(int supplierId, FacilityReportingPeriodDataStatus facilityReportingPeriodDataStatus)
        {
            throw new NotImplementedException();
        }
    }
}
