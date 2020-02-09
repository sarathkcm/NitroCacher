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
        UserSettings _userSettings;
        IConfigManager _configManager;


        List<CachingRule> _cacheRules;
        public void AutoTamperRequestAfter(Session oSession)
        {

        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (!_userSettings.Enabled) { return; }
            var matchingRules = FindMatchingRules(oSession);
            if (matchingRules.Count() == 0) return;


            var firstMatchedRule = matchingRules[0];
            var hash = Utils.GetHashFromRequest(oSession, firstMatchedRule.FilterRule);

            if (firstMatchedRule.Cache.Has(hash))
            {
                oSession.utilCreateResponseAndBypassServer();
                var responseString = firstMatchedRule.Cache.Get<string>(hash);
                var response = Utils.XmlDeSerialize<HttpResponse>(responseString);
                response.Headers.ForEach(h => oSession.ResponseHeaders.Add(h.Item1, h.Item2));
                oSession["ui-backcolor"] = ColorTranslator.ToHtml(Color.FromArgb(firstMatchedRule.FilterRule.BackgroundColor.ToArgb()));
                oSession["ui-color"] = ColorTranslator.ToHtml(Color.FromArgb(firstMatchedRule.FilterRule.ForegroundColor.ToArgb()));
                oSession.utilSetResponseBody(response.Body);

                matchingRules.ForEach(r => r.Cache.Set(hash, responseString));
                return;
            }

            oSession["NitroCacher.flags.cache-key"] = string.Join(";", matchingRules.Select(r => Utils.GetHashFromRequest(oSession, r.FilterRule)));
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            if (!_userSettings.Enabled) { return; }
            var matchingRules = FindMatchingRules(oSession);
            if (matchingRules.Count() == 0) return;
            oSession.utilDecodeResponse();
            var oBody = System.Text.Encoding.UTF8.GetString(oSession.responseBodyBytes);
            var response = new HttpResponse(oSession.ResponseHeaders.Select(h => (h.Name, h.Value)).ToList(), oBody);
            matchingRules.ForEach(r => r.Cache.Set(oSession["NitroCacher.flags.cache-key"], Utils.XmlSerialize(response)));
        }

        private List<CachingRule> FindMatchingRules(Session oSession)
        {
            return (_cacheRules ?? new List<CachingRule>()).Where(rule => rule.FilterRule.IsEnabled && Utils.DoesUrlMatch(oSession.url, rule.FilterRule)).ToList();
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
            var cacherControl = new Home(_userSettings, clearCacheForId, clearCacheForProfile, clearAllCache);
            cacherPage.Controls.Add(cacherControl);
            cacherControl.Dock = DockStyle.Fill;
            FiddlerApplication.UI.tabsViews.TabPages.Add(cacherPage);
        }
    }
}
