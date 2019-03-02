namespace SXV.Foundation.ConfigValidator.Utilities
{
    public static class Constants
    {
        public static readonly string AppConfigFolder = @"\App_Config\Sitecore";
        public static readonly string FileExtension = ".config";
        public static readonly string[] IndexesToVerify = new string[] { "sitecore_marketingdefinitions_master", "sitecore_marketingdefinitions_web", "sitecore_suggested_test_index", "sitecore_testing_index", "xdb" };
        public static readonly string[] ConnectionStringsToVerify = new string[] { "xdb.marketingautomation", "xdb.processing.pools", "xdb.referencedata", "xdb.processing.tasks", "xdb.marketingautomation.operations.client", "xdb.marketingautomation.reporting.client", "xdb.referencedata.client", "Reporting", "sitecore.reporting.client", "xconnect.collection" };

    }
}