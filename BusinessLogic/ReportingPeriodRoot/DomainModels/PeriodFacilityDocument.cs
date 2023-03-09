using BusinessLogic.ReferenceLookups;
using BusinessLogic.SupplierRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class PeriodFacilityDocument
    {
        private HashSet<Supplier> Suppliers;
        private HashSet<PeriodFacility> PeriodFacilities;
        private HashSet<DocumentStatus> DocumentStatuses;
        private HashSet<DocumentType> DocumentTypes;

        public PeriodFacilityDocument(int reportingPeriodFacilityId, string version, string displayName,
                        string storedName, string path, string validationError)
        {
            ReportingPeriodFacilityId = reportingPeriodFacilityId;
            Version = version;
            DisplayName = displayName;
            StoredName = storedName;
            Path = path;
            ValidationError = validationError;

            DocumentStatuses = new HashSet<DocumentStatus>();
            DocumentTypes = new HashSet<DocumentType>();
            Suppliers = new HashSet<Supplier>();
            PeriodFacilities = new HashSet<PeriodFacility>();
        }

        public PeriodFacilityDocument(int id, int reportingPeriodFacilityId, string version, string displayName,
                        string storedName, string path, string validationError) : this(reportingPeriodFacilityId, version, displayName, storedName, path, validationError)
        {
            Id = id;
        }

        public PeriodFacilityDocument()
        {

        }

        public int Id { get; set; }
        public int ReportingPeriodFacilityId { get; set; }
        public string Version { get; set; }
        public string DisplayName { get; set; }
        public string StoredName { get; set; }
        public string Path { get; set; }
        public string ValidationError { get; set; }

        public IEnumerable<DocumentStatus> DocumentStatus
        {
            get
            {
                if (DocumentStatuses == null)
                {
                    return new List<DocumentStatus>();
                }
                return DocumentStatuses.ToList();
            }
        }

        public IEnumerable<DocumentType> DocumentType
        {
            get
            {
                if (DocumentTypes == null)
                {
                    return new List<DocumentType>();
                }
                return DocumentTypes.ToList();
            }
        }

        public IEnumerable<Supplier> Supplier
        {
            get
            {
                if (Suppliers == null)
                {
                    return new List<Supplier>();
                }
                return Suppliers.ToList();
            }
        }

        public IEnumerable<PeriodFacility> PeriodFacility
        {
            get
            {
                if (PeriodFacilities == null)
                {
                    return new List<PeriodFacility>();
                }
                return PeriodFacilities.ToList();
            }
        }

    }
}
