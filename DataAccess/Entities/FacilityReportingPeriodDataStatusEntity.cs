﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class FacilityReportingPeriodDataStatusEntity
    {
        public FacilityReportingPeriodDataStatusEntity()
        {
            ReportingPeriodFacilityEntities = new HashSet<ReportingPeriodFacilityEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<ReportingPeriodFacilityEntity> ReportingPeriodFacilityEntities { get; set; }
    }
}
