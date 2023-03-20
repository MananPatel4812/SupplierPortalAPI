using DataAccess.DataActionContext;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public async Task<bool> AddReportingPeriod(ReportingPeriodEntity reportingPeriod)
    {
        await _context.ReportingPeriodEntities.AddAsync(reportingPeriod);

        reportingPeriod.CreatedBy = "System";
        reportingPeriod.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddPeriodSupplier(ReportingPeriodSupplierEntity reportingPeriodSupplierEntity)
    {
        await _context.ReportingPeriodSupplierEntities.AddAsync(reportingPeriodSupplierEntity);

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument)
    {
        await _context.ReportingPeriodFacilityDocumentEntities.AddAsync(reportingPeriodFacilityDocument);

        reportingPeriodFacilityDocument.CreatedBy = "System";
        reportingPeriodFacilityDocument.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument)
    {
        await _context.ReportingPeriodSupplierDocumentEntities.AddAsync(reportingPeriodSupplierDocument);

        reportingPeriodSupplierDocument.CreatedBy = "System";
        reportingPeriodSupplierDocument.CreatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    #endregion

    #region Update Methods
    public async Task<bool> UpdateReportingPeriod(ReportingPeriodEntity reportingPeriod)
    {
        var existingReportingPeriod = await _context.ReportingPeriodEntities.FirstOrDefaultAsync(x => x.Id == reportingPeriod.Id);

        if (existingReportingPeriod == null)
            throw new Exception("Existing ReportingPeriod not found");

        existingReportingPeriod.ReportingPeriodTypeId = reportingPeriod.ReportingPeriodTypeId;
        existingReportingPeriod.CollectionTimePeriod = reportingPeriod.CollectionTimePeriod;
        existingReportingPeriod.ReportingPeriodStatusId = reportingPeriod.ReportingPeriodStatusId;
        existingReportingPeriod.StartDate = reportingPeriod.StartDate;
        existingReportingPeriod.EndDate = reportingPeriod.EndDate;
        existingReportingPeriod.IsActive = reportingPeriod.IsActive;
        existingReportingPeriod.UpdatedOn = DateTime.UtcNow;
        existingReportingPeriod.UpdatedBy = "System";

        _context.ReportingPeriodEntities.Update(existingReportingPeriod);
        await _context.SaveChangesAsync();
        return true;
    }



    public async Task<bool> UpdateReportingPeriodFacilityDocument(ReportingPeriodFacilityDocumentEntity reportingPeriodFacilityDocument)
    {
        var existingfacilitydocument = await _context.ReportingPeriodFacilityDocumentEntities.FirstOrDefaultAsync(x => x.Id == reportingPeriodFacilityDocument.Id);

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

        _context.ReportingPeriodFacilityDocumentEntities.Update(existingfacilitydocument);
        await _context.SaveChangesAsync();

        return true;
    }



    public async Task<bool> UpdateReportingPeriodSupplierDocument(ReportingPeriodSupplierDocumentEntity reportingPeriodSupplierDocument)
    {
        var existingsupplierdocument = await _context.ReportingPeriodSupplierDocumentEntities.FirstOrDefaultAsync(x => x.Id == reportingPeriodSupplierDocument.Id);

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

        _context.ReportingPeriodSupplierDocumentEntities.Update(existingsupplierdocument);
        await _context.SaveChangesAsync();

        return true;
    }
    #endregion

    #region Remove Methods

    public async Task<ReportingPeriodSupplierEntity> RemovePeriodSupplier(int reportingPeriodId)
    {
        var periodSupplier = _context.ReportingPeriodSupplierEntities.Find(reportingPeriodId);

        _context.ReportingPeriodSupplierEntities.Remove(periodSupplier);
        await _context.SaveChangesAsync();
        return periodSupplier;

    }

    #endregion

    #region Get Methods


    public IEnumerable<ReportingPeriodTypeEntity> GetReportingPeriodTypes()
    {
        return _context.ReportingPeriodTypeEntities;
    }

    public IEnumerable<ReportingPeriodStatusEntity> GetReportingPeriodStatus()
    {
        return _context.ReportingPeriodStatusEntities;
    }

    public IEnumerable<ReportingPeriodEntity> GetReportingPeriods()
    {
        var reportingPeriods = _context.ReportingPeriodEntities
                                .Include(x => x.ReportingPeriodType)
                                .Include(x => x.ReportingPeriodStatus)
                                .ToList();

        return reportingPeriods;
    }

    public IEnumerable<SupplierReportingPeriodStatusEntity> GetSupplierReportingPeriodStatus()
    {
        var reportingPeriodSupplier =
            _context.ReportingPeriodSupplierEntities
            .Include(x => x.Supplier)
            .Include(x => x.ReportingPeriod)
            .Include(x=>x.SupplierReportingPeriodStatus)
            .Where(x => x.ReportingPeriodId == reportingPeriodId).ToList();
        return reportingPeriodSupplier;

    }

    public IEnumerable<ReportingPeriodSupplierEntity> GetPeriodSuppliers()
    {
        var periodSuppliers = _context.ReportingPeriodSupplierEntities
                                .Include(x => x.Supplier)
                                .Include(x => x.ReportingPeriod)
                                .Include(x => x.SupplierReportingPeriodStatus)
                                .ToList();
        return periodSuppliers;
    }

    public IEnumerable<DocumentRequiredStatusEntity> GetDocumentRequiredStatus()
    {
        return _context.DocumentRequiredStatusEntities.ToList();
    }

    public IEnumerable<DocumentStatusEntity> GetDocumentStatus()
    {
        return _context.DocumentStatusEntities.ToList();
    }

    public IEnumerable<DocumentTypeEntity> GetDocumentType()
    {
        return _context.DocumentTypeEntities.ToList();
    }

    public IEnumerable<FacilityReportingPeriodDataStatusEntity> GetFacilityReportingPeriodDataStatus()
    {
        return _context.FacilityReportingPeriodDataStatusEntities.ToList();
    }

    public IEnumerable<FacilityRequiredDocumentTypeEntity> GetFacilityRequiredDocumentType()
    {
        return _context.FacilityRequiredDocumentTypeEntities
                                    .Include(x => x.ReportingType)
                                    .Include(x => x.SupplyChainStage)
                                    .Include(x => x.DocumentType)
                                    .Include(x => x.DocumentRequiredStatus)
                                    .ToList();
    }

    #endregion

    #region GetById
    public ReportingPeriodEntity GetReportingPeriodById(int reportingPeriodId)
    {
        var reportingPeriod = _context.ReportingPeriodEntities
                                .Include(x => x.ReportingPeriodType)
                                .Include(x => x.ReportingPeriodStatus)
                                .Include(x => x.ReportingPeriodSupplierEntities)
                                .FirstOrDefault(x => x.Id == reportingPeriodId);

        return reportingPeriod;
    }

    public IEnumerable<ReportingPeriodTypeEntity> GetReportingPeriodTypeById(int reportingPeriodTypeId)
    {
        var reportingPeriodType = _context.ReportingPeriodTypeEntities.Where(x => x.Id == reportingPeriodTypeId).ToList();

        return reportingPeriodType;
    }

    public IEnumerable<ReportingPeriodStatusEntity> GetReportingPeriodStatusById(int reportingPeriodStatusId)
    {
        var reportingPeriodStatus = _context.ReportingPeriodStatusEntities.Where(x => x.Id == reportingPeriodStatusId).ToList();
        return reportingPeriodStatus;
    }

    public IEnumerable<ReportingPeriodSupplierEntity> GetReportingPeriodSuppliers(int reportingPeriodId)
    {
        var reportingPeriodSupplier =
            _context.ReportingPeriodSupplierEntities.Include(x => x.Supplier).Where(x => x.ReportingPeriodId == reportingPeriodId).ToList();
        return reportingPeriodSupplier;

    }

    public async Task<IEnumerable<ReportingPeriodFacilityEntity>> GetReportingPeriodFacilities(int SupplierId, int ReportingPeriodId)
    {
        return await _context.ReportingPeriodFacilityEntities
                                    .Include(x => x.Facility)
                                    .Include(x => x.FacilityReportingPeriodDataStatus)
                                    .Include(x => x.ReportingType)
                                    .Include(x => x.ReportingPeriodSupplier)
                                    .ToListAsync();
    }

    public async Task<IEnumerable<ReportingPeriodFacilityDocumentEntity>> GetReportingPeriodFacilitiesDocument(int DocumentId)
    {
        return await _context.ReportingPeriodFacilityDocumentEntities
                                .Include(x => x.ReportingPeriodFacility)
                                .Include(x => x.DocumentStatus)
                                .Include(x => x.DocumentType)
                                .ToListAsync();
    }

    public async Task<IEnumerable<ReportingPeriodSupplierDocumentEntity>> GetReportingPeriodSuppliersDocument(int DocumentId)
    {
        return await _context.ReportingPeriodSupplierDocumentEntities
                                    .Include(x => x.ReportingPeriodSupplier)
                                    .Include(x => x.DocumentStatus)
                                    .Include(x => x.DocumentType)
                                    .ToListAsync();
    }

    public async Task<IEnumerable<ReportingPeriodEntity>> GetReportingPeriods(int ReportingPeriodId)
    {
        return await _context.ReportingPeriodEntities
                                .Include(x => x.ReportingPeriodType)
                                .Include(x => x.ReportingPeriodStatus)
                                .ToListAsync();
    }

    #endregion

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
}
