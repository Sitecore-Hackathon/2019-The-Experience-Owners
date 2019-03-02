using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SXV.Feature.Validator.Models;
using SXV.Foundation.ConfigValidator.Configuration;

namespace SXV.Feature.Validator.sitecore.shell.Applications
{
    public partial class ExperienceValidator : System.Web.UI.Page
    {
        public string IsxDBEnabled, IsTrackingEnabled, IsxDBLicense;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RunConfiguration_Click(object sender, EventArgs e)
        {
            var configurationModel = new ConfigurationModel();

            lblxDBsettings.Text = configurationModel.XdbEnabled;
            IsxDBEnabled = XdbSettings.Enabled ? "success" : "danger";

            lblTrackingEnabled.Text = configurationModel.XdbTrackingEnabled;
            IsTrackingEnabled = XdbSettings.Enabled ? "success" : "danger";

            lblxDBLicense.Text = configurationModel.XdbHasValidLicense;
            IsxDBLicense = XdbSettings.Enabled ? "success" : "danger";

        }
    }
}