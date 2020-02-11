using NitroCacher.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroCacher.UI
{
    public partial class RuleConfig : Form
    {
        FilterRule _rule;
        public FilterRule ConfiguredRule => _rule;
        public RuleConfig(FilterRule rule = null)
        {
            _rule = rule ?? new FilterRule()
            {
                Id = Guid.NewGuid().ToString(),
                IsEnabled = true,
                IsShownInUi = true,
                BackgroundColor = Color.Black,
                ForegroundColor = Color.White
            };
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            var matchTypes = Enum.GetNames(typeof(MatchType));
            lstMatchType.Items.AddRange(matchTypes);

            txtRuleName.Text = _rule.Name;
            lstMatchType.SelectedItem = _rule.MatchType.ToString();
            txtMatchCriteria.Text = _rule.Criteria;
            txtHeadersToIgnore.Text = string.Join(";", _rule.HeadersToIgnore ?? new List<string>());
            chkShowInUi.Checked = _rule.IsShownInUi;
            chkEnabled.Checked = _rule.IsEnabled;
            lblUiSample.BackColor = pctBackgroundColor.BackColor = _rule.BackgroundColor;
            lblUiSample.ForeColor = pctForegroundColor.BackColor = _rule.ForegroundColor;
            pnlColorSelection.Enabled = chkShowInUi.Checked;
        }

        private void SaveData()
        {
            var matchTypes = Enum.GetNames(typeof(MatchType));
            lstMatchType.Items.AddRange(matchTypes);

            _rule.Name = txtRuleName.Text;
            _rule.MatchType = (MatchType)Enum.Parse(typeof(MatchType), lstMatchType.SelectedItem.ToString());
            _rule.Criteria = txtMatchCriteria.Text;
            _rule.HeadersToIgnore = txtHeadersToIgnore.Text.Split(';').ToList();
            _rule.IsShownInUi = chkShowInUi.Checked;
            _rule.IsEnabled = chkEnabled.Checked;
            _rule.BackgroundColor = pctBackgroundColor.BackColor;
            _rule.ForegroundColor = pctForegroundColor.BackColor;
        }

        private void chkShowInUi_CheckedChanged(object sender, EventArgs e)
        {
            pnlColorSelection.Enabled = chkShowInUi.Checked;
        }

        private void SelectColor(PictureBox showColorControl)
        {
            var colorBox = new ColorDialog();
            var result = colorBox.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                showColorControl.BackColor = colorBox.Color;

            }
        }

        private void pctForegroundColor_Click(object sender, EventArgs e)
        {
            SelectColor(pctForegroundColor);
            lblUiSample.ForeColor = pctForegroundColor.BackColor;
        }

        private void pctBackgroundColor_Click(object sender, EventArgs e)
        {
            SelectColor(pctBackgroundColor);
            lblUiSample.BackColor = pctBackgroundColor.BackColor;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
