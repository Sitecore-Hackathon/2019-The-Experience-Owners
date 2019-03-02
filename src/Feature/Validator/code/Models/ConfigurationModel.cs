using System;
using System.Collections.Generic;
using SXV.Foundation.ConfigValidator.Configuration;
using SXV.Foundation.ConfigValidator.Utilities;

namespace SXV.Feature.Validator.Models
{
    public class ConfigurationModel
    {
        public string XdbEnabled
        {
            get
            {
                return XdbSettings.Enabled ? "xDb is Enabled." : "xDB is disabled";
            }
        }

        public string XdbHasValidLicense
        {
            get
            {
                return XdbSettings.HasValidLicense ? "xDB has valis license." : "There is some issue with xDB license.";
            }
        }

        public string XdbTrackingEnabled
        {
            get
            {
                return XdbSettings.TrackingEnabled ? "xDb tracking is Enabled." : "xDB tracking is disabled";
            }
        }

        public string XdbDisabledUrl
        {
            get
            {
                return XdbSettings.XdbDisabledUrl;
            }
        }

        public TimeSpan MaxAcceptedClockDeviation
        {
            get
            {
                return XdbSettings.MaxAcceptedClockDeviation;
            }
        }

        public string DefaultDefinitionDatabase
        {
            get
            {
                return XdbSettings.DefaultDefinitionDatabase;
            }
        }

        public int MaximumCacheEntryCount
        {
            get
            {
                return XdbSettings.MaximumCacheEntryCount;
            }
        }

        public TimeSpan MaximumInteractionPeriod
        {
            get
            {
                return XdbSettings.MaximumInteractionPeriod;
            }
        }

        public int MaximumInteractionCount
        {
            get
            {
                return XdbSettings.MaximumInteractionCount;
            }
        }

        public string ContentTestingEnabled
        {
            get
            {
                return XdbSettings.ContentTestingEnabled ? "Content testing is enabled." : "Content testing is disabled";
            }
        }

        public Dictionary<string, string> ConnectionStrings
        {
            get
            {
                var connectionStrings = new Dictionary<string, string>();
                connectionStrings.Add("xdb.marketingautomation", string.IsNullOrEmpty(XdbConnectionStrings.MarketingAutomation) ? "This connection string is not provided." : XdbConnectionStrings.MarketingAutomation);
                connectionStrings.Add("xdb.processing.pools", string.IsNullOrEmpty(XdbConnectionStrings.ProcessingPools) ? "This connection string is not provided." : XdbConnectionStrings.ProcessingPools);
                connectionStrings.Add("xdb.referencedata", string.IsNullOrEmpty(XdbConnectionStrings.Referencedata) ? "This connection string is not provided." : XdbConnectionStrings.Referencedata);
                connectionStrings.Add("xdb.processing.tasks", string.IsNullOrEmpty(XdbConnectionStrings.ProcessingTasks) ? "This connection string is not provided." : XdbConnectionStrings.ProcessingTasks);
                connectionStrings.Add("xdb.marketingautomation.operations.client", string.IsNullOrEmpty(XdbConnectionStrings.MarketingAutomationOperationsClient) ? "This connection string is not provided." : XdbConnectionStrings.MarketingAutomationOperationsClient);
                connectionStrings.Add("xdb.marketingautomation.reporting.client", string.IsNullOrEmpty(XdbConnectionStrings.MarketingAutomationReportingClient) ? "This connection string is not provided." : XdbConnectionStrings.MarketingAutomationReportingClient);
                connectionStrings.Add("xdb.referencedata.client", string.IsNullOrEmpty(XdbConnectionStrings.ReferencedataClient) ? "This connection string is not provided." : XdbConnectionStrings.ReferencedataClient);
                connectionStrings.Add("Reporting", string.IsNullOrEmpty(XdbConnectionStrings.Reporting) ? "This connection string is not provided." : XdbConnectionStrings.Reporting);
                connectionStrings.Add("sitecore.reporting.client", string.IsNullOrEmpty(XdbConnectionStrings.SitecoreReportingClient) ? "This connection string is not provided." : XdbConnectionStrings.SitecoreReportingClient);
                connectionStrings.Add("xconnect.collection", string.IsNullOrEmpty(XdbConnectionStrings.XConnectCollection) ? "This connection string is not provided." : XdbConnectionStrings.XConnectCollection);
                return connectionStrings;
            }
        }

        public string SolrValidation
        {
            get
            {
                return ValidateProviders.IsSolrRunning() ? "Solr is running." : "There is some issue with Solr server.";
            }
        }

        public string XConnectValidation
        {
            get
            {
                return ValidateProviders.IsXConnectRunning() ? "xConnect site is running." : "There is some issue with xConnect site.";
            }
        }

        public string GlobalAsaxFileExist
        {
            get
            {
                return Helper.IsGlobalAsaxFileExist() ? "Global.asax file exist." : "Global.asax file does not exist.";
            }
        }

        public List<string> ContentTestingEnabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetContentTestingConfigs();
            }
        }

        public List<string> ContentTestingDisabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetContentTestingConfigs(ConfigState.Disabled);
            }
        }

        public List<string> XdbEnabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetXdbConfigs();
            }
        }

        public List<string> XdbDisabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetXdbConfigs(ConfigState.Disabled);
            }
        }

        public List<string> TrackingEnabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetTrackingConfigs();
            }
        }

        public List<string> TrackingDisabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetTrackingConfigs(ConfigState.Disabled);
            }
        }

        public List<string> ExperienceAnalyticsEnabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetExperienceAnalyticsConfigs();
            }
        }

        public List<string> ExperienceAnalyticsDisabledConfigs
        {
            get
            {
                return SitecoreConfigFiles.GetExperienceAnalyticsConfigs(ConfigState.Disabled);
            }
        }

        public List<string> AvailableIndexes
        {
            get
            {
                return ValidateProviders.GetAvailableIndexes();
            }
        }

        public List<string> UnavailableIndexes
        {
            get
            {
                var availableIndexes = ValidateProviders.GetAvailableIndexes();
                var indexes = new List<string>();
                foreach (var index in Helper.IndexesToVerify)
                    if (!availableIndexes.Contains(index))
                        indexes.Add(index);

                return indexes;
            }
        }
    }
}