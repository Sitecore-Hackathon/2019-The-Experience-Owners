using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SXV.Foundation.ConfigValidator.Utilities
{
    public static class Helper
    {
        public static readonly string AppConfigFolder = "/App_Config/Sitecore";
        public static readonly string FileExtension = ".config";

        public static string GetConnectionString(string connectionStringName)
        {
            if (Sitecore.Configuration.Settings.ConnectionStringExists(connectionStringName))
                return Sitecore.Configuration.Settings.GetConnectionString(connectionStringName);

            return string.Empty;
        }

        public static List<string> GetEnabledDisabledConfigs(string[] configFolders, ConfigState configState)
        {
            if (configFolders.Length > 0)
            {
                var configFilePaths = new List<string>();

                foreach (var configFolder in configFolders)
                {
                    var folderPath = $"{AppConfigFolder}/{configFolder}";
                    string[] filePaths = Directory.GetFiles(folderPath);
                    if (filePaths.Length > 0)
                        configFilePaths.AddRange(filePaths);
                }

                if (configFilePaths.Count > 0)
                {
                    if (configState == ConfigState.Enabled)
                        return configFilePaths.Where(x => Path.GetExtension(x).ToLower() == FileExtension).ToList();
                    else
                        return configFilePaths.Where(x => Path.GetExtension(x).ToLower() != FileExtension).ToList();
                }
            }

            return null;
        }
    }

    public enum ConfigState
    {
        Enabled,
        Disabled
    }
}