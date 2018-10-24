using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

using Synergy.Recruitment.Business.Services;
using Synergy.Recruitment.Core.Repositories;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Repositories;

namespace Synergy.Recruitment.Api.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options => options.AddPolicy("AllowAll", p =>
                                            p.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()));

            services.AddMvc();

            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<ICandidateService, CandidateService>();

            services
                .AddDbContextPool<ApplicationDbContext>(builder =>
                {
                    builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "recruitment api", Version = "v1" }));

            return services.CreateDIProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruitment API V1"));
        }
    }
}
