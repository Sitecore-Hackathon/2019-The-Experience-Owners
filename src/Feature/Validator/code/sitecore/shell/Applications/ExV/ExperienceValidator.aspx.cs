using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using SXV.Feature.Validator.Models;
using SXV.Foundation.ConfigValidator.Configuration;

namespace SXV.Feature.Validator.sitecore.shell.Applications
{
    public partial class ExperienceValidator : System.Web.UI.Page
    {
        public string IsxDBEnabled, IsTrackingEnabled, IsxDBLicense, IsXConnect, IsSolrRunning, GlobalAsaxExist, IsContentTestingEnabled;

        public ConfigurationModel configurationModel = new ConfigurationModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            divPanelButtons.Visible = false;
        }
        protected void RunConfiguration_Click(object sender, EventArgs e)
        {
            divPanelButtons.Visible = true;

            lblxDBsettings.Text = configurationModel.XdbEnabled;
            IsxDBEnabled = XdbSettings.Enabled ? "success" : "danger";

            lblTrackingEnabled.Text = configurationModel.XdbTrackingEnabled;
            IsTrackingEnabled = XdbSettings.TrackingEnabled ? "success" : "danger";

            lblxDBLicense.Text = configurationModel.XdbHasValidLicense;
            IsxDBLicense = XdbSettings.HasValidLicense ? "success" : "danger";

            lblDefaultDefinitionDatabase.Text = configurationModel.DefaultDefinitionDatabase;

            lblxConnect.Text = configurationModel.XConnectValidation;
            IsXConnect = ValidateProviders.IsXConnectRunning() ? "success" : "danger";

            if (configurationModel.AvailableConnectionStrings != null)
            {
                lblDBConnectionString.Text = string.Join("<br />", configurationModel.AvailableConnectionStrings.ToArray()); ;
            }
            if (configurationModel.AvailableConnectionStrings != null) { lblUnDBConnectionString.Text = string.Join("<br />", configurationModel.AvailableConnectionStrings.ToArray()); ; }

            lblSolrRunning.Text = configurationModel.SolrValidation;
            IsSolrRunning = ValidateProviders.IsSolrRunning() ? "success" : "danger";

            if (configurationModel.AvailableIndexes != null) { lblAvailableIndexes.Text = string.Join("<br />", configurationModel.AvailableIndexes.ToArray()); ; }
            if (configurationModel.UnavailableIndexes != null) { lblUnAvailableIndexes.Text = string.Join("<br />", configurationModel.UnavailableIndexes.ToArray()); ; }

            bool fileExist = configurationModel.GlobalAsaxFileExist;
            lblGlobalAsax.Text = fileExist ? "Global.asax file exist." : "Global.asax file do not exist at website root."; ;
            GlobalAsaxExist = fileExist ? "success" : "danger";

            lblContentTestingEnabled.Text = configurationModel.ContentTestingEnabled;
            IsContentTestingEnabled = XdbSettings.ContentTestingEnabled ? "success" : "danger";

            lblContentTestingEnabledConfigs.Text = configurationModel.ContentTestingEnabledConfigs != null && configurationModel.ContentTestingEnabledConfigs.Any() ? string.Join("<br />", configurationModel.ContentTestingEnabledConfigs) : string.Empty;

            lblContentTestingDisabledConfigs.Text = configurationModel.ContentTestingDisabledConfigs != null && configurationModel.ContentTestingDisabledConfigs.Any() ? string.Join("<br />", configurationModel.ContentTestingDisabledConfigs) : string.Empty;

            lblXdbEnabledConfigs.Text = configurationModel.XdbEnabledConfigs != null && configurationModel.XdbEnabledConfigs.Any() ? string.Join("<br />", configurationModel.XdbEnabledConfigs) : string.Empty;

            lblXdbDisabledConfigs.Text = configurationModel.XdbDisabledConfigs != null && configurationModel.XdbDisabledConfigs.Any() ? string.Join("<br />", configurationModel.XdbDisabledConfigs) : string.Empty;

            lblTrackingEnabledConfigs.Text = configurationModel.TrackingEnabledConfigs != null && configurationModel.TrackingEnabledConfigs.Any() ? string.Join("<br />", configurationModel.TrackingEnabledConfigs) : string.Empty;

            lblTrackingDisabledConfigs.Text = configurationModel.TrackingDisabledConfigs != null && configurationModel.TrackingDisabledConfigs.Any() ? string.Join("<br />", configurationModel.TrackingDisabledConfigs) : string.Empty;

            lblExperienceAnalyticsEnabledConfigs.Text = configurationModel.ExperienceAnalyticsEnabledConfigs != null && configurationModel.ExperienceAnalyticsEnabledConfigs.Any() ? string.Join("<br />", configurationModel.ExperienceAnalyticsEnabledConfigs) : string.Empty;

            lblExperienceAnalyticsDisabledConfigs.Text = configurationModel.ExperienceAnalyticsDisabledConfigs != null && configurationModel.ExperienceAnalyticsDisabledConfigs.Any() ? string.Join("<br />", configurationModel.ExperienceAnalyticsDisabledConfigs) : string.Empty;
        }

        protected void btnGetPersonalization_ServerClick(object sender, EventArgs e)
        {
            var data = new List<PersonalizationData>();
            Sitecore.Data.Database master = Sitecore.Data.Database.GetDatabase("master");
            var startItem = master.GetItem("/sitecore/content");
            DeviceItem device = master.Resources.Devices["Default"];
            foreach (var item in startItem.Axes.GetDescendants())
            {
                PersonalizationData details = new PersonalizationData();
                Sitecore.Data.Fields.LayoutField layoutField = item.Fields["__renderings"];
                List<Sitecore.Layouts.RenderingReference> renderings = layoutField.GetReferences(device) != null ? layoutField.GetReferences(device).ToList() : null;
                if (renderings != null)
                {
                    Sitecore.Data.Fields.LayoutField finalLayoutField = item.Fields["__final renderings"];
                    List<Sitecore.Layouts.RenderingReference> finalRenderings = finalLayoutField.GetReferences(device) != null ? finalLayoutField.GetReferences(device).ToList() : null;
                    if (finalRenderings != null)
                    {
                        renderings.AddRange(finalRenderings);
                        var renderingsWithPersonalization = renderings.Where(r => r.Settings.Rules.Count > 0).ToList();
                        details.ItemName = item.Name;
                        details.RederingDetails = new List<RenderingDetails>();
                        if (details.ItemName != null && renderingsWithPersonalization != null && renderingsWithPersonalization.Count > 0)
                        {
                            foreach (var rendering in renderingsWithPersonalization)
                            {
                                RenderingDetails renderingDetail = new RenderingDetails();
                                renderingDetail.RenderingID = master.GetItem(rendering.RenderingID).Paths.FullPath.ToString();
                                renderingDetail.RenderingName = master.GetItem(rendering.RenderingID).Name;
                                details.RederingDetails.Add(renderingDetail);
                            }
                        }
                    }
                    data.Add(details);
                }
                data = data.Where(x => x.RederingDetails.Count() > 0).ToList();
            }
            personalizedData.Text = "";
            if (data.Count > 0)
            {
                foreach (var finalData in data)
                {
                    personalizedData.Text += "Item Name : <strong>" + finalData.ItemName + "</strong></br>";
                    personalizedData.Text += "Renderings with Personalizations defined : </br>";
                    foreach (var renderingData in finalData.RederingDetails)
                    {
                        personalizedData.Text += "Rendering - Path -" + renderingData.RenderingID + "</br>";
                    }
                    personalizedData.Text += "</br>";
                }
            }
            else
            {
                personalizedData.Text += "No renderings with Personalization found";
            }

        }


    }
}