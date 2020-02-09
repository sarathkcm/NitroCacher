using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
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

