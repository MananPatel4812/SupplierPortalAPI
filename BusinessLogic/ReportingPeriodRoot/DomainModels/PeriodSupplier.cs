using BusinessLogic.ReferenceLookups;
using BusinessLogic.SupplierRoot.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class PeriodSupplier
    {
        private HashSet<Supplier> Suppliers;
        private HashSet<ReportingPeriod> reportingPeriods;
        private HashSet<SupplierReportingPeriodStatus> supplierReportingPeriodStatus;

        public PeriodSupplier()
        {
            Suppliers = new HashSet<Supplier>();
            reportingPeriods = new HashSet<ReportingPeriod>();
            supplierReportingPeriodStatus = new HashSet<SupplierReportingPeriodStatus>();
        }

        public PeriodSupplier(int id) : this()
        {
            Id = id;
        }

        public int Id { get; set; }

        public IEnumerable<Supplier> Supplier
        {
            get
            {
                if(Suppliers == null)
                {
                    return new List<Supplier>();
                }
                return Suppliers.ToList();
            }
        }

        public IEnumerable<ReportingPeriod> ReportingPeriod
        {
            get
            {
                if(reportingPeriods == null)
                {
                    return new List<ReportingPeriod>();
                }
                return reportingPeriods.ToList();
            }
        }

        public IEnumerable<SupplierReportingPeriodStatus> SupplierReportingPeriodStatus
        {
            get
            {
                if(supplierReportingPeriodStatus == null)
                {
                    return new List<SupplierReportingPeriodStatus>();
                }
                return supplierReportingPeriodStatus.ToList();
            }
        }
    }
}
