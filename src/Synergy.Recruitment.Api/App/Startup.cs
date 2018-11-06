using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

using IdentityModel;
using IdentityModel.AspNetCore.OAuth2Introspection;

using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

using Swashbuckle.AspNetCore.Swagger;

using Synergy.Recruitment.Api.App.IdentityServer.Services;
using Synergy.Recruitment.Api.App.IdentityServer.Stores;
using Synergy.Recruitment.Business.Authorization;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Api.App
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration/*IHostingEnvironment env*/)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICustomTokenRequestValidator, ClientCredentialsTokenRequestValidator>();
            services.AddTransient<IProfileService, IdentityProfileService>();
            AddIdentityDependencies(services);

            services.AddMemoryCache();

            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddProfileService<IdentityProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddCustomTokenRequestValidator<ClientCredentialsTokenRequestValidator>()
                .AddInMemoryCaching();

            services
                .AddCors(options => options.AddPolicy("AllowAll", p =>
                                            p.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()));

            services.AddAuthorizationHandler<ApiAuthorizationProvider>();

            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration[Constants.SETTINGS_KEY_IDENITY_URL];
                    options.ApiName = IdentityServerConstants.RECRUITMENT_API;
                    options.ApiSecret = IdentityServerConstants.RECRUITMENT_API_SECRET;
                    options.RequireHttpsMetadata = false;
                    options.RoleClaimType = JwtClaimTypes.ClientId;
                    options.SupportedTokens = SupportedTokens.Both;
                    options.TokenRetriever = request =>
                    {
                        string token = TokenRetrieval.FromAuthorizationHeader()(request);

                        if (string.IsNullOrWhiteSpace(token))
                        {
                            token = TokenRetrieval.FromQueryString()(request);
                        }

                        return token;
                    };
                });

            services
                .AddDbContextPool<ApplicationDbContext>(builder =>
                {
                    builder.UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider()}));
                    builder.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
                });

            AddSwagger(services);

            services.AddAuthorization();

            services.AddMvc();

            services.AddAuthorizationHandler<AuthorizationProvider, RoleActions>();

            return services.CreateDIProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");

            app.UseIdentityServer();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruitment API V1"));
        }

        #region Private Methods
    
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Recruitment api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });
        }

        private static void AddIdentityDependencies(IServiceCollection services)
        {
            services.AddTransient<IClaimsService, IdentityClaimsService>();
            services.AddSingleton<IResourceStore, ResourcesStore>();
            services.AddSingleton<IClientStore, ClientStore>();
        }

        #endregion

    }
}
