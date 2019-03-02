using Sitecore.Configuration;
using System;

namespace SXV.Foundation.ConfigValidator.Configuration
{
    /// <summary>Experience database settings.</summary>
    public static class XdbSettings
    {
        /// <summary>Gets a value indicating whether the xDB is enabled.</summary>
        /// <value>
        ///   <c>true</c> if xDB license is valid and xDB is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool Enabled
        {
            get
            {
                if (XdbSettings.HasValidLicense)
                    return Settings.GetBoolSetting("Xdb.Enabled", true);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the tracking functionality is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the tracking functionality is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool TrackingEnabled
        {
            get
            {
                return Settings.GetBoolSetting("Xdb.Tracking.Enabled", true);
            }
        }

        /// <summary>Gets a value indicating whether the license is valid.</summary>
        /// <value>
        /// <c>true</c> if the license is valid; otherwise, <c>false</c>.
        /// </value>
        public static bool HasValidLicense
        {
            get
            {
                if (!Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Base") && !Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Plus") && (!Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Premium") && !Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Base.Cloud")) && (!Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Plus.Cloud") && !Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Premium.Cloud")))
                    return Sitecore.SecurityModel.License.License.HasModule("Sitecore.xDB.Enterprise.Cloud");
                return true;
            }
        }

        /// <summary>Gets the URL to redirect to, if the Xdb is disabled.</summary>
        /// <value>Default value: "/sitecore/service/xdb/disabled.aspx".</value>
        public static string XdbDisabledUrl
        {
            get
            {
                return Settings.GetSetting(nameof(XdbDisabledUrl), "/sitecore/service/xdb/disabled.aspx");
            }
        }

        /// <summary>
        /// Gets the largest acceptable deviation between the current server’s system time and the system time
        /// of other Sitecore servers in the same environment.
        /// The system uses this setting to compensate for any system time deviation between servers.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.TimeSpan" /> containing the largest system clock deviation between Sitecore servers.
        /// </value>
        public static TimeSpan MaxAcceptedClockDeviation
        {
            get
            {
                return Settings.GetTimeSpanSetting("Analytics.MaxAcceptedClockDeviation", TimeSpan.FromSeconds(10.0));
            }
        }

        /// <summary>Gets the definition database.</summary>
        /// <value>The definition database.</value>
        public static string DefaultDefinitionDatabase
        {
            get
            {
                return Settings.GetSetting("Analytics.DefaultDefinitionDatabase", "master");
            }
        }

        /// <summary>
        /// Gets the maximum number of items in the cache for a given category (goals, page events, etc.).
        /// </summary>
        /// <value>The maximum cache entry count.</value>
        public static int MaximumCacheEntryCount
        {
            get
            {
                return Settings.GetIntSetting("Xdb.Tracking.KeyBehaviorCache.MaximumCacheEntryCount", 50);
            }
        }

        /// <summary>
        /// Gets the maximum time period (compared to interaction start date time) for interactions that can be included in cache rebuilds or updates.
        /// </summary>
        /// <value>The maximum interaction period.</value>
        public static TimeSpan MaximumInteractionPeriod
        {
            get
            {
                return Settings.GetTimeSpanSetting("Xdb.Tracking.KeyBehaviorCache.MaximumInteractionPeriod", TimeSpan.FromDays(30.0));
            }
        }

        /// <summary>
        /// Gets the maximum number of interactions to examine during cache rebuilds or updates.
        /// </summary>
        /// <value>The maximum interaction count.</value>
        public static int MaximumInteractionCount
        {
            get
            {
                return Settings.GetIntSetting("Xdb.Tracking.KeyBehaviorCache.MaximumInteractionCount", 25);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Content Testing is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the content testing functionality is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool ContentTestingEnabled
        {
            get
            {
                return Settings.GetBoolSetting("ContentTesting.AutomaticContentTesting.Enabled", true);
            }
        }
    }
}