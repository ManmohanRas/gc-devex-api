using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Mvc;
using DevExpress.AspNetCore.Reporting.QueryBuilder;
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;
using DevExpress.AspNetCore.Reporting.ReportDesigner;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.DataProtection;
using PresTrust.DevExReports.API.Configurators;

namespace PresTrust.DevExReports.API.Controllers
{

    public class CountyHeaderDashboardController : DashboardController
    {
        public CountyHeaderDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyOpenspaceDashboardController : DashboardController
    {
        public CountyOpenspaceDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyHistoricDashboardController : DashboardController
    {
        public CountyHistoricDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyFloodDashboardController : DashboardController
    {
        public CountyFloodDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyFarmlandDashboardController : DashboardController
    {
        public CountyFarmlandDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyTrailsDashboardController : DashboardController
    {
        public CountyTrailsDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyMuaDashboardController : DashboardController
    {
        public CountyMuaDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class CountyParkDashboardController : DashboardController
    {
        public CountyParkDashboardController(CountyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyHeaderDashboardController : DashboardController
    {
        public AgencyHeaderDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyOpenspaceDashboardController : DashboardController
    {
        public AgencyOpenspaceDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyHistoricDashboardController : DashboardController
    {
        public AgencyHistoricDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyFloodDashboardController : DashboardController
    {
        public AgencyFloodDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyFarmlandDashboardController : DashboardController
    {
        public AgencyFarmlandDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyTrailsDashboardController : DashboardController
    {
        public AgencyTrailsDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyMuaDashboardController : DashboardController
    {
        public AgencyMuaDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }

    public class AgencyParkDashboardController : DashboardController
    {
        public AgencyParkDashboardController(AgencyDashboardConfigurator configurator, IDataProtectionProvider dataProtectionProvider = null) : base(configurator, dataProtectionProvider) { }
    }
}
