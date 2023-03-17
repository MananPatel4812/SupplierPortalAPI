using BusinessLogic.ReferenceLookups;
using BusinessLogic.SupplierRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class PeriodFacility
    {
        private HashSet<Facility> facilities;
        private HashSet<FacilityReportingPeriodDataStatus> facilityReportingPeriodDataStatuses;
        private HashSet<ReportingType> reportingTypes;
        //private HashSet<ReportingPeriodSupplier> ReportingPeriodSuppliers;

        public PeriodFacility()
        {
            facilities = new HashSet<Facility>();
            facilityReportingPeriodDataStatuses = new HashSet<FacilityReportingPeriodDataStatus>();
            reportingTypes = new HashSet<ReportingType>();
        }

        public PeriodFacility(int id) : this()
        {
            Id = id;
        }

        public int Id { get; set; }

        public IEnumerable<Facility> Facilities
        {
            get
            {
                if (facilities == null)
                {
                    return new List<Facility>();
                }
                return facilities.ToList();
            }
        }

        public IEnumerable<FacilityReportingPeriodDataStatus> FacilityReportingPeriodDataStatus
        {
            get
            {
                if (facilityReportingPeriodDataStatuses == null)
                {
                    return new List<FacilityReportingPeriodDataStatus>();
                }
                return facilityReportingPeriodDataStatuses.ToList();
            }
        }

        public IEnumerable<ReportingType> ReportingType
        {
            get
            {
                if (reportingTypes == null)
                {
                    return new List<ReportingType>();
                }
                return reportingTypes.ToList();
            }
        }
    }
}
