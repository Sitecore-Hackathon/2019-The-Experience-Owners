using SXV.Foundation.ConfigValidator.Utilities;
using System.Collections.Generic;

namespace SXV.Foundation.ConfigValidator.Configuration
{
    public static class XdbConnectionStrings
    {
        /// <summary>
        /// Get available connection strings
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAvailableConnectionStrings()
        {
            var availableConnectionStrings = new List<string>();
            foreach (var connectionString in Constants.ConnectionStringsToVerify)
            {
                if (Sitecore.Configuration.Settings.ConnectionStringExists(connectionString))
                    availableConnectionStrings.Add(connectionString);
            }

            return availableConnectionStrings;
        }

        /// <summary>
        /// Get Unavailable connection strings
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUnavailableConnectionStrings()
        {
            var availableConnectionStrings = GetAvailableConnectionStrings();
            var connectionStrings = new List<string>();
            foreach (var index in Constants.ConnectionStringsToVerify)
                if (!availableConnectionStrings.Contains(index))
                    connectionStrings.Add(index);

            return connectionStrings;
        }
    }
}