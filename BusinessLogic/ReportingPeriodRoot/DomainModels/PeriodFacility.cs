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
        private HashSet<Facility> Facilities;
        private HashSet<FacilityReportingPeriodDataStatus> FacilityReportingPeriodDataStatuses;
        private HashSet<ReportingType> ReportingTypes;
        //private HashSet<ReportingPeriodSupplier> ReportingPeriodSuppliers;

        public PeriodFacility()
        {
            Facilities = new HashSet<Facility>();
            FacilityReportingPeriodDataStatuses = new HashSet<FacilityReportingPeriodDataStatus>();
            ReportingTypes = new HashSet<ReportingType>();
        }

        public PeriodFacility(int id) : this()
        {
            Id = id;
        }

        public int Id { get; set; }

        public IEnumerable<Facility> Facilitie
        {
            get
            {
                if(Facilities == null)
                {
                    return new List<Facility>();
                }
                return Facilities.ToList();
            }
        }

        public IEnumerable<FacilityReportingPeriodDataStatus> FacilityReportingPeriodDataStatus
        {
            get
            {
                if(FacilityReportingPeriodDataStatuses == null)
                {
                    return new List<FacilityReportingPeriodDataStatus>();
                }
                return FacilityReportingPeriodDataStatuses.ToList();
            }
        }

        public IEnumerable<ReportingType> ReportingType
        {
            get
            {
                if(ReportingTypes == null)
                {
                    return new List<ReportingType>();
                }
                return ReportingTypes.ToList();
            }
        }
    }
namespace BusinessLogic.ReportingPeriodRoot.DomainModels;

public class PeriodFacility
{
}
