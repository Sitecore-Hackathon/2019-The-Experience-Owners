using Sitecore.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SXV.Feature.Validator.Models
{
    public class PersonalizationModel
    {
        public List<PersonalizationData> PersonalizationData { get; set; }
    }
    public class PersonalizationData
    {
        public string ItemName { get; set; }
        public List<RenderingDetails> RederingDetails { get; set; }
    }

    public class RenderingDetails
    {

        public string RenderingID { get; set; }
        public string RenderingName { get; set; }
    }

}