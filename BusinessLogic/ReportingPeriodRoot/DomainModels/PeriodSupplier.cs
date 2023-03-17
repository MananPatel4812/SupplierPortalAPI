using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.ValueObjects;
using BusinessLogic.SupplierRoot.DomainModels;
using BusinessLogic.SupplierRoot.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodRoot.DomainModels
{
    public class PeriodSupplier
    {
        public PeriodSupplier(SupplierVO supplier, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriodStatus,bool isActive)
        {
            Supplier = supplier;
            ReportingPeriodId = reportingPeriodId;
            SupplierReportingPeriodStatus = supplierReportingPeriodStatus;
            IsActive = isActive;

        }

        public PeriodSupplier(int id, SupplierVO supplierVO, int reportingPeriodId, SupplierReportingPeriodStatus supplierReportingPeriod, bool isActive) : this(supplierVO, reportingPeriodId, supplierReportingPeriod,isActive)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public SupplierVO Supplier { get; private set; }
        public int ReportingPeriodId { get; private set; }
        public SupplierReportingPeriodStatus SupplierReportingPeriodStatus { get; private set; }
        public bool IsActive { get; private set; }
    }
}
