﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReportingPeriodFacilityEntity
    {
        public ReportingPeriodFacilityEntity()
        {
            ReportingPeriodFacilityDocumentEntities = new HashSet<ReportingPeriodFacilityDocumentEntity>();
        }

        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int FacilityReportingPeriodDataStatusId { get; set; }
        public int ReportingTypeId { get; set; }
        public int ReportingPeriodSupplierId { get; set; }

        public virtual FacilityEntity Facility { get; set; } = null!;
        public virtual FacilityReportingPeriodDataStatusEntity FacilityReportingPeriodDataStatus { get; set; } = null!;
        public virtual ReportingPeriodSupplierEntity ReportingPeriodSupplier { get; set; } = null!;
        public virtual ReportingTypeEntity ReportingType { get; set; } = null!;
        public virtual ICollection<ReportingPeriodFacilityDocumentEntity> ReportingPeriodFacilityDocumentEntities { get; set; }
    }
}
