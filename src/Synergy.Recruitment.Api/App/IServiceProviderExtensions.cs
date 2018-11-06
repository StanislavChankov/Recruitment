using System;
using System.Reflection;

using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Synergy.Recruitment.Business.Authorization;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App
{
    public static class IServiceProviderExtensions
    {
        #region Fields

        private static readonly Func<string, Assembly> Load = (assemblyName) => Assembly.Load(new AssemblyName(assemblyName));

        private static readonly Func<ILifetime> CreateScopeLifetyme = () => new PerScopeLifetime();

        private static readonly Func<Type, Type, bool> FilterByCoreInterfaces = (service, implementation) =>
            service.GetTypeInfo().IsAbstract &&
            service.Name != nameof(IDisposable) &&
            service.Namespace.StartsWith(Constants.RECRUITMENT_CORE_ASSEMBLY_NAME);

        #endregion

        #region Public Methods

        /// <summary>
        /// Create LightInject service provider that resolve objects.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>LightInject service provider with already registered services.</returns>
        public static IServiceProvider CreateDIProvider(this IServiceCollection serviceCollection)
        {
            var container = new ServiceContainer(new ContainerOptions() { EnablePropertyInjection = false });
            container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
        
            // Register all data repositories.
            container.RegisterAssembly(Load(Constants.Recruitment_DATA_ASSEMBLY_NAME), CreateScopeLifetyme, FilterByCoreInterfaces);

            // Register all services.
            container.RegisterAssembly(Load(Constants.Recruitment_BUSINESS_ASSEMBLY_NAME), CreateScopeLifetyme, FilterByCoreInterfaces);

            // Add context accessors
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return container.CreateServiceProvider(serviceCollection);
        }

        #endregion
    }
}
