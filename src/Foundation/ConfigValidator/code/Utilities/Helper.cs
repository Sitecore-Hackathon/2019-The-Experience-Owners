using System.IO;
using System.Linq;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using System.Net;
using System;
using Sitecore.Diagnostics;
using System.Web;

namespace SXV.Foundation.ConfigValidator.Utilities
{
    public static class Helper
    {
        public static string GetConnectionString(string connectionStringName)
        {
            try
            {
                if (Sitecore.Configuration.Settings.ConnectionStringExists(connectionStringName))
                    return Sitecore.Configuration.Settings.GetConnectionString(connectionStringName);

                return string.Empty;
            }
            catch (Exception e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return string.Empty;
            }
        }

        public static List<string> GetEnabledDisabledConfigs(string[] configFolders, ConfigState configState)
        {
            try
            {
                if (configFolders.Length > 0)
                {
                    var configFilePaths = new List<string>();

                    foreach (var configFolder in configFolders)
                    {
                        var folderPath = HttpContext.Current.Server.MapPath($"{Constants.AppConfigFolder}\\{configFolder}");

                        string[] filePaths = Directory.GetFiles(folderPath);
                        if (filePaths.Length > 0)
                            configFilePaths.AddRange(filePaths);
                    }

                    if (configFilePaths.Count > 0)
                    {
                        if (configState == ConfigState.Enabled)
                            return configFilePaths.Where(x => Path.GetExtension(x).ToLower() == Constants.FileExtension).ToList();
                        else
                            return configFilePaths.Where(x => Path.GetExtension(x).ToLower() != Constants.FileExtension).ToList();
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return null;
            }
        }

        public static bool ValidateSuccessRequest(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var statusCode = response.StatusCode;
                response.Close();

                if (statusCode == HttpStatusCode.OK)
                    return true;

                return false;

            }
            catch (WebException e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return false;
            }
            catch (Exception e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return false;
            }
        }

        public static IEnumerable<ISearchIndex> GetAllIndexes()
        {
            try
            {
                return ContentSearchManager.Indexes;
            }
            catch (Exception e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return null;
            }
        }

        public static bool IsGlobalAsaxFileExist()
        {
            try
            {
                return File.Exists("/Global.asax");
            }
            catch (Exception e)
            {
                Log.Error("The following Exception was raised : ", e, "ExperienceValidator");
                return false;
            }
        }
    }

    public enum ConfigState
    {
        Enabled,
        Disabled
    }
}