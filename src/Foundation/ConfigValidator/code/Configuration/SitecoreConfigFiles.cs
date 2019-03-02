using SXV.Foundation.ConfigValidator.Utilities;
using System.Collections.Generic;

namespace SXV.Foundation.ConfigValidator.Configuration
{
    public static class SitecoreConfigFiles
    {
        /// <summary>
        /// Get enabled/disabled config files of /App_Config/Sitecore/ContentTesting folder
        /// </summary>
        /// <param name="configState">Enabled/Disabled</param>
        /// <returns>List of config files</returns>
        public static List<string> GetContentTestingConfigs(ConfigState configState = ConfigState.Enabled)
        {
            return Helper.GetEnabledDisabledConfigs(new string[] { "ContentTesting" }, configState);
        }

        /// <summary>
        /// Get enabled/disabled config files of /App_Config/Sitecore/Marketing.xDB, /App_Config/Sitecore/Marketing.xDB, /App_Config/Sitecore/Marketing.xDB.ReferenceData.Client, /App_Config/Sitecore/Marketing.xDB.ReferenceData.Core, /App_Config/Sitecore/Marketing.xDB.ReferenceData.SqlServer, /App_Config/Sitecore/Marketing.xDB.Sql.Common  folders
        /// </summary>
        /// <param name="configState">Enabled/Disabled</param>
        /// <returns>List of config files</returns>
        public static List<string> GetXdbConfigs(ConfigState configState = ConfigState.Enabled)
        {
            return Helper.GetEnabledDisabledConfigs(new string[] { "Marketing.xDB", "Marketing.Xdb.ReferenceData.Client", "Marketing.Xdb.ReferenceData.Core", "Marketing.Xdb.ReferenceData.Service", "Marketing.Xdb.ReferenceData.SqlServer", "Marketing.Xdb.Sql.Common" }, configState);
        }

        /// <summary>
        /// Get enabled/disabled config files of /App_Config/Sitecore/Marketing.Tracking, /App_Config/Sitecore/Tracking.Web.MVC, /App_Config/Sitecore/Tracking.Web.RobotDetection folders
        /// </summary>
        /// <param name="configState">Enabled/Disabled</param>
        /// <returns>List of config files</returns>
        public static List<string> GetTrackingConfigs(ConfigState configState = ConfigState.Enabled)
        {
            return Helper.GetEnabledDisabledConfigs(new string[] { "Marketing.Tracking", "Tracking.Web.MVC", "Tracking.Web.RobotDetection" }, configState);
        }

        /// <summary>
        /// Get enabled/disabled config files of /App_Config/Sitecore/ExperienceAnalytics folder
        /// </summary>
        /// <param name="configState">Enabled/Disabled</param>
        /// <returns>List of config files</returns>
        public static List<string> GetExperienceAnalyticsConfigs(ConfigState configState = ConfigState.Enabled)
        {
            return Helper.GetEnabledDisabledConfigs(new string[] { "ExperienceAnalytics" }, configState);
        }
    }
}