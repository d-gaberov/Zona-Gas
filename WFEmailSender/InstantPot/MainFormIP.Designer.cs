namespace WFEmailSender.InstantPot
{
    partial class MainFormIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormIP));
            this.tbAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDelFiles = new System.Windows.Forms.CheckBox();
            this.lblPdfFilesCount = new System.Windows.Forms.Label();
            this.lblDocFilesCount = new System.Windows.Forms.Label();
            this.cbDefaultUserPW = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbDefDestDir = new System.Windows.Forms.CheckBox();
            this.cbDefSourceDir = new System.Windows.Forms.CheckBox();
            this.lblFilesDest = new System.Windows.Forms.Label();
            this.lvFilesPdf = new System.Windows.Forms.ListView();
            this.lblDestDir = new System.Windows.Forms.Label();
            this.tbDestDir = new System.Windows.Forms.TextBox();
            this.btnBrowseDestFolder = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSendEmails = new System.Windows.Forms.Button();
            this.lblFilesSource = new System.Windows.Forms.Label();
            this.lvFilesDoc = new System.Windows.Forms.ListView();
            this.zonaGasImg = new System.Windows.Forms.PictureBox();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.tbSourceDir = new System.Windows.Forms.TextBox();
            this.btnBrowseSourceFolder = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbdSelectSourceDir = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdSelectDestDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSwitch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zonaGasImg)).BeginInit();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAlias
            // 
            this.tbAlias.Location = new System.Drawing.Point(554, 263);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(162, 20);
            this.tbAlias.TabIndex = 57;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlias.Location = new System.Drawing.Point(457, 263);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(34, 13);
            this.lblAlias.TabIndex = 56;
            this.lblAlias.Text = "Alias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(832, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "version 1.2.7";
            // 
            // cbDelFiles
            // 
            this.cbDelFiles.AutoSize = true;
            this.cbDelFiles.ForeColor = System.Drawing.Color.Red;
            this.cbDelFiles.Location = new System.Drawing.Point(12, 263);
            this.cbDelFiles.Name = "cbDelFiles";
            this.cbDelFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDelFiles.Size = new System.Drawing.Size(118, 17);
            this.cbDelFiles.TabIndex = 54;
            this.cbDelFiles.Text = "Delete docx/rtf files";
            this.cbDelFiles.UseVisualStyleBackColor = true;
            // 
            // lblPdfFilesCount
            // 
            this.lblPdfFilesCount.AutoSize = true;
            this.lblPdfFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPdfFilesCount.Location = new System.Drawing.Point(144, 362);
            this.lblPdfFilesCount.Name = "lblPdfFilesCount";
            this.lblPdfFilesCount.Size = new System.Drawing.Size(0, 13);
            this.lblPdfFilesCount.TabIndex = 53;
            // 
            // lblDocFilesCount
            // 
            this.lblDocFilesCount.AutoSize = true;
            this.lblDocFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocFilesCount.Location = new System.Drawing.Point(126, 147);
            this.lblDocFilesCount.Name = "lblDocFilesCount";
            this.lblDocFilesCount.Size = new System.Drawing.Size(0, 13);
            this.lblDocFilesCount.TabIndex = 52;
            // 
            // cbDefaultUserPW
            // 
            this.cbDefaultUserPW.AutoSize = true;
            this.cbDefaultUserPW.Location = new System.Drawing.Point(636, 187);
            this.cbDefaultUserPW.Name = "cbDefaultUserPW";
            this.cbDefaultUserPW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefaultUserPW.Size = new System.Drawing.Size(80, 17);
            this.cbDefaultUserPW.TabIndex = 51;
            this.cbDefaultUserPW.Text = "Use default";
            this.cbDefaultUserPW.UseVisualStyleBackColor = true;
            this.cbDefaultUserPW.CheckedChanged += new System.EventHandler(this.cbDefaultEmailPW_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(426, 414);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 50;
            this.lblStatus.Text = "Status:";
            // 
            // cbDefDestDir
            // 
            this.cbDefDestDir.AutoSize = true;
            this.cbDefDestDir.Location = new System.Drawing.Point(160, 307);
            this.cbDefDestDir.Name = "cbDefDestDir";
            this.cbDefDestDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefDestDir.Size = new System.Drawing.Size(80, 17);
            this.cbDefDestDir.TabIndex = 49;
            this.cbDefDestDir.Text = "Use default";
            this.cbDefDestDir.UseVisualStyleBackColor = true;
            this.cbDefDestDir.CheckedChanged += new System.EventHandler(this.cbDefDestDir_CheckedChanged);
            // 
            // cbDefSourceDir
            // 
            this.cbDefSourceDir.AutoSize = true;
            this.cbDefSourceDir.Location = new System.Drawing.Point(160, 93);
            this.cbDefSourceDir.Name = "cbDefSourceDir";
            this.cbDefSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefSourceDir.Size = new System.Drawing.Size(80, 17);
            this.cbDefSourceDir.TabIndex = 48;
            this.cbDefSourceDir.Text = "Use default";
            this.cbDefSourceDir.UseVisualStyleBackColor = true;
            this.cbDefSourceDir.CheckedChanged += new System.EventHandler(this.cbDefSourceDir_CheckedChanged);
            // 
            // lblFilesDest
            // 
            this.lblFilesDest.AutoSize = true;
            this.lblFilesDest.BackColor = System.Drawing.Color.White;
            this.lblFilesDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilesDest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFilesDest.Location = new System.Drawing.Point(12, 362);
            this.lblFilesDest.Name = "lblFilesDest";
            this.lblFilesDest.Size = new System.Drawing.Size(126, 13);
            this.lblFilesDest.TabIndex = 47;
            this.lblFilesDest.Text = "Pdf Files Converted :";
            // 
            // lvFilesPdf
            // 
            this.lvFilesPdf.HideSelection = false;
            this.lvFilesPdf.Location = new System.Drawing.Point(12, 378);
            this.lvFilesPdf.Name = "lvFilesPdf";
            this.lvFilesPdf.Size = new System.Drawing.Size(322, 94);
            this.lvFilesPdf.TabIndex = 46;
            this.lvFilesPdf.UseCompatibleStateImageBehavior = false;
            this.lvFilesPdf.View = System.Windows.Forms.View.List;
            // 
            // lblDestDir
            // 
            this.lblDestDir.AutoSize = true;
            this.lblDestDir.BackColor = System.Drawing.Color.White;
            this.lblDestDir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblDestDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDestDir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDestDir.Location = new System.Drawing.Point(9, 308);
            this.lblDestDir.Name = "lblDestDir";
            this.lblDestDir.Size = new System.Drawing.Size(134, 13);
            this.lblDestDir.TabIndex = 45;
            this.lblDestDir.Text = "Destination Directory :";
            // 
            // tbDestDir
            // 
            this.tbDestDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbDestDir.Location = new System.Drawing.Point(12, 332);
            this.tbDestDir.Name = "tbDestDir";
            this.tbDestDir.Size = new System.Drawing.Size(228, 20);
            this.tbDestDir.TabIndex = 44;
            // 
            // btnBrowseDestFolder
            // 
            this.btnBrowseDestFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseDestFolder.BackgroundImage")));
            this.btnBrowseDestFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowseDestFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseDestFolder.Location = new System.Drawing.Point(246, 332);
            this.btnBrowseDestFolder.Name = "btnBrowseDestFolder";
            this.btnBrowseDestFolder.Size = new System.Drawing.Size(88, 24);
            this.btnBrowseDestFolder.TabIndex = 43;
            this.btnBrowseDestFolder.Text = "Browse";
            this.btnBrowseDestFolder.UseVisualStyleBackColor = true;
            this.btnBrowseDestFolder.Click += new System.EventHandler(this.btnBrowseDestFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(429, 449);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 42;
            // 
            // btnSendEmails
            // 
            this.btnSendEmails.BackColor = System.Drawing.Color.Green;
            this.btnSendEmails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendEmails.BackgroundImage")));
            this.btnSendEmails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendEmails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendEmails.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSendEmails.Location = new System.Drawing.Point(570, 294);
            this.btnSendEmails.Name = "btnSendEmails";
            this.btnSendEmails.Size = new System.Drawing.Size(132, 40);
            this.btnSendEmails.TabIndex = 41;
            this.btnSendEmails.UseVisualStyleBackColor = false;
            this.btnSendEmails.Click += new System.EventHandler(this.btnSendEmails_Click);
            // 
            // lblFilesSource
            // 
            this.lblFilesSource.AutoSize = true;
            this.lblFilesSource.BackColor = System.Drawing.Color.White;
            this.lblFilesSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilesSource.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFilesSource.Location = new System.Drawing.Point(9, 147);
            this.lblFilesSource.Name = "lblFilesSource";
            this.lblFilesSource.Size = new System.Drawing.Size(111, 13);
            this.lblFilesSource.TabIndex = 40;
            this.lblFilesSource.Text = "Docx Files Count :";
            // 
            // lvFilesDoc
            // 
            this.lvFilesDoc.HideSelection = false;
            this.lvFilesDoc.Location = new System.Drawing.Point(12, 163);
            this.lvFilesDoc.Name = "lvFilesDoc";
            this.lvFilesDoc.Size = new System.Drawing.Size(322, 94);
            this.lvFilesDoc.TabIndex = 39;
            this.lvFilesDoc.UseCompatibleStateImageBehavior = false;
            this.lvFilesDoc.View = System.Windows.Forms.View.List;
            // 
            // zonaGasImg
            // 
            this.zonaGasImg.BackColor = System.Drawing.Color.Transparent;
            this.zonaGasImg.Image = ((System.Drawing.Image)(resources.GetObject("zonaGasImg.Image")));
            this.zonaGasImg.Location = new System.Drawing.Point(460, 34);
            this.zonaGasImg.Name = "zonaGasImg";
            this.zonaGasImg.Size = new System.Drawing.Size(305, 76);
            this.zonaGasImg.TabIndex = 38;
            this.zonaGasImg.TabStop = false;
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.AutoSize = true;
            this.lblSourceDir.BackColor = System.Drawing.Color.White;
            this.lblSourceDir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSourceDir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSourceDir.Location = new System.Drawing.Point(9, 93);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(110, 13);
            this.lblSourceDir.TabIndex = 37;
            this.lblSourceDir.Text = "Source Directory :";
            // 
            // tbSourceDir
            // 
            this.tbSourceDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbSourceDir.Location = new System.Drawing.Point(12, 117);
            this.tbSourceDir.Name = "tbSourceDir";
            this.tbSourceDir.Size = new System.Drawing.Size(228, 20);
            this.tbSourceDir.TabIndex = 36;
            // 
            // btnBrowseSourceFolder
            // 
            this.btnBrowseSourceFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseSourceFolder.BackgroundImage")));
            this.btnBrowseSourceFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseSourceFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowseSourceFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBrowseSourceFolder.Location = new System.Drawing.Point(246, 117);
            this.btnBrowseSourceFolder.Name = "btnBrowseSourceFolder";
            this.btnBrowseSourceFolder.Size = new System.Drawing.Size(88, 24);
            this.btnBrowseSourceFolder.TabIndex = 35;
            this.btnBrowseSourceFolder.Text = "Browse";
            this.btnBrowseSourceFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSourceFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(554, 236);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(162, 20);
            this.tbPassword.TabIndex = 34;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(554, 210);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(162, 20);
            this.tbEmail.TabIndex = 33;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPassword.Location = new System.Drawing.Point(457, 240);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 32;
            this.lblPassword.Text = "Password";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmail.Location = new System.Drawing.Point(457, 210);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(37, 13);
            this.lbEmail.TabIndex = 31;
            this.lbEmail.Text = "Email";
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(912, 24);
            this.msMainMenu.TabIndex = 30;
            this.msMainMenu.Text = "mainMenu";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSwitch.BackgroundImage")));
            this.btnSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitch.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
            this.btnSwitch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSwitch.Location = new System.Drawing.Point(12, 478);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(228, 57);
            this.btnSwitch.TabIndex = 58;
            this.btnSwitch.Text = "Switch to ZonaGas";
            this.btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // MainFormIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(912, 553);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.tbAlias);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDelFiles);
            this.Controls.Add(this.lblPdfFilesCount);
            this.Controls.Add(this.lblDocFilesCount);
            this.Controls.Add(this.cbDefaultUserPW);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbDefDestDir);
            this.Controls.Add(this.cbDefSourceDir);
            this.Controls.Add(this.lblFilesDest);
            this.Controls.Add(this.lvFilesPdf);
            this.Controls.Add(this.lblDestDir);
            this.Controls.Add(this.tbDestDir);
            this.Controls.Add(this.btnBrowseDestFolder);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSendEmails);
            this.Controls.Add(this.lblFilesSource);
            this.Controls.Add(this.lvFilesDoc);
            this.Controls.Add(this.zonaGasImg);
            this.Controls.Add(this.lblSourceDir);
            this.Controls.Add(this.tbSourceDir);
            this.Controls.Add(this.btnBrowseSourceFolder);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.msMainMenu);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFormIP";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instant Pot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormIP_FormClosing);
            this.Load += new System.EventHandler(this.MainFormIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zonaGasImg)).EndInit();
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDelFiles;
        private System.Windows.Forms.Label lblPdfFilesCount;
        private System.Windows.Forms.Label lblDocFilesCount;
        private System.Windows.Forms.CheckBox cbDefaultUserPW;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbDefDestDir;
        private System.Windows.Forms.CheckBox cbDefSourceDir;
        private System.Windows.Forms.Label lblFilesDest;
        private System.Windows.Forms.ListView lvFilesPdf;
        private System.Windows.Forms.Label lblDestDir;
        private System.Windows.Forms.TextBox tbDestDir;
        private System.Windows.Forms.Button btnBrowseDestFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSendEmails;
        private System.Windows.Forms.Label lblFilesSource;
        private System.Windows.Forms.ListView lvFilesDoc;
        private System.Windows.Forms.PictureBox zonaGasImg;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.TextBox tbSourceDir;
        private System.Windows.Forms.Button btnBrowseSourceFolder;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectSourceDir;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectDestDir;
        private System.Windows.Forms.Button btnSwitch;
    }
}