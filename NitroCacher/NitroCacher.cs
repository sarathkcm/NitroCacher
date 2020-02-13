using NitroCacher.Interfaces;
using NitroCacher.Models;
using NitroCacher.Plugins;
using NitroCacher.UI;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: Fiddler.RequiredVersion("2.3.5.0")]
namespace NitroCacher
{


    public class NitroCacher : IAutoTamper
    {

        const string disabledIconBase64 = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAz0lEQVQ4T62TMQ7CMAxF/19ScQsmdsTMwsJFoGJD6tSeoJkqMYEKF2Fh6YyYYeIWKFmMUlFUVYBo02yOv5/txCYaJ03TMYCQ5AzA8OW+i8gJQJ4kyaUewsrIsmxgrd0AWAB43zf4AuCglFpHUfRwvlLogo0xR5LTZkWfbBEpgiCYO0gJ0FrnAJb/BNc0+ziOQ7qeSZ5/lP2NKyIycYAtyVXL7KVcRHbUWl8BjLoAANwcwABQHQG2F4BfC96P6P2N3oPUyyhXkM7LVJ+Btuv8BPdOcfmKn4mVAAAAAElFTkSuQmCC";
        const string enabledIconBase64 = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAwklEQVQ4T63TvU5CQRCG4WcwMfEuqOgNtQ2Nd4CxV2LHtVhJ0N7AHdjQUBtrrLwLA4ks2Rx+/Qucw3Y78807M7sz4ft5dq6mI7RQX7o/JCNzfdfetkNifRk6k9wLN9jYdxMkyZPQ1faZXYUwB/OCix8V/W4Y4zJDCsBAX7jdM7iQJY+udELu+cTrP2X/xU2+NMPAg3B3UPaVOOmFoQkapQC8Z8AUpyUBs6MAKrZQ+RErf2PlQTrKKK8gpZdpewgOXOcFTTxEjYwMoIkAAAAASUVORK5CYII=";

        UserSettings _userSettings;
        IConfigManager _configManager;


        List<CachingRule> _cacheRules;
        bool Enabled => _userSettings != null && _userSettings.Enabled;
        List<CachingRule> CacheRules => _cacheRules.Where(r => r.ProfileId == _userSettings.SelectedProfileId).ToList();
        public void AutoTamperRequestAfter(Session oSession)
        {

        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (!Enabled) { return; }
            var matchingRules = FindMatchingRules(oSession);
            if (matchingRules.Count() == 0) return;


            var firstMatchedRule = matchingRules[0];
            var hash = Utils.GetHashFromRequest(oSession, firstMatchedRule.FilterRule);

            if (firstMatchedRule.Cache.Has(hash))
            {
                oSession.utilCreateResponseAndBypassServer();
                var responseString = firstMatchedRule.Cache.Get<string>(hash);
                var response = Utils.XmlDeSerialize<HttpResponse>(responseString);
                response.Headers.ForEach(h => oSession.ResponseHeaders.Add(h.Key, h.Value));
                if (firstMatchedRule.FilterRule.IsShownInUi)
                {
                    oSession["ui-backcolor"] = ColorTranslator.ToHtml(Color.FromArgb(firstMatchedRule.FilterRule.BackgroundColor.ToArgb()));
                    oSession["ui-color"] = ColorTranslator.ToHtml(Color.FromArgb(firstMatchedRule.FilterRule.ForegroundColor.ToArgb()));
                }
                else
                {
                    oSession["ui-hide"] = "true";
                }
                oSession.utilSetResponseBody(response.Body);
                oSession["NitroCacher.flags.responseServedFromCache"] = "true";
                matchingRules.ForEach(r => r.Cache.Set(hash, responseString));
                return;
            }

            oSession["NitroCacher.flags.cacheKey"] = string.Join(";", matchingRules.Select(r => $"{r.FilterRule.Id}/{Utils.GetHashFromRequest(oSession, r.FilterRule)}"));
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            if (!Enabled || oSession["NitroCacher.flags.responseServedFromCache"] == "true") { return; }
            var matchingRules = FindMatchingRules(oSession);
            if (matchingRules.Count() == 0) return;
            oSession.utilDecodeResponse();
            var oBody = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
            var response = new HttpResponse(oSession.ResponseHeaders.Select(h => new Header(h.Name, h.Value)).ToList(), oBody);
            var responseXml = Utils.XmlSerialize(response);
            oSession["NitroCacher.flags.cacheKey"].Split(';').Select(v => new { CacheId = v.Split('/')[0], CacheKey = v.Split('/')[1] })
                                                             .ToList()
                                                             .ForEach(c =>
                                                             {
                                                                 var rule = matchingRules
                                                                                .FirstOrDefault(r => r.FilterRule.Id == c.CacheId);
                                                                 if (rule == null) return;
                                                                 rule.Cache.Set(c.CacheKey, responseXml);
                                                             });
        }

        private List<CachingRule> FindMatchingRules(Session oSession)
        {
            return (CacheRules ?? new List<CachingRule>()).Where(rule => rule.FilterRule.IsEnabled && Utils.DoesUrlMatch(oSession.url, rule.FilterRule)).ToList();
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
            _configManager.SaveConfig(_userSettings);
        }

        public void OnLoad()
        {
            _configManager = new XmlFileConfigManager();
            _userSettings = _configManager.GetConfig<UserSettings>() ?? new UserSettings { RuleProfiles = new List<RuleProfile>() };
            _cacheRules = _userSettings.RuleProfiles.SelectMany(p => p.Rules.Select(r => new CachingRule
            {
                Cache = new MemoryCache(),
                ProfileId = p.Id,
                FilterRule = r
            })).ToList();


            Action<string> clearCacheForId = (string id) => _cacheRules
                .Where(r => r.FilterRule.Id == id)
                .ToList()
                .ForEach(c => c.Cache.Clear());

            Action<string> clearCacheForProfile = (string id) => _cacheRules
                .Where(r => r.ProfileId == id)
                .ToList()
                .ForEach(c => c.Cache.Clear());

            Action clearAllCache = () => _cacheRules
                .ForEach(c => c.Cache.Clear());



            var cacherPage = new TabPage("Nitro Cacher");


            Action<bool> toggleIcon = (enabled) =>
            {
                var key = enabled ? "NitroCacher.Enabled" : "NitroCacher.Disabled";
                cacherPage.ImageKey = key;
            };

            var cacherControl = new Home(_userSettings, clearCacheForId, clearCacheForProfile, clearAllCache, toggleIcon);
            cacherPage.Controls.Add(cacherControl);
            cacherControl.Dock = DockStyle.Fill;
            FiddlerApplication.UI.imglSessionIcons.Images.Add("NitroCacher.Enabled", enabledIconBase64.ToImage());
            FiddlerApplication.UI.imglSessionIcons.Images.Add("NitroCacher.Disabled", disabledIconBase64.ToImage());
            FiddlerApplication.UI.tabsViews.TabPages.Add(cacherPage);
        }
    }
}
