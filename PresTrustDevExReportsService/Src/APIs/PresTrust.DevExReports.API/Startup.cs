using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb.Native;
using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PresTrust.DevExReports.API.Domain;
using PresTrust.DevExReports.API.Extensions;
using PresTrust.DevExReports.API.Services;
using PresTrust.DevExReports.API.Configurators;
using static PresTrust.DevExReports.API.Domain.DevExReportsDomainConstants;

namespace PresTrust.DevExReports.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
            DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted;
        }

        public IFileProvider FileProvider { get; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDevExpressControls();
            services.RegisterDependencies(Configuration);
            services.AddControllers();
            services.AddHttpContextAccessor();
            var connectionString = new ConnectionStringConfiguration(Configuration.GetConnectionString(AppSettingKeys.PRESTRUST_SQL_DB_CONNECTION_STRING_SECTION));
            services.AddSingleton(connectionString);
            services.AddScoped<CountyDashboardConfigurator>();
            services.AddScoped<AgencyDashboardConfigurator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "PresTrust.DevExReports.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(AppSettingKeys.CORS_POLICY_NAME);
            app.UseStaticFiles();
            app.UseDevExpressControls();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/header", "CountyHeaderDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/openspace", "CountyOpenspaceDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/historic", "CountyHistoricDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/flood", "CountyFloodDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/farmland", "CountyFarmlandDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/trails", "CountyTrailsDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/mua", "CountyMuaDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "county/park", "CountyParkDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/header", "AgencyHeaderDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/openspace", "AgencyOpenspaceDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/historic", "AgencyHistoricDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/flood", "AgencyFloodDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/farmland", "AgencyFarmlandDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/trails", "AgencyTrailsDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/mua", "AgencyMuaDashboard");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "agency/park", "AgencyParkDashboard");
                endpoints.MapControllers();
            });

            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new CustomReportStorageWebExtension(env));
        }
    }
}
