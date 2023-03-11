﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ReportingPeriodDto
    {
        public int? Id { get; set; }

        public string DisplayName { get; set; }

        public int ReportingPeriodTypeId { get; set; }

        public string ReportingPeriodType { get; set; }

        public string CollectionTimePeriod { get;set; }

        public int ReportingPeriodStatusId { get; set; }

        public string ReportingPeriodStatus { get;set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<ReportingPeriodSupplierDto> reportingPeriodSupplierDtos { get; set; }


        public ReportingPeriodDto(int? id, string displayName, int reportingPeriodTypeId, string reportingPeriodType, string collectionTimePeriod, int reportingPeriodStatusId, string reportingPeriodStatus, DateTime startDate, DateTime? endDate, bool isActive, List<ReportingPeriodSupplierDto> reportingPeriodSupplierDtos)
        {
            Id = id;
            DisplayName = displayName;
            ReportingPeriodTypeId = reportingPeriodTypeId;
            ReportingPeriodType = reportingPeriodType;
            CollectionTimePeriod = collectionTimePeriod;
            ReportingPeriodStatusId = reportingPeriodStatusId;
            ReportingPeriodStatus = reportingPeriodStatus;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            this.reportingPeriodSupplierDtos = reportingPeriodSupplierDtos;
        }
    }
}
