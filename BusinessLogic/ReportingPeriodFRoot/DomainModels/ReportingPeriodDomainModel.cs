using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ReportingPeriodFRoot.DomainModels
{
    public class ReportingPeriodDomainModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public int ReportingPeriodTypeId { get; set; }
        public string CollectionTimePeriod { get; set; } = null!;
        public int ReportingPeriodStatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public ReportingPeriodDomainModel(int id,string displayName,int reportingPeriodTypeId,string collectionTimePeriod,int reportingPeriodStatusId,DateTime startDate,bool active)
        {
            Id = id;
            DisplayName = displayName;
            ReportingPeriodTypeId = reportingPeriodTypeId;
            CollectionTimePeriod = collectionTimePeriod;
            ReportingPeriodStatusId = reportingPeriodStatusId;
            StartDate = startDate;
            EndDate = null;
            Active = active;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = null;
            CreatedBy = "System";
            UpdatedBy = null;

        }
    }
}
