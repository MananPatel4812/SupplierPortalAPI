using DataAccess.DataActions.Interfaces;
using DataAccess.DataActionsContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions
{
    internal class ReportingPeriodDataActionsManager : IReportingPeriodDataActions
    {
        private readonly SupplierPortalDBContext _context;
        public ReportingPeriodDataActionsManager(SupplierPortalDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddReportingPeriod(ReportingPeriod reportingPeriod)
        {
            await _context.ReportingPeriods.AddAsync(reportingPeriod);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReportingPeriodFacility>> GetReportingPeriodFacilities(int SupplierId, int ReportingPeriodId)
        {
            return await _context.ReportingPeriodFacilities
                                        .Include(x => x.Facility)
                                        .Include(x => x.FacilityReportingPeriodDataStatus)
                                        .Include(x => x.ReportingType)
                                        .Include(x => x.ReportingPeriodSupplier)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriodFacilityDocument>> GetReportingPeriodFacilitiesDocument(int DocumentId)
        {
            return await _context.ReportingPeriodFacilityDocuments
                                    .Include(x => x.ReportingPeriodFacility)
                                    .Include(x => x.DocumentStatus)
                                    .Include(x => x.DocumentType)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriodSupplierDocument>> GetReportingPeriodSuppliersDocument(int DocumentId)
        {
            return await _context.ReportingPeriodSupplierDocuments
                                        .Include(x => x.ReportingPeriodSupplier)
                                        .Include(x => x.DocumentStatus)
                                        .Include(x => x.DocumentType)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriod>> GetReportingPeriods(int ReportingPeriodId)
        {
            return await _context.ReportingPeriods
                                    .Include(x => x.ReportingPeriodType)
                                    .Include(x => x.ReportingPeriodStatus)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriodStatus>> GetReportingPeriodStatus()
        {
            return await _context.ReportingPeriodStatuses.ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriodSupplier>> GetReportingPeriodSuppliers(int ReportingPeriodId)
        {
            return await _context.ReportingPeriodSuppliers
                                    .Include(x => x.Supplier)
                                    .Include(x => x.ReportingPeriod)
                                    .Include(x => x.SupplierReportingPeriodStatus)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<ReportingPeriodType>> GetReportingPeriodTypes()
        {
            return await _context.ReportingPeriodTypes.ToListAsync();
        }

        public async Task<IEnumerable<DocumentRequiredStatus>> GetDocumentRequiredStatus()
        {
            return await _context.DocumentRequiredStatuses.ToListAsync();
        }

        public async Task<IEnumerable<DocumentStatus>> GetDocumentStatus()
        {
            return await _context.DocumentStatuses.ToListAsync();
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentType()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<IEnumerable<FacilityReportingPeriodDataStatus>> GetFacilityReportingPeriodDataStatus()
        {
            return await _context.FacilityReportingPeriodDataStatuses.ToListAsync();
        }

        public async Task<IEnumerable<FacilityRequiredDocumentType>> GetFacilityRequiredDocumentType()
        {
            return await _context.FacilityRequiredDocumentTypes
                                        .Include(x => x.ReportingType)
                                        .Include(x => x.SupplyChainStage)
                                        .Include(x => x.DocumentType)
                                        .Include(x => x.DocumentRequiredStatus)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<SupplierReportingPeriodStatus>> GetSupplierReportingPeriodStatus()
        {
            return await _context.SupplierReportingPeriodStatuses.ToListAsync();
        }
    }
}
