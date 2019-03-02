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
                return XdbSettings.HasValidLicense ? "Valid xDB license." : "Invalid xDB license.";
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

        public List<string> AvailableConnectionStrings
        {
            get
            {
                return XdbConnectionStrings.GetAvailableConnectionStrings();
            }
        }

        public List<string> UnavailableConnectionStrings
        {
            get
            {
                return XdbConnectionStrings.GetUnavailableConnectionStrings();
            }
        }

        public string SolrValidation
        {
            get
            {
                return ValidateProviders.IsSolrRunning() ? "Solr is running." : "Cannot connect to solr or solr is not running.";
            }
        }

        public string XConnectValidation
        {
            get
            {
                return ValidateProviders.IsXConnectRunning() ? "xConnect site is running." : "xConnect is not running.";
            }
        }

        public bool GlobalAsaxFileExist
        {
            get
            {
                return Helper.IsGlobalAsaxFileExist();
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
                return ValidateProviders.GetUnavailableIndexes();
            }
        }
    }
}