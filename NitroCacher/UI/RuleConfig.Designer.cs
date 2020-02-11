namespace NitroCacher.UI
{
    partial class RuleConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.lblRuleName = new System.Windows.Forms.Label();
            this.lstMatchType = new System.Windows.Forms.ComboBox();
            this.lblMatchUrlType = new System.Windows.Forms.Label();
            this.lblMatchCriteria = new System.Windows.Forms.Label();
            this.txtMatchCriteria = new System.Windows.Forms.TextBox();
            this.txtHeadersToIgnore = new System.Windows.Forms.TextBox();
            this.lblHeadersToIgnore = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkShowInUi = new System.Windows.Forms.CheckBox();
            this.pctForegroundColor = new System.Windows.Forms.PictureBox();
            this.pctBackgroundColor = new System.Windows.Forms.PictureBox();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.lblUiSample = new System.Windows.Forms.Label();
            this.pnlColorSelection = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pctForegroundColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBackgroundColor)).BeginInit();
            this.pnlColorSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(295, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(376, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtRuleName
            // 
            this.txtRuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuleName.Location = new System.Drawing.Point(149, 24);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(284, 21);
            this.txtRuleName.TabIndex = 1;
            // 
            // lblRuleName
            // 
            this.lblRuleName.AutoSize = true;
            this.lblRuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleName.Location = new System.Drawing.Point(12, 24);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(48, 16);
            this.lblRuleName.TabIndex = 2;
            this.lblRuleName.Text = "Name:";
            // 
            // lstMatchType
            // 
            this.lstMatchType.FormattingEnabled = true;
            this.lstMatchType.Location = new System.Drawing.Point(149, 63);
            this.lstMatchType.Name = "lstMatchType";
            this.lstMatchType.Size = new System.Drawing.Size(284, 21);
            this.lstMatchType.TabIndex = 3;
            // 
            // lblMatchUrlType
            // 
            this.lblMatchUrlType.AutoSize = true;
            this.lblMatchUrlType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchUrlType.Location = new System.Drawing.Point(12, 64);
            this.lblMatchUrlType.Name = "lblMatchUrlType";
            this.lblMatchUrlType.Size = new System.Drawing.Size(76, 16);
            this.lblMatchUrlType.TabIndex = 2;
            this.lblMatchUrlType.Text = "Match type:";
            // 
            // lblMatchCriteria
            // 
            this.lblMatchCriteria.AutoSize = true;
            this.lblMatchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchCriteria.Location = new System.Drawing.Point(12, 103);
            this.lblMatchCriteria.Name = "lblMatchCriteria";
            this.lblMatchCriteria.Size = new System.Drawing.Size(72, 16);
            this.lblMatchCriteria.TabIndex = 2;
            this.lblMatchCriteria.Text = "Match with:";
            // 
            // txtMatchCriteria
            // 
            this.txtMatchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatchCriteria.Location = new System.Drawing.Point(149, 98);
            this.txtMatchCriteria.Name = "txtMatchCriteria";
            this.txtMatchCriteria.Size = new System.Drawing.Size(284, 21);
            this.txtMatchCriteria.TabIndex = 1;
            // 
            // txtHeadersToIgnore
            // 
            this.txtHeadersToIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeadersToIgnore.Location = new System.Drawing.Point(149, 133);
            this.txtHeadersToIgnore.Name = "txtHeadersToIgnore";
            this.txtHeadersToIgnore.Size = new System.Drawing.Size(284, 21);
            this.txtHeadersToIgnore.TabIndex = 1;
            // 
            // lblHeadersToIgnore
            // 
            this.lblHeadersToIgnore.AutoSize = true;
            this.lblHeadersToIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadersToIgnore.Location = new System.Drawing.Point(12, 138);
            this.lblHeadersToIgnore.Name = "lblHeadersToIgnore";
            this.lblHeadersToIgnore.Size = new System.Drawing.Size(119, 16);
            this.lblHeadersToIgnore.TabIndex = 2;
            this.lblHeadersToIgnore.Text = "Headers to ignore:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnabled.Location = new System.Drawing.Point(12, 257);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(78, 20);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkShowInUi
            // 
            this.chkShowInUi.AutoSize = true;
            this.chkShowInUi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowInUi.Location = new System.Drawing.Point(12, 172);
            this.chkShowInUi.Name = "chkShowInUi";
            this.chkShowInUi.Size = new System.Drawing.Size(170, 20);
            this.chkShowInUi.TabIndex = 4;
            this.chkShowInUi.Text = "Show sessions in fiddler";
            this.chkShowInUi.UseVisualStyleBackColor = true;
            this.chkShowInUi.CheckedChanged += new System.EventHandler(this.chkShowInUi_CheckedChanged);
            // 
            // pctForegroundColor
            // 
            this.pctForegroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctForegroundColor.Location = new System.Drawing.Point(3, 4);
            this.pctForegroundColor.Name = "pctForegroundColor";
            this.pctForegroundColor.Size = new System.Drawing.Size(16, 15);
            this.pctForegroundColor.TabIndex = 5;
            this.pctForegroundColor.TabStop = false;
            this.pctForegroundColor.Click += new System.EventHandler(this.pctForegroundColor_Click);
            // 
            // pctBackgroundColor
            // 
            this.pctBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBackgroundColor.Location = new System.Drawing.Point(96, 5);
            this.pctBackgroundColor.Name = "pctBackgroundColor";
            this.pctBackgroundColor.Size = new System.Drawing.Size(16, 15);
            this.pctBackgroundColor.TabIndex = 5;
            this.pctBackgroundColor.TabStop = false;
            this.pctBackgroundColor.Click += new System.EventHandler(this.pctBackgroundColor_Click);
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextColor.Location = new System.Drawing.Point(25, 4);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(67, 16);
            this.lblTextColor.TabIndex = 2;
            this.lblTextColor.Text = "Text color";
            // 
            // lblBackgroundColor
            // 
            this.lblBackgroundColor.AutoSize = true;
            this.lblBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackgroundColor.Location = new System.Drawing.Point(118, 4);
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            this.lblBackgroundColor.Size = new System.Drawing.Size(72, 16);
            this.lblBackgroundColor.TabIndex = 2;
            this.lblBackgroundColor.Text = "Back color";
            // 
            // lblUiSample
            // 
            this.lblUiSample.AutoSize = true;
            this.lblUiSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUiSample.Location = new System.Drawing.Point(0, 37);
            this.lblUiSample.Name = "lblUiSample";
            this.lblUiSample.Size = new System.Drawing.Size(63, 16);
            this.lblUiSample.TabIndex = 6;
            this.lblUiSample.Text = "(Sample)";
            // 
            // pnlColorSelection
            // 
            this.pnlColorSelection.Controls.Add(this.lblBackgroundColor);
            this.pnlColorSelection.Controls.Add(this.lblUiSample);
            this.pnlColorSelection.Controls.Add(this.lblTextColor);
            this.pnlColorSelection.Controls.Add(this.pctBackgroundColor);
            this.pnlColorSelection.Controls.Add(this.pctForegroundColor);
            this.pnlColorSelection.Location = new System.Drawing.Point(29, 191);
            this.pnlColorSelection.Name = "pnlColorSelection";
            this.pnlColorSelection.Size = new System.Drawing.Size(200, 61);
            this.pnlColorSelection.TabIndex = 7;
            // 
            // RuleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 316);
            this.ControlBox = false;
            this.Controls.Add(this.pnlColorSelection);
            this.Controls.Add(this.chkShowInUi);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lstMatchType);
            this.Controls.Add(this.lblHeadersToIgnore);
            this.Controls.Add(this.lblMatchCriteria);
            this.Controls.Add(this.lblMatchUrlType);
            this.Controls.Add(this.lblRuleName);
            this.Controls.Add(this.txtHeadersToIgnore);
            this.Controls.Add(this.txtMatchCriteria);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configure Rule";
            ((System.ComponentModel.ISupportInitialize)(this.pctForegroundColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBackgroundColor)).EndInit();
            this.pnlColorSelection.ResumeLayout(false);
            this.pnlColorSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label lblRuleName;
        private System.Windows.Forms.ComboBox lstMatchType;
        private System.Windows.Forms.Label lblMatchUrlType;
        private System.Windows.Forms.Label lblMatchCriteria;
        private System.Windows.Forms.TextBox txtMatchCriteria;
        private System.Windows.Forms.TextBox txtHeadersToIgnore;
        private System.Windows.Forms.Label lblHeadersToIgnore;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkShowInUi;
        private System.Windows.Forms.PictureBox pctForegroundColor;
        private System.Windows.Forms.PictureBox pctBackgroundColor;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.Label lblUiSample;
        private System.Windows.Forms.Panel pnlColorSelection;
    }
}