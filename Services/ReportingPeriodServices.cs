using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.Factories.Interface;
using Services.Interfaces;
using Services.Mappers.Interfaces;
using System.ComponentModel.Design;

namespace Services;

public class ReportingPeriodServices : IReportingPeriodServices
{
    private IReportingPeriodFactory _reportingPeriodFactory;
    private readonly ILogger _logger;
    private IReportingPeriodEntityDomainMapper _reportingPeriodEntityDomainMapper;
    private IReportingPeriodDataActions _reportingPeriodDataActions;
    private ISupplierDataActions _supplierDataActions;
    private IReferenceLookUpMapper _referenceLookUpMapper;
    private IReportingPeriod _reportingPeriod;


    public ReportingPeriodServices(IReportingPeriodFactory reportingPeriodFactory, ILoggerFactory loggerFactory, IReportingPeriodEntityDomainMapper reportingPeriodEntityDomainMapper, IReportingPeriodDataActions reportingPeriodDataActions,ISupplierDataActions supplierDataActions, IReferenceLookUpMapper referenceLookUpMapper, IReportingPeriod reportingPeriod)
    {
        _reportingPeriodFactory = reportingPeriodFactory;
        _logger = loggerFactory.CreateLogger<SupplierServices>();
        _reportingPeriodEntityDomainMapper = reportingPeriodEntityDomainMapper;
        _reportingPeriodDataActions = reportingPeriodDataActions;
        _supplierDataActions = supplierDataActions;
        _referenceLookUpMapper = referenceLookUpMapper;
        _reportingPeriod = reportingPeriod;
    }

    private IEnumerable<ReportingPeriodType> GetAndConvertReportingPeriodType()
    {
        var reportingPeriodTypeEntity = _reportingPeriodDataActions.GetReportingPeriodTypes();

        return _referenceLookUpMapper.GetReportingPeriodTypesLookUp(reportingPeriodTypeEntity);
    }

    private IEnumerable<ReportingPeriodStatus> GetAndConvertReportingPeriodStatus()
    {
        var reportingPeriodStatusEntity = _reportingPeriodDataActions.GetReportingPeriodStatus();

        return _referenceLookUpMapper.GetReportingPeriodStatusesLookUp(reportingPeriodStatusEntity);
    }


    private IEnumerable<SupplierReportingPeriodStatus> GetAndConvertSupplierPeriodStatus()
    {
        var supplierPeriodStatusEntity = _reportingPeriodDataActions.GetSupplierReportingPeriodStatus();

        return _referenceLookUpMapper.GetSupplierReportingPeriodStatusesLookUp(supplierPeriodStatusEntity);
    }

    public async Task<string> AddUpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)

    {
        if (reportingPeriodDto.Id == 0)
        {
            var reportingPeriodTypes = GetAndConvertReportingPeriodType().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodTypeId);
            var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodStatusId);

            if (reportingPeriodStatuses is null)
                throw new Exception("Unable to retrieve reporting period Status for the identifier");

            if (reportingPeriodTypes is null)
                throw new Exception("Unable to retrieve reporting period Status for the identifier");

            var reportingPeriod = _reportingPeriodFactory.CreateNewReportingPeriod(reportingPeriodTypes, reportingPeriodDto.CollectionTimePeriod, reportingPeriodStatuses, reportingPeriodDto.StartDate, reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);

            var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
            await _reportingPeriodDataActions.AddReportingPeriod(reportingPeriodEntity);
        }
        else
        {
            //Fetch record by id
            var reportingPeriod = RetrieveAndConvertReportingPeriod(reportingPeriodDto.Id ?? 0);
            reportingPeriod.UpdateReportingPeriod(reportingPeriodDto.ReportingPeriodTypeId, reportingPeriodDto.CollectionTimePeriod, reportingPeriodDto.ReportingPeriodStatusId, reportingPeriodDto.StartDate, reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);

            //Convert domain to entity
            var entity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
            await _reportingPeriodDataActions.UpdateReportingPeriod(entity);
        }

        return "Success";
    }
    public async Task<string> SetPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto)
    {
        var reportingPeriodEntity = _reportingPeriodDataActions.GetReportingPeriodById(reportingPeriodSupplierDto.ReportingPeriodId);
        var supplierEntity = _supplierDataActions.GetSupplierById(reportingPeriodSupplierDto.SupplierId);
        
        var reportingPeriodTypes = GetAndConvertReportingPeriodType();
        var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus();
        var supplierPeriodStatuses = GetAndConvertSupplierPeriodStatus();

        var reportingPeriod = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity, reportingPeriodTypes, reportingPeriodStatuses);

        if (supplierEntity.IsActive == true)
        {
            var supplierPeriodStatus = supplierPeriodStatuses.FirstOrDefault(x => x.Id == reportingPeriodSupplierDto.SupplierReportingPeriodStatusId);
            
            var supplierVO = _reportingPeriodEntityDomainMapper.ConvertSupplierToSupplierValueObject(supplierEntity);

            var periodSupplierList = _reportingPeriodDataActions.GetPeriodSuppliers();
            var counter = 0;

            foreach(var periodSupplier in periodSupplierList)
            {
                if(periodSupplier.SupplierId == supplierVO.Id && periodSupplier.ReportingPeriodId == reportingPeriod.Id)
                {
                    throw new Exception("ReportingPeriod Supplier already exists!!");
                }
                else
                {
                    counter++;
                }
            }

            if(counter > 0)
            {
                var periodSupplier = reportingPeriod.AddPeriodSupplier(supplierVO, reportingPeriodSupplierDto.ReportingPeriodId, supplierPeriodStatus, reportingPeriodSupplierDto.IsActive);
                var periodSupplierEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodSupplierDomainToEntity(periodSupplier);
                await _reportingPeriodDataActions.AddPeriodSupplier(periodSupplierEntity);
            }
          
        }
        else
        {
            throw new Exception("Supplier is inActive");
        }
        
        return "Success";
    }

    private ReportingPeriod GetAndConvertReportingPeriodSupplierToDomain(int reportingPeriodId)
    {
        var reportingPeriodSuppliers = _reportingPeriodDataActions.GetReportingPeriodSuppliers(reportingPeriodId);
        var periodEntity = _reportingPeriodDataActions.GetReportingPeriodById(reportingPeriodId);
        var reportingPeriodTypes = GetAndConvertReportingPeriodType();
        var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus();

        ReportingPeriod reportingPeriod = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(periodEntity, reportingPeriodTypes, reportingPeriodStatuses);

        var supplierPeriodStatuses = GetAndConvertSupplierPeriodStatus();

        foreach (var reportingPeriodSupplier in reportingPeriodSuppliers)
        {
            var supplierEntity = reportingPeriodSupplier.Supplier;
            var supplierVO = _reportingPeriodEntityDomainMapper.ConvertSupplierToSupplierValueObject(supplierEntity);
            var supplierPeriodStatus = supplierPeriodStatuses.FirstOrDefault(x => x.Id == reportingPeriodSupplier.SupplierReportingPeriodStatusId);

            _reportingPeriod.LoadPeriodSupplier(reportingPeriodSupplier.Id,supplierVO, reportingPeriodId, supplierPeriodStatus ?? new SupplierReportingPeriodStatus(),reportingPeriodSupplier.IsActive);
        }
        return reportingPeriod;

    }
    private ReportingPeriod RetrieveAndConvertReportingPeriod(int reportingPeriodId)
    {
        var reportingPeriodEntity = _reportingPeriodDataActions.GetReportingPeriodById(reportingPeriodId);
        var reportingPeriodTypes = GetAndConvertReportingPeriodType();
        var reportingPeriodStatus = GetAndConvertReportingPeriodStatus();

        if (reportingPeriodEntity is null)
            throw new ArgumentNullException("Unable to retrieve reporting period entity");

        var periodDomain = ConfigureReportingPeriod(reportingPeriodEntity, reportingPeriodTypes, reportingPeriodStatus);

        var supplierReportingPeriodStatuses = GetAndConvertSupplierPeriodStatus();

        _reportingPeriodEntityDomainMapper.ConvertPeriodSupplierEntityToDomain(periodDomain, reportingPeriodEntity.ReportingPeriodSupplierEntities, supplierReportingPeriodStatuses);
        return periodDomain;

    }

    private ReportingPeriod ConfigureReportingPeriod(ReportingPeriodEntity reportingPeriodEntity, IEnumerable<ReportingPeriodType> reportingPeriodTypes, IEnumerable<ReportingPeriodStatus> reportingPeriodStatuses)
    {
        var reportingPeriodType = reportingPeriodTypes.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodTypeId).ToList();
        var reportingPeriodStatus = reportingPeriodStatuses.Where(x => x.Id == reportingPeriodEntity.ReportingPeriodStatusId).ToList();

        //Convert entity to domain
        var reportingPeriodDomain = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity, reportingPeriodType, reportingPeriodStatus);
        return reportingPeriodDomain;

    }

    
}
