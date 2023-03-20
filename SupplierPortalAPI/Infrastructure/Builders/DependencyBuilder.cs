using DataAccess.DataActions;
using DataAccess.DataActions.Interfaces;
using Services;
using Services.Factories;
using Services.Factories.Interface;
using Services.Factories.Interfaces;
using Services.Interfaces;
using Services.Mappers.Interfaces;
using Services.Mappers.SupplierMappers;
using Services.Mappers.ReportingPeriodMappers;
using Services.Mappers.UserMappers;
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
            services.AddTransient<ISupplierServices, SupplierServices>();
            services.AddTransient<ISupplierDataActions,SupplierDataActionsManager>();
            services.AddTransient<ISupplierFactory, SupplierFactory>();
            services.AddTransient<ISupplierEntityDomainMapper, SupplierEntityDomainMapper>();
            services.AddTransient<ISupplierDomainDtoMapper, SupplierDomainDtoMapper>();

            //User
            services.AddTransient<IUserDomainDtoMapper,UserDomainDtoMapper>();
            services.AddTransient<IUserEntityDomainMapper,UserEntityDomainMapper>();
            services.AddTransient<IUserDomainDtoMapper, UserDomainDtoMapper>();
            services.AddTransient<IUserEntityDomainMapper, UserEntityDomainMapper>();
            services.AddTransient<IUserFactory, UserFactory>();

            //ReportingPeriod
            services.AddTransient<IReportingPeriod, ReportingPeriod>();
            services.AddTransient<IReportingPeriodServices, ReportingPeriodServices>();
            services.AddTransient<IReportingPeriodDataActions,ReportingPeriodDataActionsManager>();
            services.AddTransient<IReportingPeriodFactory, ReportingPeriodFactory>();
            services.AddTransient<IReportingPeriodDomainDtoMapper, ReportingPeriodDomainDtoMapper>();
            services.AddTransient<IReportingPeriodEntityDomainMapper, ReportingPeriodEntityDomainMapper>();
            services.AddTransient<IReadOnlyEntityToDtoMapper, ReadOnlyEntityToDtoMapper>();
            services.AddTransient<IReportingPeriod, ReportingPeriod>();
            services.AddTransient<IReferenceLookUpMapper, ReferenceLookupMapper>();
            //services.AddScoped<IServiceCollection, ServiceCollection>();    
        }

    }
}
