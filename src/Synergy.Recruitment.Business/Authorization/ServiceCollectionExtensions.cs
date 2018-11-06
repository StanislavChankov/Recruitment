using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Synergy.Recruitment.Business.Authorization
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Public methods

        /// <summary>
        /// Adds the authorization handler to the service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public static void AddAuthorizationHandler<TProvider, TActions>(this IServiceCollection serviceCollection)
            where TProvider : class, IAuthorizationProvider
            where TActions : class
        {
            RegisterDependencies<TProvider>(serviceCollection);

            IEnumerable<RoleAction> applicationSpecificRoleActions = GetRoleActionsFromType(typeof(TActions));

            AddAuthorization(serviceCollection, applicationSpecificRoleActions);
        }

        public static void AddAuthorizationHandler<TProvider>(this IServiceCollection serviceCollection)
            where TProvider : class, IAuthorizationProvider
        {
            RegisterDependencies<TProvider>(serviceCollection);

            IEnumerable<RoleAction> roleActions = GetRoleActionsFromType(typeof(RoleActions));

            AddAuthorization(serviceCollection, roleActions);
        }

        #endregion

        #region Private methods

        private static void RegisterDependencies<TProvider>(IServiceCollection serviceCollection)
            where TProvider : class, IAuthorizationProvider
        {
            serviceCollection.AddScoped<IAuthorizationHandler, ActionsAuthorizationHandler>();
            serviceCollection.AddScoped<IAuthorizationProvider, TProvider>();
        }

        private static void AddAuthorization(IServiceCollection serviceCollection, IEnumerable<RoleAction> roleActions)
        {
            serviceCollection.AddAuthorization(options =>
            {
                foreach (RoleAction roleAction in roleActions)
                {
                    options.AddPolicy(roleAction.Name, policyBuider => policyBuider.Requirements.Add(roleAction));
                }
            });
        }

        private static IEnumerable<RoleAction> GetRoleActionsFromType(Type type)
        {
            IEnumerable<RoleAction> roleActions = type
                .GetTypeInfo()
                .GetProperties()
                .Where(p => p.PropertyType == typeof(RoleAction))
                .Select(p => p.GetValue(typeof(RoleAction)) as RoleAction)
                .ToArray();

            if (!roleActions.Any())
            {
                throw new InvalidOperationException($"Unable to find RoleActions for the provided class {type.Name}");
            }

            return roleActions;
        }

        #endregion
    }
}
