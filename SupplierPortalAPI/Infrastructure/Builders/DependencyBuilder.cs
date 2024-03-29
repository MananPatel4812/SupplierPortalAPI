﻿using DataAccess.DataActions;
using DataAccess.DataActions.Interfaces;
using Services;
using Services.Factories;
using Services.Factories.Interface;
using Services.Factories.Interfaces;
using Services.Interfaces;
using Services.Mappers.Interfaces;
using Services.Mappers.SupplierMappers;
using Services.Mappers.ReportingPeriodMappers;
using BusinessLogic.ReportingPeriodRoot.Interfaces;
using BusinessLogic.ReportingPeriodRoot.DomainModels;

namespace SupplierPortalAPI.Infrastructure.Builders
{
    public static class DependencyBuilder
    {

        public static void AddDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<ISupplierServices, SupplierServices>();

            //Supplier
            services.AddScoped<ISupplierServices, SupplierServices>();
            services.AddScoped<ISupplierDataActions, SupplierDataActionsManager>();
            services.AddScoped<ISupplierFactory, SupplierFactory>();
            services.AddSingleton<ISupplierEntityDomainMapper, SupplierEntityDomainMapper>();
            services.AddSingleton<ISupplierDomainDtoMapper, SupplierDomainDtoMapper>();

            //ReportingPeriod
            services.AddScoped<IReportingPeriod, ReportingPeriod>();
            services.AddScoped<IReportingPeriodServices, ReportingPeriodServices>();
            services.AddScoped<IReportingPeriodDataActions, ReportingPeriodDataActionsManager>();
            services.AddScoped<IReportingPeriodFactory, ReportingPeriodFactory>();
            services.AddSingleton<IReportingPeriodDomainDtoMapper, ReportingPeriodDomainDtoMapper>();
            services.AddSingleton<IReportingPeriodEntityDomainMapper, ReportingPeriodEntityDomainMapper>();
            services.AddSingleton<IReadOnlyEntityToDtoMapper, ReadOnlyEntityToDtoMapper>();
            services.AddScoped<IReportingPeriod, ReportingPeriod>();
            services.AddSingleton<IReferenceLookUpMapper, ReferenceLookupMapper>();
            //services.AddScoped<IServiceCollection, ServiceCollection>();    
        }

    }
}
