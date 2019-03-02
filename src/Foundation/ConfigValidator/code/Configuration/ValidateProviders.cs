using SXV.Foundation.ConfigValidator.Utilities;

namespace SXV.Foundation.ConfigValidator.Configuration
{
    public static class ValidateProviders
    {
        /// <summary>
        /// Verify XConnect is running
        /// </summary>
        /// <returns></returns>
        public static bool IsXConnectRunning()
        {
            string url = Sitecore.Configuration.Settings.GetConnectionString("xconnect.collection");
            if (!string.IsNullOrWhiteSpace(url))
                return Helper.ValidateSuccessRequest(url);

            return false;
        }

        /// <summary>
        /// Verify Solr is running
        /// </summary>
        /// <returns></returns>
        public static bool IsSolrRunning()
        {
            var solrUrl = Sitecore.Configuration.Settings.GetConnectionString("solr.search");
            if (!string.IsNullOrWhiteSpace(solrUrl))
                return Helper.ValidateSuccessRequest(solrUrl);

            return false;
        }
    }
}