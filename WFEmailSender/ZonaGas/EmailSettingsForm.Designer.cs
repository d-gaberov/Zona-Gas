namespace WFEmailSender
{
    partial class EmailSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblInvoiceFooter = new System.Windows.Forms.Label();
            this.tbInvoiceFooter = new System.Windows.Forms.TextBox();
            this.lblInvoiceSubject = new System.Windows.Forms.Label();
            this.tbInvoiceSubject = new System.Windows.Forms.TextBox();
            this.lblInvoiceWaybill = new System.Windows.Forms.Label();
            this.lblInvoiceBody = new System.Windows.Forms.Label();
            this.tbInvoiceWaybill = new System.Windows.Forms.TextBox();
            this.tbInvoiceBody = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCertFooter = new System.Windows.Forms.Label();
            this.tbCertFooter = new System.Windows.Forms.TextBox();
            this.lblCertSubject = new System.Windows.Forms.Label();
            this.tbCertSubject = new System.Windows.Forms.TextBox();
            this.lblCertWaybill = new System.Windows.Forms.Label();
            this.lblCertBody = new System.Windows.Forms.Label();
            this.tbCertWaybill = new System.Windows.Forms.TextBox();
            this.tbCertBody = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblReportFooter = new System.Windows.Forms.Label();
            this.tbReportFooter = new System.Windows.Forms.TextBox();
            this.lblReportSubject = new System.Windows.Forms.Label();
            this.tbReportSubject = new System.Windows.Forms.TextBox();
            this.lblReportWaybill = new System.Windows.Forms.Label();
            this.lblReportBody = new System.Windows.Forms.Label();
            this.tbReportWaybill = new System.Windows.Forms.TextBox();
            this.tbReportBody = new System.Windows.Forms.TextBox();
            this.lblBanner = new System.Windows.Forms.Label();
            this.btnChangeBanner = new System.Windows.Forms.Button();
            this.btnSaveEmailSettings = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.lblBannerLink = new System.Windows.Forms.Label();
            this.tbAdLink = new System.Windows.Forms.TextBox();
            this.tbBannerDirectory = new System.Windows.Forms.TextBox();
            this.ofdBannerDir = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(316, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblInvoiceFooter);
            this.tabPage1.Controls.Add(this.tbInvoiceFooter);
            this.tabPage1.Controls.Add(this.lblInvoiceSubject);
            this.tabPage1.Controls.Add(this.tbInvoiceSubject);
            this.tabPage1.Controls.Add(this.lblInvoiceWaybill);
            this.tabPage1.Controls.Add(this.lblInvoiceBody);
            this.tabPage1.Controls.Add(this.tbInvoiceWaybill);
            this.tabPage1.Controls.Add(this.tbInvoiceBody);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Invoice";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblInvoiceFooter
            // 
            this.lblInvoiceFooter.AutoSize = true;
            this.lblInvoiceFooter.Location = new System.Drawing.Point(18, 249);
            this.lblInvoiceFooter.Name = "lblInvoiceFooter";
            this.lblInvoiceFooter.Size = new System.Drawing.Size(40, 13);
            this.lblInvoiceFooter.TabIndex = 28;
            this.lblInvoiceFooter.Text = "Footer:";
            // 
            // tbInvoiceFooter
            // 
            this.tbInvoiceFooter.Location = new System.Drawing.Point(68, 249);
            this.tbInvoiceFooter.Multiline = true;
            this.tbInvoiceFooter.Name = "tbInvoiceFooter";
            this.tbInvoiceFooter.Size = new System.Drawing.Size(387, 47);
            this.tbInvoiceFooter.TabIndex = 27;
            // 
            // lblInvoiceSubject
            // 
            this.lblInvoiceSubject.AutoSize = true;
            this.lblInvoiceSubject.Location = new System.Drawing.Point(18, 17);
            this.lblInvoiceSubject.Name = "lblInvoiceSubject";
            this.lblInvoiceSubject.Size = new System.Drawing.Size(46, 13);
            this.lblInvoiceSubject.TabIndex = 26;
            this.lblInvoiceSubject.Text = "Subject:";
            // 
            // tbInvoiceSubject
            // 
            this.tbInvoiceSubject.Location = new System.Drawing.Point(68, 17);
            this.tbInvoiceSubject.Multiline = true;
            this.tbInvoiceSubject.Name = "tbInvoiceSubject";
            this.tbInvoiceSubject.Size = new System.Drawing.Size(387, 31);
            this.tbInvoiceSubject.TabIndex = 25;
            // 
            // lblInvoiceWaybill
            // 
            this.lblInvoiceWaybill.AutoSize = true;
            this.lblInvoiceWaybill.Location = new System.Drawing.Point(18, 196);
            this.lblInvoiceWaybill.Name = "lblInvoiceWaybill";
            this.lblInvoiceWaybill.Size = new System.Drawing.Size(44, 13);
            this.lblInvoiceWaybill.TabIndex = 24;
            this.lblInvoiceWaybill.Text = "Waybill:";
            // 
            // lblInvoiceBody
            // 
            this.lblInvoiceBody.AutoSize = true;
            this.lblInvoiceBody.Location = new System.Drawing.Point(18, 52);
            this.lblInvoiceBody.Name = "lblInvoiceBody";
            this.lblInvoiceBody.Size = new System.Drawing.Size(34, 13);
            this.lblInvoiceBody.TabIndex = 23;
            this.lblInvoiceBody.Text = "Body:";
            // 
            // tbInvoiceWaybill
            // 
            this.tbInvoiceWaybill.Enabled = false;
            this.tbInvoiceWaybill.Location = new System.Drawing.Point(68, 196);
            this.tbInvoiceWaybill.Multiline = true;
            this.tbInvoiceWaybill.Name = "tbInvoiceWaybill";
            this.tbInvoiceWaybill.Size = new System.Drawing.Size(387, 47);
            this.tbInvoiceWaybill.TabIndex = 22;
            // 
            // tbInvoiceBody
            // 
            this.tbInvoiceBody.Location = new System.Drawing.Point(68, 52);
            this.tbInvoiceBody.Multiline = true;
            this.tbInvoiceBody.Name = "tbInvoiceBody";
            this.tbInvoiceBody.Size = new System.Drawing.Size(387, 138);
            this.tbInvoiceBody.TabIndex = 21;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCertFooter);
            this.tabPage2.Controls.Add(this.tbCertFooter);
            this.tabPage2.Controls.Add(this.lblCertSubject);
            this.tabPage2.Controls.Add(this.tbCertSubject);
            this.tabPage2.Controls.Add(this.lblCertWaybill);
            this.tabPage2.Controls.Add(this.lblCertBody);
            this.tabPage2.Controls.Add(this.tbCertWaybill);
            this.tabPage2.Controls.Add(this.tbCertBody);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Certificate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCertFooter
            // 
            this.lblCertFooter.AutoSize = true;
            this.lblCertFooter.Location = new System.Drawing.Point(18, 249);
            this.lblCertFooter.Name = "lblCertFooter";
            this.lblCertFooter.Size = new System.Drawing.Size(40, 13);
            this.lblCertFooter.TabIndex = 30;
            this.lblCertFooter.Text = "Footer:";
            // 
            // tbCertFooter
            // 
            this.tbCertFooter.Location = new System.Drawing.Point(68, 249);
            this.tbCertFooter.Multiline = true;
            this.tbCertFooter.Name = "tbCertFooter";
            this.tbCertFooter.Size = new System.Drawing.Size(387, 47);
            this.tbCertFooter.TabIndex = 29;
            // 
            // lblCertSubject
            // 
            this.lblCertSubject.AutoSize = true;
            this.lblCertSubject.Location = new System.Drawing.Point(18, 17);
            this.lblCertSubject.Name = "lblCertSubject";
            this.lblCertSubject.Size = new System.Drawing.Size(46, 13);
            this.lblCertSubject.TabIndex = 26;
            this.lblCertSubject.Text = "Subject:";
            // 
            // tbCertSubject
            // 
            this.tbCertSubject.Location = new System.Drawing.Point(68, 17);
            this.tbCertSubject.Multiline = true;
            this.tbCertSubject.Name = "tbCertSubject";
            this.tbCertSubject.Size = new System.Drawing.Size(387, 31);
            this.tbCertSubject.TabIndex = 25;
            // 
            // lblCertWaybill
            // 
            this.lblCertWaybill.AutoSize = true;
            this.lblCertWaybill.Location = new System.Drawing.Point(18, 196);
            this.lblCertWaybill.Name = "lblCertWaybill";
            this.lblCertWaybill.Size = new System.Drawing.Size(44, 13);
            this.lblCertWaybill.TabIndex = 24;
            this.lblCertWaybill.Text = "Waybill:";
            // 
            // lblCertBody
            // 
            this.lblCertBody.AutoSize = true;
            this.lblCertBody.Location = new System.Drawing.Point(18, 52);
            this.lblCertBody.Name = "lblCertBody";
            this.lblCertBody.Size = new System.Drawing.Size(34, 13);
            this.lblCertBody.TabIndex = 23;
            this.lblCertBody.Text = "Body:";
            // 
            // tbCertWaybill
            // 
            this.tbCertWaybill.Enabled = false;
            this.tbCertWaybill.Location = new System.Drawing.Point(68, 196);
            this.tbCertWaybill.Multiline = true;
            this.tbCertWaybill.Name = "tbCertWaybill";
            this.tbCertWaybill.Size = new System.Drawing.Size(387, 47);
            this.tbCertWaybill.TabIndex = 22;
            // 
            // tbCertBody
            // 
            this.tbCertBody.Location = new System.Drawing.Point(68, 52);
            this.tbCertBody.Multiline = true;
            this.tbCertBody.Name = "tbCertBody";
            this.tbCertBody.Size = new System.Drawing.Size(387, 138);
            this.tbCertBody.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblReportFooter);
            this.tabPage3.Controls.Add(this.tbReportFooter);
            this.tabPage3.Controls.Add(this.lblReportSubject);
            this.tabPage3.Controls.Add(this.tbReportSubject);
            this.tabPage3.Controls.Add(this.lblReportWaybill);
            this.tabPage3.Controls.Add(this.lblReportBody);
            this.tabPage3.Controls.Add(this.tbReportWaybill);
            this.tabPage3.Controls.Add(this.tbReportBody);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(458, 302);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Report";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblReportFooter
            // 
            this.lblReportFooter.AutoSize = true;
            this.lblReportFooter.Location = new System.Drawing.Point(18, 249);
            this.lblReportFooter.Name = "lblReportFooter";
            this.lblReportFooter.Size = new System.Drawing.Size(40, 13);
            this.lblReportFooter.TabIndex = 38;
            this.lblReportFooter.Text = "Footer:";
            // 
            // tbReportFooter
            // 
            this.tbReportFooter.Location = new System.Drawing.Point(68, 249);
            this.tbReportFooter.Multiline = true;
            this.tbReportFooter.Name = "tbReportFooter";
            this.tbReportFooter.Size = new System.Drawing.Size(387, 47);
            this.tbReportFooter.TabIndex = 37;
            // 
            // lblReportSubject
            // 
            this.lblReportSubject.AutoSize = true;
            this.lblReportSubject.Location = new System.Drawing.Point(18, 17);
            this.lblReportSubject.Name = "lblReportSubject";
            this.lblReportSubject.Size = new System.Drawing.Size(46, 13);
            this.lblReportSubject.TabIndex = 36;
            this.lblReportSubject.Text = "Subject:";
            // 
            // tbReportSubject
            // 
            this.tbReportSubject.Location = new System.Drawing.Point(68, 17);
            this.tbReportSubject.Multiline = true;
            this.tbReportSubject.Name = "tbReportSubject";
            this.tbReportSubject.Size = new System.Drawing.Size(387, 31);
            this.tbReportSubject.TabIndex = 35;
            // 
            // lblReportWaybill
            // 
            this.lblReportWaybill.AutoSize = true;
            this.lblReportWaybill.Location = new System.Drawing.Point(18, 196);
            this.lblReportWaybill.Name = "lblReportWaybill";
            this.lblReportWaybill.Size = new System.Drawing.Size(44, 13);
            this.lblReportWaybill.TabIndex = 34;
            this.lblReportWaybill.Text = "Waybill:";
            // 
            // lblReportBody
            // 
            this.lblReportBody.AutoSize = true;
            this.lblReportBody.Location = new System.Drawing.Point(18, 52);
            this.lblReportBody.Name = "lblReportBody";
            this.lblReportBody.Size = new System.Drawing.Size(34, 13);
            this.lblReportBody.TabIndex = 33;
            this.lblReportBody.Text = "Body:";
            // 
            // tbReportWaybill
            // 
            this.tbReportWaybill.Enabled = false;
            this.tbReportWaybill.Location = new System.Drawing.Point(68, 196);
            this.tbReportWaybill.Multiline = true;
            this.tbReportWaybill.Name = "tbReportWaybill";
            this.tbReportWaybill.Size = new System.Drawing.Size(387, 47);
            this.tbReportWaybill.TabIndex = 32;
            // 
            // tbReportBody
            // 
            this.tbReportBody.Location = new System.Drawing.Point(68, 52);
            this.tbReportBody.Multiline = true;
            this.tbReportBody.Name = "tbReportBody";
            this.tbReportBody.Size = new System.Drawing.Size(387, 138);
            this.tbReportBody.TabIndex = 31;
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Location = new System.Drawing.Point(12, 42);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(80, 13);
            this.lblBanner.TabIndex = 1;
            this.lblBanner.Text = "Current banner:";
            // 
            // btnChangeBanner
            // 
            this.btnChangeBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangeBanner.BackgroundImage")));
            this.btnChangeBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeBanner.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChangeBanner.Location = new System.Drawing.Point(199, 33);
            this.btnChangeBanner.Name = "btnChangeBanner";
            this.btnChangeBanner.Size = new System.Drawing.Size(101, 31);
            this.btnChangeBanner.TabIndex = 2;
            this.btnChangeBanner.Text = "Change";
            this.btnChangeBanner.UseVisualStyleBackColor = true;
            this.btnChangeBanner.Click += new System.EventHandler(this.btnChangeBanner_Click);
            // 
            // btnSaveEmailSettings
            // 
            this.btnSaveEmailSettings.BackColor = System.Drawing.Color.Green;
            this.btnSaveEmailSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveEmailSettings.BackgroundImage")));
            this.btnSaveEmailSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveEmailSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveEmailSettings.Location = new System.Drawing.Point(672, 346);
            this.btnSaveEmailSettings.Name = "btnSaveEmailSettings";
            this.btnSaveEmailSettings.Size = new System.Drawing.Size(110, 32);
            this.btnSaveEmailSettings.TabIndex = 12;
            this.btnSaveEmailSettings.UseVisualStyleBackColor = false;
            this.btnSaveEmailSettings.Click += new System.EventHandler(this.btnSaveEmailSettings_Click);
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(12, 155);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(288, 111);
            this.pbBanner.TabIndex = 13;
            this.pbBanner.TabStop = false;
            // 
            // lblBannerLink
            // 
            this.lblBannerLink.AutoSize = true;
            this.lblBannerLink.Location = new System.Drawing.Point(9, 283);
            this.lblBannerLink.Name = "lblBannerLink";
            this.lblBannerLink.Size = new System.Drawing.Size(96, 13);
            this.lblBannerLink.TabIndex = 14;
            this.lblBannerLink.Text = "Advertisement link:";
            // 
            // tbAdLink
            // 
            this.tbAdLink.Location = new System.Drawing.Point(12, 311);
            this.tbAdLink.Multiline = true;
            this.tbAdLink.Name = "tbAdLink";
            this.tbAdLink.Size = new System.Drawing.Size(288, 25);
            this.tbAdLink.TabIndex = 26;
            // 
            // tbBannerDirectory
            // 
            this.tbBannerDirectory.Location = new System.Drawing.Point(12, 86);
            this.tbBannerDirectory.Multiline = true;
            this.tbBannerDirectory.Name = "tbBannerDirectory";
            this.tbBannerDirectory.Size = new System.Drawing.Size(288, 35);
            this.tbBannerDirectory.TabIndex = 27;
            // 
            // EmailSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 381);
            this.Controls.Add(this.tbBannerDirectory);
            this.Controls.Add(this.tbAdLink);
            this.Controls.Add(this.lblBannerLink);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.btnSaveEmailSettings);
            this.Controls.Add(this.btnChangeBanner);
            this.Controls.Add(this.lblBanner);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Settings";
            this.Load += new System.EventHandler(this.EmailSettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.Button btnChangeBanner;
        private System.Windows.Forms.Button btnSaveEmailSettings;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Label lblInvoiceSubject;
        private System.Windows.Forms.TextBox tbInvoiceSubject;
        private System.Windows.Forms.Label lblInvoiceWaybill;
        private System.Windows.Forms.Label lblInvoiceBody;
        private System.Windows.Forms.TextBox tbInvoiceWaybill;
        private System.Windows.Forms.TextBox tbInvoiceBody;
        private System.Windows.Forms.Label lblCertSubject;
        private System.Windows.Forms.TextBox tbCertSubject;
        private System.Windows.Forms.Label lblCertWaybill;
        private System.Windows.Forms.Label lblCertBody;
        private System.Windows.Forms.TextBox tbCertWaybill;
        private System.Windows.Forms.TextBox tbCertBody;
        private System.Windows.Forms.Label lblBannerLink;
        private System.Windows.Forms.TextBox tbAdLink;
        private System.Windows.Forms.TextBox tbBannerDirectory;
        private System.Windows.Forms.OpenFileDialog ofdBannerDir;
        private System.Windows.Forms.Label lblInvoiceFooter;
        private System.Windows.Forms.TextBox tbInvoiceFooter;
        private System.Windows.Forms.Label lblCertFooter;
        private System.Windows.Forms.TextBox tbCertFooter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblReportFooter;
        private System.Windows.Forms.TextBox tbReportFooter;
        private System.Windows.Forms.Label lblReportSubject;
        private System.Windows.Forms.TextBox tbReportSubject;
        private System.Windows.Forms.Label lblReportWaybill;
        private System.Windows.Forms.Label lblReportBody;
        private System.Windows.Forms.TextBox tbReportWaybill;
        private System.Windows.Forms.TextBox tbReportBody;
    }
}