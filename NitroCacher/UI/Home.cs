using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NitroCacher.Models;
namespace NitroCacher.UI
{
    public partial class Home : UserControl
    {
  

        UserSettings _userSettings;
        private readonly Action<string> _clearCacheForRule;
        private readonly Action<string> _clearAllCacheForProfile;
        private readonly Action _clearAllCache;
        private readonly Action<bool> _toggleIcon;

        RuleProfile _ruleProfile => _userSettings.RuleProfiles.First(r => r.Id == _userSettings.SelectedProfileId);

        public Home(UserSettings userSettings, Action<string> clearCacheForRule, Action<string> clearAllCacheForProfile, Action clearAllCache, Action<bool> toggleIcon)
        {
            _userSettings = userSettings;
            _clearCacheForRule = clearCacheForRule;
            _clearAllCacheForProfile = clearAllCacheForProfile;
            _clearAllCache = clearAllCache;
            _toggleIcon = toggleIcon;
            InitializeComponent();
            lstProfiles.DisplayMember = "Name";
            lstRules.DisplayMember = "Name";
        }

        private void lnkAddNewRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ruleConfigForm = new RuleConfig();
            var result = ruleConfigForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _ruleProfile.Rules.Add(ruleConfigForm.ConfiguredRule);
                DrawUi();
            }
        }

        private void DrawUi()
        {
            chkEnabled.Checked = _userSettings.Enabled;
            _toggleIcon(_userSettings.Enabled);
            PopulateProfilesList();
            PopulateRulesList();
            EnableDisableLinks();
        }

        private void EnableDisableLinks()
        {
            lnkAddNewRule.Enabled = lstProfiles.SelectedItem != null;
            lnkRemoveRule.Enabled = lstProfiles.SelectedItem != null && lstRules.SelectedItem != null;
            lnkEditRule.Enabled = lstProfiles.SelectedItem != null && lstRules.SelectedItem != null;
            lnkClearCacheForRule.Enabled = lstProfiles.SelectedItem != null && lstRules.SelectedItem != null;
            lnkClearCacheProfile.Enabled = lstProfiles.SelectedItem != null;

        }

        private void PopulateProfilesList()
        {
            lstProfiles.Items.Clear();
            lstProfiles.Items.AddRange(_userSettings.RuleProfiles.ToArray());
            lstProfiles.SelectedItem = _userSettings.RuleProfiles.FirstOrDefault(f => f.Id == _userSettings.SelectedProfileId);
        }

        private void PopulateRulesList()
        {
            lstRules.Items.Clear();
            foreach (var rule in _ruleProfile.Rules)
            {
                lstRules.Items.Add(rule, rule.IsEnabled);
            }
        }

        private void lnkAddNewProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var newProfileName = GetPromptTextInput("Enter a profile name.", "Enter a profile name.");
            if (string.IsNullOrWhiteSpace(newProfileName)) { return; }
            string newProfileId = Guid.NewGuid().ToString();
            RuleProfile profile = new RuleProfile
            {
                Id = newProfileId,
                Name = newProfileName,
                Rules = new List<FilterRule>()
            };
            _userSettings.RuleProfiles.Add(profile);
            _userSettings.SelectedProfileId = newProfileId;
            DrawUi();
        }

        private void lnkEditRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ruleConfigForm = new RuleConfig(lstRules.SelectedItem as FilterRule);
            var result = ruleConfigForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // the filterRule is mutated by ruleConfigForm
                DrawUi();
            }
        }


        // Credits: https://stackoverflow.com/a/5427121
        public static string GetPromptTextInput(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };
            textLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            Button cancel = new Button() { Text = "Cancel", Left = 470, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void lnkClearAllCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _clearAllCache();
        }

        private void lnkClearCacheProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _clearAllCacheForProfile((lstProfiles.SelectedItem as RuleProfile).Id);
        }

        private void lnkClearCacheForRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _clearCacheForRule((lstRules.SelectedItem as FilterRule).Id);
        }

        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userSettings.SelectedProfileId = (lstProfiles.SelectedItem as RuleProfile).Id;
            PopulateRulesList();
            EnableDisableLinks();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DrawUi();
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _userSettings.Enabled = chkEnabled.Checked;
            _toggleIcon(_userSettings.Enabled);
        }


        private void lstRules_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ((FilterRule)lstRules.Items[e.Index]).IsEnabled = e.NewValue == CheckState.Checked;
        }

        private void lstRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableLinks();
        }

        private void lnkRemoveRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ruleProfile.Rules.Remove(lstRules.SelectedItem as FilterRule);
        }
    }
}
