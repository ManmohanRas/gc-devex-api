using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace PresTrust.DevExReports.API.Configurators
{
    public class CountyDashboardConfigurator : DashboardConfigurator
    {
        private readonly string programType;
        public CountyDashboardConfigurator(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            programType = httpContextAccessor.HttpContext.Request.Headers["User_ProgramType"];
            if (programType == null)
                programType = httpContextAccessor.HttpContext.Request.Form["User_ProgramType"];
            if (programType != null)
                programType = Uri.UnescapeDataString(programType);

            SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));
            AllowExecutingCustomSql = true;
            SetDashboardStorage(new CountyDashboardStorage(hostingEnvironment, programType));
            CustomParameters += CustomCountyDashboardConfigurator_CustomParameters;
        }

        private void CustomCountyDashboardConfigurator_CustomParameters(object sender, CustomParametersWebEventArgs e)
        {
            e.Parameters.Add(new Parameter("User_ProgramType", typeof(string), programType));
        }
    }

    public class AgencyDashboardConfigurator : DashboardConfigurator
    {
        private readonly string programType;
        private readonly string agencyIds;
        public AgencyDashboardConfigurator(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            programType = httpContextAccessor.HttpContext.Request.Headers["User_ProgramType"];
            if (programType == null)
                programType = httpContextAccessor.HttpContext.Request.Form["User_ProgramType"];
            if (programType != null)
                programType = Uri.UnescapeDataString(programType);

            agencyIds = httpContextAccessor.HttpContext.Request.Headers["User_AgencyIds"];
            if (agencyIds == null)
                agencyIds = httpContextAccessor.HttpContext.Request.Form["User_AgencyIds"];
            if (agencyIds != null)
                agencyIds = Uri.UnescapeDataString(agencyIds);

            SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));
            AllowExecutingCustomSql = true;
            SetDashboardStorage(new AgencyDashboardStorage(hostingEnvironment, programType));
            CustomParameters += CustomAgencyDashboardConfigurator_CustomParameters;
        }

        private void CustomAgencyDashboardConfigurator_CustomParameters(object sender, CustomParametersWebEventArgs e)
        {
            string[] agencyIdsArr = agencyIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> agencyIdsList = new List<int>();
            foreach (var item in agencyIdsArr)
            {
                int id = 0;
                int.TryParse(item, out id);
                if (id > 0 && !agencyIdsList.Contains(id))
                    agencyIdsList.Add(id);
            }
            e.Parameters.Add(new Parameter("User_ProgramType", typeof(string), programType));
            e.Parameters.Add(new Parameter("User_AgencyIds", typeof(List<int>), agencyIdsList));
        }
    }
}
