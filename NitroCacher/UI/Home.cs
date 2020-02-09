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

        RuleProfile _ruleProfile => _userSettings.RuleProfiles.First(r => r.Id == _userSettings.SelectedProfileId);

        public Home(UserSettings userSettings, Action<string> clearCacheForRule, Action<string> clearAllCacheForProfile, Action clearAllCache)
        {
            _userSettings = userSettings;
            _clearCacheForRule = clearCacheForRule;
            _clearAllCacheForProfile = clearAllCacheForProfile;
            _clearAllCache = clearAllCache;
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
            lstProfiles.Items.Clear();
            lstProfiles.Items.AddRange(_userSettings.RuleProfiles.ToArray());
            PopulateRulesList();
        }

        private void PopulateRulesList()
        {
            _ruleProfile.Rules.Clear();
            foreach (var rule in _ruleProfile.Rules)
            {
                lstRules.Items.Add(rule, rule.IsEnabled);
            }
        }

        private void lnkAddNewProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var newProfileName= GetPromptTextInput("Enter a profile name.", "Enter a profile name.");
            if(string.IsNullOrWhiteSpace(newProfileName)) { return; }
            string newProfileId = Guid.NewGuid().ToString();
            _userSettings.RuleProfiles.Add(new RuleProfile
            {
                Id = newProfileId,
                Name = newProfileName,
                Rules = new List<FilterRule>()
            });
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
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
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
        }
    }
}
