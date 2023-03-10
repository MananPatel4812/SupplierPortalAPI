using DataAccess.DataActions;
using DataAccess.DataActions.Interfaces;
using Services;
using Services.Factories;
using Services.Factories.Interface;
using Services.Interfaces;
using Services.Mappers.Interfaces;
using Services.Mappers.ReportingPeriodMappers;
using Services.Mappers.UserMappers;

namespace SupplierPortalAPI.Infrastructure.Builders
{
    public static class DependencyBuilder
    {

        public static void AddDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<ISupplierServices, SupplierServices>();
            services.AddTransient<ISupplierServices, SupplierServices>();
            services.AddTransient<IUserPersister, UserDataActionManager>();
            services.AddTransient<IUserDomainDtoMapper, UserDomainDtoMapper>();
            services.AddTransient<IUserEntityDomainMapper, UserEntityDomainMapper>();
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IReportingPeriodServices, ReportingPeriodServices>();
            services.AddTransient<IReportingPeriodDataActions,ReportingPeriodDataActionsManager>();
            services.AddTransient<IReportingPeriodFactory, ReportingPeriodFactory>();
            services.AddTransient<IReportingPeriodDomainDtoMapper, ReportingPeriodDomainDtoMapper>();
            services.AddTransient<IReportingPeriodEntityDomainMapper, ReportingPeriodEntityDomainMapper>();
            //services.AddScoped<IServiceCollection, ServiceCollection>();    
        }

    }
}
