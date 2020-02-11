using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NitroCacher.Models
{
    [Serializable]
    public class UserSettings
    {
        public List<RuleProfile> RuleProfiles { get; set; }
        public string SelectedProfileId { get; set; }
        public bool Enabled { get; set; }
    }
    [Serializable]
    public class RuleProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<FilterRule> Rules { get; set; }
    }

    [Serializable]
    public class FilterRule
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public MatchType MatchType { get; set; }
        public string Criteria { get; set; }
        public List<string> HeadersToIgnore { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsShownInUi { get; set; }


        [XmlIgnore]
        public Color BackgroundColor { get; set; }
        
        [XmlIgnore]
        public Color ForegroundColor { get; set; }



        [XmlElement("BackgroundColor")]
        public string BackgroundColorHtml
        {
            get { return ColorTranslator.ToHtml(BackgroundColor); }
            set { BackgroundColor = ColorTranslator.FromHtml(value); }
        }


        [XmlElement("ForegroundColor")]
        public string ForegroundColorHtml
        {
            get { return ColorTranslator.ToHtml(ForegroundColor); }
            set { ForegroundColor = ColorTranslator.FromHtml(value); }
        }
    }

    [Serializable]
    public enum MatchType
    {
        [Description("Exact Url")]
        ExactUrl,

        [Description("Host Name")]
        HostName,

        [Description("Partial Url")]
        PartialUrl,

        [Description("Regex")]
        Regex
    }
}

