using SXV.Foundation.ConfigValidator.Utilities;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Get available indexes
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAvailableIndexes()
        {
            var indexes = Helper.GetAllIndexes();
            if (indexes.Count() > 0)
            {
                var availableIndexes = new List<string>();
                foreach (var index in Constants.IndexesToVerify)
                {
                    if (indexes.FirstOrDefault(x => x.Name.ToLower().Equals(index)) != null)
                        availableIndexes.Add(index);
                }
                return availableIndexes;
            }
            return null;
        }

        /// <summary>
        /// Get Unavailable indexes
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUnavailableIndexes()
        {
            var availableIndexes = GetAvailableIndexes();
            var indexes = new List<string>();
            foreach (var index in Constants.IndexesToVerify)
                if (!availableIndexes.Contains(index))
                    indexes.Add(index);

            return indexes;
        }
    }
}