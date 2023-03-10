using BusinessLogic.ReferenceLookups;

namespace BusinessLogic.ReportingPeriodRoot.ValueObjects
{
    public class ActiveSupplier
    {
        public int PeriodId { get; set; }
        public SupplierVO SupplierVO { get; set; }
        public bool IsActiveForPeriod { get; set; }
        public SupplierReportingPeriodStatus SupplierReportingPeriodStatus { get; set; }
        public bool SendInitialDataRequest { get; set; }
        public bool ResendDataRequest { get; set; }
        public DateTime InitialDataRequestSentDate { get; set; }
        public DateTime ResendDataRequestSentDate { get; set; }

        public ActiveSupplier(int periodId, SupplierVO supplierVO, bool isActiveForPeriod, SupplierReportingPeriodStatus supplierReportingPeriodStatus, bool sendInitialDataRequest, bool resendDataRequest, DateTime initialDataRequestSentDate, DateTime resendDataRequestSentDate)
        {
            PeriodId = periodId;
            SupplierVO = supplierVO;
            IsActiveForPeriod = isActiveForPeriod;
            SupplierReportingPeriodStatus = supplierReportingPeriodStatus;
            SendInitialDataRequest = sendInitialDataRequest;
            ResendDataRequest = resendDataRequest;
            InitialDataRequestSentDate = initialDataRequestSentDate;
            ResendDataRequest = resendDataRequest;
            InitialDataRequestSentDate = initialDataRequestSentDate;
            ResendDataRequestSentDate = resendDataRequestSentDate;
        }


    }
}
