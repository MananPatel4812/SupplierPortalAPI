using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.ValueObjects;
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
        public PeriodSupplier(SupplierVO supplierVO, int reportingPeriodId, int supplierReportingPeriodId)
        {
            SupplierVO = supplierVO;
            ReportingPeriodId = reportingPeriodId;
            SupplierReportingPeriodStatusId = supplierReportingPeriodId;
        }

        public PeriodSupplier(int id, SupplierVO supplierVO, int reportingPeriodId, int supplierReportingPeriodId) : this(supplierVO, reportingPeriodId, supplierReportingPeriodId)
        {
            Id = id;
        }

        public PeriodSupplier()
        {

        }

        public int Id { get; private set; }
        public SupplierVO SupplierVO { get; private set; }
        public int ReportingPeriodId { get; private set; }
        public int SupplierReportingPeriodStatusId { get; private set; }
    }
}
