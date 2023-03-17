using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using BusinessLogic.SupplierRoot.ValueObjects;
using BusinessLogic.ValueConstants;
using DataAccess.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class ReportingPeriod : IReportingPeriod
    {
        private HashSet<PeriodSupplier> periodSupplier;
        private readonly string REPORTING_PERIOD_NAME_PREFIX = "Reporting Period Data";
        public ReportingPeriod(ReportingPeriodType types, string collectionTimePeriod, ReportingPeriodStatus status, DateTime startDate, DateTime? endDate, bool isActive)
        {
            ValidateReportingPeriod(collectionTimePeriod, startDate, endDate, types);
            DisplayName = GeneratedReportingPeriodName(types);
            CollectionTimePeriod = collectionTimePeriod;
            ReportingPeriodType = types;
            ReportingPeriodStatus = status;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
        }

        public ReportingPeriod(int id, string displayName, ReportingPeriodType types, string collectionTimePeriod, ReportingPeriodStatus status, DateTime startDate, DateTime? endDate, bool isActive) : this(types, collectionTimePeriod, status, startDate, endDate, isActive)
        {
            Id = id;
        }
        public ReportingPeriod()
        {
            periodSupplier = new HashSet<PeriodSupplier>();
        }

        public int Id { get; private set; }
        public string DisplayName { get; private set; }
        public string CollectionTimePeriod { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }

        public ReportingPeriodType ReportingPeriodType { get; private set; }

        public ReportingPeriodStatus ReportingPeriodStatus { get; private set; }


        private string[] SplitCollectionTimePeriod()
        {
            return CollectionTimePeriod.Split(" ");
        }

        private string GeneratedReportingPeriodName(ReportingPeriodType reportingPeriodType)
        {
            var reportingPeriodName = REPORTING_PERIOD_NAME_PREFIX;
            switch (reportingPeriodType.Name)
            {
                case ReportingPeriodTypeValues.Annual:
                    reportingPeriodName = $"{reportingPeriodName} year";
                    break;
                case ReportingPeriodTypeValues.Quartly:
                    reportingPeriodName = $"{reportingPeriodName} quarterly";
                    break;
                case ReportingPeriodTypeValues.Monthly:
                    reportingPeriodName = $"{reportingPeriodName} monthly";
                    break;
                default:
                    reportingPeriodName = $"{reportingPeriodName} {SplitCollectionTimePeriod().FirstOrDefault()}";
                    break;
            }
            return $"{reportingPeriodName}";
        }

        private void ValidateReportingPeriod(string collectionTimePeriod, DateTime startDate, DateTime? endDate, ReportingPeriodType reportingPeriodType)
        {
            if (string.IsNullOrWhiteSpace(collectionTimePeriod))
                throw new ArgumentNullException("CollectionTimePeriod can not be null");

            if (startDate == null)
                throw new ArgumentNullException("StartDate can not be null");

            if (reportingPeriodType != null && reportingPeriodType.Name == ReportingPeriodTypeValues.Annual)
            {
                int convertedCollectionTimePeriod = Convert.ToInt32(collectionTimePeriod);
                if (convertedCollectionTimePeriod.ToString().Length != 4)
                    throw new ArgumentException("Collection time period should be in year only");
            }

            if (reportingPeriodType != null && reportingPeriodType.Name == ReportingPeriodTypeValues.Quartly)
            {
                string convertedCollectionTimePeriod = Convert.ToString(collectionTimePeriod);
                if (convertedCollectionTimePeriod.ToString().Length != 7)
                    throw new ArgumentException("Collection time period should be in quartly(ex: 2021-Q1) only");
            }

            if (reportingPeriodType != null && reportingPeriodType.Name == ReportingPeriodTypeValues.Monthly)
            {
                string convertedCollectionTimePeriod = Convert.ToString(collectionTimePeriod);
                if (convertedCollectionTimePeriod.ToString().Length != 8)
                    throw new ArgumentException("Collection time period should be in monthly(ex: Jan-2021) only");
            }

        }

        public IEnumerable<PeriodSupplier> PeriodSuppliers
        {
            get
            {
                if (periodSupplier == null)
                {
                    return new List<PeriodSupplier>();
                }
                return periodSupplier.ToList();
            }
        }

        public void UpdateReportingPeriod(int reportingPeriodTypeId, string collectionTimePeriod, int reportingPeriodStatusId, DateTime startDate, DateTime? endDate, bool isActive)
        {
            ReportingPeriodType.Id = reportingPeriodTypeId;
            CollectionTimePeriod = collectionTimePeriod;
            ReportingPeriodStatus.Id = reportingPeriodStatusId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            UpdatedOn = DateTime.UtcNow;
            UpdatedBy = "System";
        }


        public PeriodSupplier LoadPeriodSupplier(int id, SupplierVO supplier, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus, bool isActive)
        {
            var reportingPeriodSupplier = new PeriodSupplier(id, supplier, reportingPeriodId, supplierReportingPeriodStatus, isActive);

            if (periodSupplier.Contains(reportingPeriodSupplier))
            {
                throw new Exception("Supplier Already Exist!");
            }
            periodSupplier.Add(reportingPeriodSupplier);

            return reportingPeriodSupplier;


        }

        public PeriodSupplier AddPeriodSupplier(SupplierVO supplier, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus, bool isActive)
        {
            var reportingPeriodSupplier = new PeriodSupplier(supplier, reportingPeriodId, supplierReportingPeriodStatus, isActive);

            if (periodSupplier.Contains(reportingPeriodSupplier))
            {
                throw new Exception("Supplier Already Exist!");
            }
            periodSupplier.Add(reportingPeriodSupplier);

            return reportingPeriodSupplier;
        }

        public PeriodSupplier RemovePeriodSupplier(int periodSupplierId)
        {
            return null;
        }

        
        public PeriodFacilityDocument AddDataSubmissionDocumentForReportingPeriod(int supplierId, int periodFacilityId, FacilityRequiredDocumentTypeEntity facilityRequiredDocumentType, IEnumerable<DocumentRequirementStatus> documentRequirementStatus)
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
