using SXV.Foundation.ConfigValidator.Utilities;

namespace SXV.Foundation.ConfigValidator.Configuration
{
    public static class XdbConnectionStrings
    {
        /// <summary>Gets the xdb.marketingautomation connection string.</summary>
        /// <value>The xdb.marketingautomation connection string.</value>
        public static string MarketingAutomation
        {
            get
            {
                return Helper.GetConnectionString("xdb.marketingautomation");
            }
        }

        /// <summary>Gets the xdb.processing.pools connection string.</summary>
        /// <value>The xdb.processing.pools connection string.</value>
        public static string ProcessingPools
        {
            get
            {                
                return Helper.GetConnectionString("xdb.processing.pools");
            }
        }

        /// <summary>Gets the xdb.referencedata connection string.</summary>
        /// <value>The xdb.referencedata connection string.</value>
        public static string Referencedata
        {
            get
            {
                return Helper.GetConnectionString("xdb.referencedata");
            }
        }

        /// <summary>Gets the xdb.processing.tasks connection string.</summary>
        /// <value>The xdb.processing.tasks connection string.</value>
        public static string ProcessingTasks
        {
            get
            {
                return Helper.GetConnectionString("xdb.processing.tasks");
            }
        }

        /// <summary>Gets the xdb.marketingautomation.operations.client connection string.</summary>
        /// <value>The xdb.marketingautomation.operations.client connection string.</value>
        public static string MarketingAutomationOperationsClient
        {
            get
            {
                return Helper.GetConnectionString("xdb.marketingautomation.operations.client");
            }
        }

        /// <summary>Gets the xdb.marketingautomation.reporting.client connection string.</summary>
        /// <value>The xdb.marketingautomation.reporting.client connection string.</value>
        public static string MarketingAutomationReportingClient
        {
            get
            {
                return Helper.GetConnectionString("xdb.marketingautomation.reporting.client");
            }
        }

        /// <summary>Gets the xdb.referencedata.client connection string.</summary>
        /// <value>The xdb.referencedata.client connection string.</value>
        public static string ReferencedataClient
        {
            get
            {
                return Helper.GetConnectionString("xdb.referencedata.client");
            }
        }

        /// <summary>Gets the Reporting connection string.</summary>
        /// <value>The Reporting connection string.</value>
        public static string Reporting
        {
            get
            {
                return Helper.GetConnectionString("Reporting");
            }
        }

        /// <summary>Gets the sitecore.reporting.client connection string.</summary>
        /// <value>The sitecore.reporting.client connection string.</value>
        public static string SitecoreReportingClient
        {
            get
            {
                return Helper.GetConnectionString("sitecore.reporting.client");
            }
        }

        /// <summary>Gets the xconnect.collection connection string.</summary>
        /// <value>The xconnect.collection connection string.</value>
        public static string XConnectCollection
        {
            get
            {
                return Helper.GetConnectionString("xconnect.collection");
            }
        }
    }
}