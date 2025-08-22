using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PresTrust.DevExReports.API.Configurators
{
    public class CountyDashboardStorage : IEditableDashboardStorage
    {
        private string dashboardStorageFolder;
        private string dashboardFileName;
        public CountyDashboardStorage(IWebHostEnvironment hostingEnvironment, string programType)
        {
            dashboardStorageFolder = hostingEnvironment.ContentRootFileProvider.GetFileInfo("PredefinedDashboards/County").PhysicalPath;
            switch (programType)
            {
                case "FARM":
                    dashboardFileName = "CountyDashboardFARM";
                    break;
                case "FLOOD":
                    dashboardFileName = "CountyDashboardFLOOD";
                    break;
                case "HIST":
                    dashboardFileName = "CountyDashboardHIST";
                    break;
                case "OSTF":
                    dashboardFileName = "CountyDashboardOSTF";
                    break;
                case "MCMUA":
                    dashboardFileName = "CountyDashboardMCMUA";
                    break;
                case "MCPC":
                    dashboardFileName = "CountyDashboardMCPC";
                    break;
                case "TRAIL":
                    dashboardFileName = "CountyDashboardTRAIL";
                    break;
                case "DashboardHeader":
                    dashboardFileName = "CountyDashboardHeader";
                    break;
            }
        }

        public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()
        {
            var dashboardInfos = new List<DashboardInfo>();
            var files = Directory.GetFiles(dashboardStorageFolder, "*.xml");
            foreach (var item in files)
            {
                var name = Path.GetFileNameWithoutExtension(item);
                if (name == dashboardFileName)
                {
                    dashboardInfos.Add(new DashboardInfo() { ID = name, Name = name });
                    break;
                }
            }
            return dashboardInfos;
        }

        public XDocument LoadDashboard(string dashboardID)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardID + ".xml");
            var content = File.ReadAllText(path);
            return XDocument.Parse(content);
        }

        public string AddDashboard(XDocument dashboard, string dashboardName)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardName + ".xml");
            File.WriteAllText(path, dashboard.ToString());
            return Path.GetFileNameWithoutExtension(path);
        }

        public void SaveDashboard(string dashboardID, XDocument dashboard)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardID + ".xml");
            File.WriteAllText(path, dashboard.ToString());
        }
    }

    public class AgencyDashboardStorage : IEditableDashboardStorage
    {
        private string dashboardStorageFolder;
        private string dashboardFileName;
        public AgencyDashboardStorage(IWebHostEnvironment hostingEnvironment, string programType)
        {
            dashboardStorageFolder = hostingEnvironment.ContentRootFileProvider.GetFileInfo("PredefinedDashboards/Agency").PhysicalPath;
            switch (programType)
            {
                case "FARM":
                    dashboardFileName = "AgencyDashboardFARM";
                    break;
                case "FLOOD":
                    dashboardFileName = "AgencyDashboardFLOOD";
                    break;
                case "HIST":
                    dashboardFileName = "AgencyDashboardHIST";
                    break;
                case "OSTF":
                    dashboardFileName = "AgencyDashboardOSTF";
                    break;
                case "MCMUA":
                    dashboardFileName = "AgencyDashboardMCMUA";
                    break;
                case "MCPC":
                    dashboardFileName = "AgencyDashboardMCPC";
                    break;
                case "TRAIL":
                    dashboardFileName = "AgencyDashboardTRAIL";
                    break;
                case "DashboardHeader":
                    dashboardFileName = "AgencyDashboardHeader";
                    break;
            }
        }

        public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()
        {
            var dashboardInfos = new List<DashboardInfo>();
            var files = Directory.GetFiles(dashboardStorageFolder, "*.xml");
            foreach (var item in files)
            {
                var name = Path.GetFileNameWithoutExtension(item);
                if (name == dashboardFileName)
                {
                    dashboardInfos.Add(new DashboardInfo() { ID = name, Name = name });
                    break;
                }
            }
            return dashboardInfos;
        }

        public XDocument LoadDashboard(string dashboardID)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardID + ".xml");
            var content = File.ReadAllText(path);
            return XDocument.Parse(content);
        }

        public string AddDashboard(XDocument dashboard, string dashboardName)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardName + ".xml");
            File.WriteAllText(path, dashboard.ToString());
            return Path.GetFileNameWithoutExtension(path);
        }

        public void SaveDashboard(string dashboardID, XDocument dashboard)
        {
            var path = Path.Combine(dashboardStorageFolder, dashboardID + ".xml");
            File.WriteAllText(path, dashboard.ToString());
        }
    }
}
