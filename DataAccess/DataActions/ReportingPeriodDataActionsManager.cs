using DataAccess.DataActionContext;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataActions;

public class ReportingPeriodDataActionsManager : IReportingPeriodDataActions
{
    private readonly SupplierPortalDBContext _context;
    public ReportingPeriodDataActionsManager(SupplierPortalDBContext context)
    {
        _context = context;
    }

    #region Add Methods
    public async Task<bool> AddReportingPeriod(ReportingPeriod reportingPeriod)
    {
        await _context.ReportingPeriods.AddAsync(reportingPeriod);

        reportingPeriod.CreatedBy = "System";
        reportingPeriod.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddReportingPeriodFacilityDocument(ReportingPeriodFacilityDocument reportingPeriodFacilityDocument)
    {
        await _context.ReportingPeriodFacilityDocuments.AddAsync(reportingPeriodFacilityDocument);

        reportingPeriodFacilityDocument.CreatedBy = "System";
        reportingPeriodFacilityDocument.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddReportingPeriodSupplierDocument(ReportingPeriodSupplierDocument reportingPeriodSupplierDocument)
    {
        await _context.ReportingPeriodSupplierDocuments.AddAsync(reportingPeriodSupplierDocument);

        reportingPeriodSupplierDocument.CreatedBy = "System";
        reportingPeriodSupplierDocument.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    #endregion

    #region Update Methods
    public async Task<bool> UpdateReportingPeriod(ReportingPeriod reportingPeriod)
    {
        var existingperiod = await _context.ReportingPeriods.FirstOrDefaultAsync(x => x.Id == reportingPeriod.Id);
        
        if (existingperiod == null)
        {
            throw new Exception("Existing ReportingPeriod not found");
        }
        existingperiod.ReportingPeriodTypeId = reportingPeriod.ReportingPeriodTypeId;
        existingperiod.CollectionTimePeriod = reportingPeriod.CollectionTimePeriod;
        existingperiod.ReportingPeriodStatusId = reportingPeriod.ReportingPeriodStatusId;
        existingperiod.StartDate = reportingPeriod.StartDate;
        existingperiod.EndDate = reportingPeriod.EndDate;
        existingperiod.Active = reportingPeriod.Active;
        existingperiod.UpdatedOn = DateTime.UtcNow;
        existingperiod.UpdatedBy = "System";

        _context.ReportingPeriods.Update(existingperiod);
        await _context.SaveChangesAsync();

        return true;
    }



    public async Task<bool> UpdateReportingPeriodFacilityDocument(ReportingPeriodFacilityDocument reportingPeriodFacilityDocument)
    {
        var existingfacilitydocument = await _context.ReportingPeriodFacilityDocuments.FirstOrDefaultAsync(x => x.Id == reportingPeriodFacilityDocument.Id);

        if (existingfacilitydocument == null)
        {
            throw new Exception("Facility Document Not found");
        }

        existingfacilitydocument.ReportingPeriodFacilityId = reportingPeriodFacilityDocument.ReportingPeriodFacilityId;
        existingfacilitydocument.Version = reportingPeriodFacilityDocument.Version;
        existingfacilitydocument.DisplayName = reportingPeriodFacilityDocument.DisplayName;
        existingfacilitydocument.StoredName = reportingPeriodFacilityDocument.StoredName;
        existingfacilitydocument.Path = reportingPeriodFacilityDocument.Path;
        existingfacilitydocument.DocumentStatusId = reportingPeriodFacilityDocument.DocumentStatusId;
        existingfacilitydocument.DocumentTypeId = reportingPeriodFacilityDocument.DocumentTypeId;
        existingfacilitydocument.ValidationError = reportingPeriodFacilityDocument.ValidationError;
        existingfacilitydocument.UpdatedBy = "System";
        existingfacilitydocument.UpdatedOn = DateTime.UtcNow;

        _context.ReportingPeriodFacilityDocuments.Update(existingfacilitydocument);
        await _context.SaveChangesAsync();

        return true;
    }



    public async Task<bool> UpdateReportingPeriodSupplierDocument(ReportingPeriodSupplierDocument reportingPeriodSupplierDocument)
    {
        var existingsupplierdocument = await _context.ReportingPeriodSupplierDocuments.FirstOrDefaultAsync(x => x.Id == reportingPeriodSupplierDocument.Id);

        if (existingsupplierdocument == null)
        {
            throw new Exception("Supplier Document Not found");
        }

        existingsupplierdocument.ReportingPeriodSupplierId = reportingPeriodSupplierDocument.ReportingPeriodSupplierId;
        existingsupplierdocument.Version = reportingPeriodSupplierDocument.Version;
        existingsupplierdocument.DisplayName = reportingPeriodSupplierDocument.DisplayName;
        existingsupplierdocument.StoredName = reportingPeriodSupplierDocument.StoredName;
        existingsupplierdocument.Path = reportingPeriodSupplierDocument.Path;
        existingsupplierdocument.DocumentStatusId = reportingPeriodSupplierDocument.DocumentStatusId;
        existingsupplierdocument.DocumentTypeId = reportingPeriodSupplierDocument.DocumentTypeId;
        existingsupplierdocument.ValidationError = reportingPeriodSupplierDocument.ValidationError;
        existingsupplierdocument.UpdatedBy = "System";
        existingsupplierdocument.UpdatedOn = DateTime.UtcNow;

        _context.ReportingPeriodSupplierDocuments.Update(existingsupplierdocument);
        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region Get Methods
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

    #endregion

}
