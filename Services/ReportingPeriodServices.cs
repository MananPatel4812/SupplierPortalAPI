using BusinessLogic.ReferenceLookups;
using BusinessLogic.ReportingPeriodRoot.DomainModels;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using BusinessLogic.SupplierRoot.ValueObjects;
using DataAccess.DataActions.Interfaces;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.DTOs.ReadOnlyDTOs;
using Services.Factories.Interface;
using Services.Interfaces;
using Services.Mappers.Interfaces;

namespace Services;

public class ReportingPeriodServices : IReportingPeriodServices
{
    private IReportingPeriodFactory _reportingPeriodFactory;
    private readonly ILogger _logger;
    private IReportingPeriodEntityDomainMapper _reportingPeriodEntityDomainMapper;
    private IReadOnlyEntityToDtoMapper _readOnlyEntityToDtoMapper;
    private IReportingPeriodDataActions _reportingPeriodDataActions;
    private ISupplierDataActions _supplierDataActions;
    private IReferenceLookUpMapper _referenceLookUpMapper;
    private IReportingPeriod _reportingPeriod;



    public ReportingPeriodServices(IReportingPeriodFactory reportingPeriodFactory, ILoggerFactory loggerFactory,
        IReportingPeriodDomainDtoMapper reportingPeriodDomainMapper, IReportingPeriodEntityDomainMapper reportingPeriodEntityDomainMapper, IReadOnlyEntityToDtoMapper readOnlyEntityToDtoMapper, IReportingPeriodDataActions reportingPeriodDataActions, ISupplierDataActions supplierDataActions, IReferenceLookUpMapper referenceLookUpMapper, IReportingPeriod reportingPeriod)

    {
        _reportingPeriodFactory = reportingPeriodFactory;
        _logger = loggerFactory.CreateLogger<SupplierServices>();
        _reportingPeriodEntityDomainMapper = reportingPeriodEntityDomainMapper;
        _readOnlyEntityToDtoMapper = readOnlyEntityToDtoMapper;
        _reportingPeriodDataActions = reportingPeriodDataActions;
        _supplierDataActions = supplierDataActions;
        _referenceLookUpMapper = referenceLookUpMapper;
        _reportingPeriod = reportingPeriod;
    }

    #region Private Methods

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

    private SupplierVO GetAndConvertSupplierValueObject(int supplierId)
    {
        var supplierEntity = _supplierDataActions.GetSupplierById(supplierId);

        if (supplierEntity == null)
        {
            throw new ArgumentNullException("Unable to retrive Supplier");
        }
        var supplierVO = _reportingPeriodEntityDomainMapper.ConvertSupplierToSupplierValueObject(supplierEntity);
        return supplierVO;
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

            _reportingPeriod.LoadPeriodSupplier(reportingPeriodSupplier.Id, supplierVO, reportingPeriodId, supplierPeriodStatus ?? new SupplierReportingPeriodStatus());
        }
        return reportingPeriod;

    }

    private ReportingPeriod RetrieveAndConvertReportingPeriodAndReportingPeriodSupplier(int reportingPeriodId)
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

    //private ReportingPeriod ConfigurePeriodSupplier(ReportingPeriodSupplierEntity reportingPeriodSupplierEntity, ReportingPeriodEntity reportingPeriodEntity,SupplierVO supplierVO,IEnumerable<SupplierReportingPeriodStatus> supplierReportingPeriodStatuses)
    //{
    //    var supplierReportingPeriodStatus = supplierReportingPeriodStatuses.Where(x => x.Id == reportingPeriodSupplierEntity.SupplierReportingPeriodStatusId).ToList();

    //    _reportingPeriodEntityDomainMapper.ConvertPeriodSupplierEntityToDomain(RetrieveAndConvertReportingPeriod(reportingPeriodEntity.Id), new List<ReportingPeriodSupplierEntity>() { reportingPeriodSupplierEntity}, supplierReportingPeriodStatus);

    //    return supplierDomain;

    //}

    //private ReportingPeriod RetrieveAndConvertPeriodSupplier(int reportingPeriodId,int supplierId)
    //{
    //    var reportingPeriodEntity = RetrieveAndConvertReportingPeriod(reportingPeriodId);
    //    var supplierEntity = _supplierDataActions.GetSupplierById(supplierId);
    //    var supplierPeriodStatus = GetAndConvertSupplierPeriodStatus();

    //    if(supplierEntity is null)
    //    {
    //        throw new ArgumentNullException("Unable to retrieve Supplier Entity");
    //    }
    //    var supplierVO = _reportingPeriodEntityDomainMapper.ConvertSupplierToSupplierValueObject(supplierEntity);



    //    return reportingPeriodEntity;



    //}



    #endregion

    #region Add-Update-Remove Methods


    /// <summary>
    /// SetReportingPeriod
    /// </summary>
    /// <param name="reportingPeriodDto"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddUpdateReportingPeriod(ReportingPeriodDto reportingPeriodDto)

    {
        if (reportingPeriodDto.Id == 0)
        {
            //Add ReportingPeriod =>

            var reportingPeriodTypes = GetAndConvertReportingPeriodType().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodTypeId);
            var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus().FirstOrDefault(x => x.Id == reportingPeriodDto.ReportingPeriodStatusId);

            if (reportingPeriodTypes is null)
                throw new Exception("Unable to retrieve ReportingPeriodType");
            if (reportingPeriodStatuses is null)
                throw new Exception("Unable to retrieve ReportingPeriodStatus");



            var reportingPeriod = _reportingPeriodFactory.CreateNewReportingPeriod(reportingPeriodTypes, reportingPeriodDto.CollectionTimePeriod, reportingPeriodStatuses, reportingPeriodDto.StartDate, reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);

            var reportingPeriodEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
            await _reportingPeriodDataActions.AddReportingPeriod(reportingPeriodEntity);
        }
        else
        {
            //Update ReportingPeriod =>

            //Fetch record by id
            var reportingPeriod = RetrieveAndConvertReportingPeriodAndReportingPeriodSupplier(reportingPeriodDto.Id ?? 0);
            if (reportingPeriod == null)
            {
                throw new Exception("Unable to retrieve ReportingPeriod");
            }
            reportingPeriod.UpdateReportingPeriod(reportingPeriodDto.ReportingPeriodTypeId, reportingPeriodDto.CollectionTimePeriod, reportingPeriodDto.ReportingPeriodStatusId, reportingPeriodDto.StartDate, reportingPeriodDto.EndDate, reportingPeriodDto.IsActive);

            //Convert domain to entity
            var entity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodDomainToEntity(reportingPeriod);
            await _reportingPeriodDataActions.UpdateReportingPeriod(entity);
        }

        return "Reporting Period Added";
    }

    /// <summary>
    /// Add PeriodSupplier (Where Supplier should be Active & ReportingPeriod Should Be InActive)
    /// </summary>
    /// <param name="reportingPeriodSupplierDto"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> SetPeriodSupplier(ReportingPeriodSupplierDto reportingPeriodSupplierDto)
    {
        var reportingPeriodEntity = RetrieveAndConvertReportingPeriodAndReportingPeriodSupplier(reportingPeriodSupplierDto.ReportingPeriodId);
    
        var supplierPeriodStatus = GetAndConvertSupplierPeriodStatus().FirstOrDefault(x => x.Id == reportingPeriodSupplierDto.SupplierReportingPeriodStatusId);

        var periodSupplierList = _reportingPeriodDataActions.GetPeriodSuppliers();

        ///First Entry In Database
        if (periodSupplierList.Count() == 0)
        {
            goto AddCase;
        }
        var counter = 0;

        foreach (var periodSupplier in periodSupplierList)
        {
            if (periodSupplier.SupplierId == periodSupplier.Supplier.Id && periodSupplier.ReportingPeriodId == reportingPeriodEntity.Id)
            {
                throw new Exception("ReportingPeriod Supplier already exists!!");
            }
            else
            {
                counter++;
            }
        }

        if (counter > 0)
        {
            goto AddCase;
        }

    AddCase:
        {
            var periodSupplier = reportingPeriodEntity.AddPeriodSupplier(GetAndConvertSupplierValueObject(reportingPeriodSupplierDto.SupplierId), reportingPeriodSupplierDto.ReportingPeriodId,supplierPeriodStatus);
            var periodSupplierEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodSupplierDomainToEntity(periodSupplier);
            await _reportingPeriodDataActions.AddPeriodSupplier(periodSupplierEntity);
        }



        return "Success";
    }

    /// <summary>
    /// Update Lock-Unlock Status of PeriodSupplier
    /// </summary>
    /// <param name="periodSupplierId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool UpdateLockUnlockPeriodSupplier(int periodSupplierId)
    {

        var periodSupplierEntity = _reportingPeriodDataActions.GetPeriodSupplierById(periodSupplierId);

        var reportingPeriodEntity = _reportingPeriodDataActions.GetReportingPeriodById(periodSupplierEntity.ReportingPeriodId);

        var reportingPeriodTypes = GetAndConvertReportingPeriodType();
        var reportingPeriodStatuses = GetAndConvertReportingPeriodStatus();
        var supplierPeriodStatuses = GetAndConvertSupplierPeriodStatus();

        var periodDomain = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodEntityToDomain(reportingPeriodEntity, reportingPeriodTypes, reportingPeriodStatuses);

        _reportingPeriodEntityDomainMapper.ConvertPeriodSupplierEntityToDomain(periodDomain, new List<ReportingPeriodSupplierEntity>() { periodSupplierEntity }, supplierPeriodStatuses);

        var updatePeriodSupplierStatus = periodDomain.UpdatePeriodSupplierStatus(periodSupplierEntity.Id, supplierPeriodStatuses);
        periodSupplierEntity = _reportingPeriodEntityDomainMapper.ConvertReportingPeriodSupplierDomainToEntity(updatePeriodSupplierStatus);

        _reportingPeriodDataActions.UpdatePeriodSupplierStatus(periodSupplierEntity);
        return true;
    }

    /// <summary>
    /// Remove PeriodSupplier
    /// </summary>
    /// <param name="PeriodSupplierId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool RemovePeriodSupplier(int periodSupplierId)
    {
        //var periodSupplierRelevantFacility =  

        return _reportingPeriodDataActions.RemovePeriodSupplier(periodSupplierId);
    }


    #endregion

    #region Get Methods
    public IEnumerable<InternalReportingPeriodDTO> GetActiveReportingPeriods()
    {
        var activeReportingPeriods = _reportingPeriodDataActions.GetReportingPeriods().Where(x => x.IsActive == true);
        var reportingPeriodDto = new List<InternalReportingPeriodDTO>();
        foreach (var reportingPeriodEntity in activeReportingPeriods)
        {
            reportingPeriodDto.Add(_readOnlyEntityToDtoMapper.ConvertReportingPeriodEntityToInternalPeriodDTO(reportingPeriodEntity));
        }
        return reportingPeriodDto;
    }

    /// <summary>
    /// GetReportingPeriodSuppliers
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SupplierReportingPeriodDTO> GetReportingPeriodSuppliers(int ReportingPeriodId)
    {
        var periodSuppliers = _reportingPeriodDataActions.GetReportingPeriodSuppliers(ReportingPeriodId);
        var supplierReportingPeriodDTO = new List<SupplierReportingPeriodDTO>();

        foreach (var periodSupplierEntity in periodSuppliers)
        {
            supplierReportingPeriodDTO.Add(_readOnlyEntityToDtoMapper.
                ConvertReportingPeriodSupplierEntityToSupplierReportingPeriodDTO(periodSupplierEntity));
        }
        return supplierReportingPeriodDTO;
    }

    public IEnumerable<ReportingPeriodActiveSupplierDTO> GetActivePeriodSuppliers()
    {
        var activePeriodSuppliers = _reportingPeriodDataActions.GetPeriodSuppliers();
        var periodSupplierDto = new List<ReportingPeriodActiveSupplierDTO>();

        foreach (var periodSupplierEntity in activePeriodSuppliers)
        {
            if (periodSupplierEntity.Supplier.IsActive == true)
            {
                periodSupplierDto.Add(_readOnlyEntityToDtoMapper.ConvertReportingPeriodSupplierEntityToReportingPeriodActiveSupplier(periodSupplierEntity));
            }

        }

        return periodSupplierDto;
    }


    #endregion
}
