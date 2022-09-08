namespace WFEmailSender
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToInstantPotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.fbdSelectSourceDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseSourceFolder = new System.Windows.Forms.Button();
            this.tbSourceDir = new System.Windows.Forms.TextBox();
            this.lblSourceDir = new System.Windows.Forms.Label();
            this.zonaGasImg = new System.Windows.Forms.PictureBox();
            this.lvFilesDoc = new System.Windows.Forms.ListView();
            this.lblFilesSource = new System.Windows.Forms.Label();
            this.btnSendEmails = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblFilesDest = new System.Windows.Forms.Label();
            this.lvFilesPdf = new System.Windows.Forms.ListView();
            this.lblDestDir = new System.Windows.Forms.Label();
            this.tbDestDir = new System.Windows.Forms.TextBox();
            this.btnBrowseDestFolder = new System.Windows.Forms.Button();
            this.cbDefSourceDir = new System.Windows.Forms.CheckBox();
            this.cbDefDestDir = new System.Windows.Forms.CheckBox();
            this.fbdSelectDestDir = new System.Windows.Forms.FolderBrowserDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbDefaultUserPW = new System.Windows.Forms.CheckBox();
            this.lblDocFilesCount = new System.Windows.Forms.Label();
            this.lblPdfFilesCount = new System.Windows.Forms.Label();
            this.cbDelFiles = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zonaGasImg)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(912, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "mainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem2.Text = "Email";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Text = "Settings";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem4.Text = "Info";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
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
            // switchToInstantPotToolStripMenuItem
            // 
            this.switchToInstantPotToolStripMenuItem.Name = "switchToInstantPotToolStripMenuItem";
            this.switchToInstantPotToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEmail.Location = new System.Drawing.Point(457, 211);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(37, 13);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "Email";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPassword.Location = new System.Drawing.Point(457, 241);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(554, 211);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(162, 20);
            this.tbEmail.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(554, 237);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(162, 20);
            this.tbPassword.TabIndex = 4;
            // 
            // btnBrowseSourceFolder
            // 
            this.btnBrowseSourceFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseSourceFolder.BackgroundImage")));
            this.btnBrowseSourceFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseSourceFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowseSourceFolder.ForeColor = System.Drawing.Color.White;
            this.btnBrowseSourceFolder.Location = new System.Drawing.Point(246, 118);
            this.btnBrowseSourceFolder.Name = "btnBrowseSourceFolder";
            this.btnBrowseSourceFolder.Size = new System.Drawing.Size(88, 24);
            this.btnBrowseSourceFolder.TabIndex = 6;
            this.btnBrowseSourceFolder.Text = "Browse";
            this.btnBrowseSourceFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSourceFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tbSourceDir
            // 
            this.tbSourceDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbSourceDir.Location = new System.Drawing.Point(12, 118);
            this.tbSourceDir.Name = "tbSourceDir";
            this.tbSourceDir.Size = new System.Drawing.Size(228, 20);
            this.tbSourceDir.TabIndex = 7;
            // 
            // lblSourceDir
            // 
            this.lblSourceDir.AutoSize = true;
            this.lblSourceDir.BackColor = System.Drawing.Color.White;
            this.lblSourceDir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSourceDir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSourceDir.Location = new System.Drawing.Point(9, 94);
            this.lblSourceDir.Name = "lblSourceDir";
            this.lblSourceDir.Size = new System.Drawing.Size(110, 13);
            this.lblSourceDir.TabIndex = 8;
            this.lblSourceDir.Text = "Source Directory :";
            // 
            // zonaGasImg
            // 
            this.zonaGasImg.BackColor = System.Drawing.Color.Transparent;
            this.zonaGasImg.Image = ((System.Drawing.Image)(resources.GetObject("zonaGasImg.Image")));
            this.zonaGasImg.Location = new System.Drawing.Point(460, 35);
            this.zonaGasImg.Name = "zonaGasImg";
            this.zonaGasImg.Size = new System.Drawing.Size(305, 76);
            this.zonaGasImg.TabIndex = 9;
            this.zonaGasImg.TabStop = false;
            // 
            // lvFilesDoc
            // 
            this.lvFilesDoc.HideSelection = false;
            this.lvFilesDoc.Location = new System.Drawing.Point(12, 164);
            this.lvFilesDoc.Name = "lvFilesDoc";
            this.lvFilesDoc.Size = new System.Drawing.Size(322, 94);
            this.lvFilesDoc.TabIndex = 10;
            this.lvFilesDoc.UseCompatibleStateImageBehavior = false;
            this.lvFilesDoc.View = System.Windows.Forms.View.List;
            // 
            // lblFilesSource
            // 
            this.lblFilesSource.AutoSize = true;
            this.lblFilesSource.BackColor = System.Drawing.Color.White;
            this.lblFilesSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilesSource.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFilesSource.Location = new System.Drawing.Point(9, 148);
            this.lblFilesSource.Name = "lblFilesSource";
            this.lblFilesSource.Size = new System.Drawing.Size(111, 13);
            this.lblFilesSource.TabIndex = 11;
            this.lblFilesSource.Text = "Docx Files Count :";
            // 
            // btnSendEmails
            // 
            this.btnSendEmails.BackColor = System.Drawing.Color.White;
            this.btnSendEmails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendEmails.BackgroundImage")));
            this.btnSendEmails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendEmails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendEmails.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSendEmails.Location = new System.Drawing.Point(570, 296);
            this.btnSendEmails.Name = "btnSendEmails";
            this.btnSendEmails.Size = new System.Drawing.Size(132, 39);
            this.btnSendEmails.TabIndex = 12;
            this.btnSendEmails.UseVisualStyleBackColor = false;
            this.btnSendEmails.Click += new System.EventHandler(this.btnSendEmails_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(429, 450);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 13;
            // 
            // lblFilesDest
            // 
            this.lblFilesDest.AutoSize = true;
            this.lblFilesDest.BackColor = System.Drawing.Color.White;
            this.lblFilesDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilesDest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFilesDest.Location = new System.Drawing.Point(12, 363);
            this.lblFilesDest.Name = "lblFilesDest";
            this.lblFilesDest.Size = new System.Drawing.Size(126, 13);
            this.lblFilesDest.TabIndex = 19;
            this.lblFilesDest.Text = "Pdf Files Converted :";
            // 
            // lvFilesPdf
            // 
            this.lvFilesPdf.HideSelection = false;
            this.lvFilesPdf.Location = new System.Drawing.Point(12, 379);
            this.lvFilesPdf.Name = "lvFilesPdf";
            this.lvFilesPdf.Size = new System.Drawing.Size(322, 94);
            this.lvFilesPdf.TabIndex = 18;
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
            this.lblDestDir.Location = new System.Drawing.Point(9, 309);
            this.lblDestDir.Name = "lblDestDir";
            this.lblDestDir.Size = new System.Drawing.Size(134, 13);
            this.lblDestDir.TabIndex = 17;
            this.lblDestDir.Text = "Destination Directory :";
            // 
            // tbDestDir
            // 
            this.tbDestDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbDestDir.Location = new System.Drawing.Point(12, 333);
            this.tbDestDir.Name = "tbDestDir";
            this.tbDestDir.Size = new System.Drawing.Size(228, 20);
            this.tbDestDir.TabIndex = 16;
            // 
            // btnBrowseDestFolder
            // 
            this.btnBrowseDestFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseDestFolder.BackgroundImage")));
            this.btnBrowseDestFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowseDestFolder.ForeColor = System.Drawing.Color.White;
            this.btnBrowseDestFolder.Location = new System.Drawing.Point(246, 333);
            this.btnBrowseDestFolder.Name = "btnBrowseDestFolder";
            this.btnBrowseDestFolder.Size = new System.Drawing.Size(88, 24);
            this.btnBrowseDestFolder.TabIndex = 15;
            this.btnBrowseDestFolder.Text = "Browse";
            this.btnBrowseDestFolder.UseVisualStyleBackColor = true;
            this.btnBrowseDestFolder.Click += new System.EventHandler(this.btnBrowseDestFolder_Click);
            // 
            // cbDefSourceDir
            // 
            this.cbDefSourceDir.AutoSize = true;
            this.cbDefSourceDir.Location = new System.Drawing.Point(160, 94);
            this.cbDefSourceDir.Name = "cbDefSourceDir";
            this.cbDefSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefSourceDir.Size = new System.Drawing.Size(80, 17);
            this.cbDefSourceDir.TabIndex = 20;
            this.cbDefSourceDir.Text = "Use default";
            this.cbDefSourceDir.UseVisualStyleBackColor = true;
            this.cbDefSourceDir.CheckedChanged += new System.EventHandler(this.cbDefSourceDir_CheckedChanged);
            // 
            // cbDefDestDir
            // 
            this.cbDefDestDir.AutoSize = true;
            this.cbDefDestDir.Location = new System.Drawing.Point(160, 308);
            this.cbDefDestDir.Name = "cbDefDestDir";
            this.cbDefDestDir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefDestDir.Size = new System.Drawing.Size(80, 17);
            this.cbDefDestDir.TabIndex = 21;
            this.cbDefDestDir.Text = "Use default";
            this.cbDefDestDir.UseVisualStyleBackColor = true;
            this.cbDefDestDir.CheckedChanged += new System.EventHandler(this.cbDefDestDir_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(426, 415);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Status:";
            // 
            // cbDefaultUserPW
            // 
            this.cbDefaultUserPW.AutoSize = true;
            this.cbDefaultUserPW.Location = new System.Drawing.Point(636, 188);
            this.cbDefaultUserPW.Name = "cbDefaultUserPW";
            this.cbDefaultUserPW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDefaultUserPW.Size = new System.Drawing.Size(80, 17);
            this.cbDefaultUserPW.TabIndex = 23;
            this.cbDefaultUserPW.Text = "Use default";
            this.cbDefaultUserPW.UseVisualStyleBackColor = true;
            this.cbDefaultUserPW.CheckedChanged += new System.EventHandler(this.cbDefaultEmailPW_CheckedChanged);
            // 
            // lblDocFilesCount
            // 
            this.lblDocFilesCount.AutoSize = true;
            this.lblDocFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocFilesCount.Location = new System.Drawing.Point(126, 148);
            this.lblDocFilesCount.Name = "lblDocFilesCount";
            this.lblDocFilesCount.Size = new System.Drawing.Size(0, 13);
            this.lblDocFilesCount.TabIndex = 24;
            // 
            // lblPdfFilesCount
            // 
            this.lblPdfFilesCount.AutoSize = true;
            this.lblPdfFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPdfFilesCount.Location = new System.Drawing.Point(144, 363);
            this.lblPdfFilesCount.Name = "lblPdfFilesCount";
            this.lblPdfFilesCount.Size = new System.Drawing.Size(0, 13);
            this.lblPdfFilesCount.TabIndex = 25;
            // 
            // cbDelFiles
            // 
            this.cbDelFiles.AutoSize = true;
            this.cbDelFiles.ForeColor = System.Drawing.Color.Red;
            this.cbDelFiles.Location = new System.Drawing.Point(12, 264);
            this.cbDelFiles.Name = "cbDelFiles";
            this.cbDelFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDelFiles.Size = new System.Drawing.Size(118, 17);
            this.cbDelFiles.TabIndex = 26;
            this.cbDelFiles.Text = "Delete docx/rtf files";
            this.cbDelFiles.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(832, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "version 1.2.6";
            // 
            // tbAlias
            // 
            this.tbAlias.Location = new System.Drawing.Point(554, 264);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(162, 20);
            this.tbAlias.TabIndex = 29;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlias.Location = new System.Drawing.Point(457, 264);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(34, 13);
            this.lblAlias.TabIndex = 28;
            this.lblAlias.Text = "Alias";
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackColor = System.Drawing.Color.DarkGray;
            this.btnSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSwitch.BackgroundImage")));
            this.btnSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitch.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.ForeColor = System.Drawing.Color.White;
            this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
            this.btnSwitch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSwitch.Location = new System.Drawing.Point(12, 479);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(228, 57);
            this.btnSwitch.TabIndex = 30;
            this.btnSwitch.Text = "Switch to InstantPot";
            this.btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zona Gas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zonaGasImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectSourceDir;
        private System.Windows.Forms.Button btnBrowseSourceFolder;
        private System.Windows.Forms.TextBox tbSourceDir;
        private System.Windows.Forms.Label lblSourceDir;
        private System.Windows.Forms.PictureBox zonaGasImg;
        private System.Windows.Forms.ListView lvFilesDoc;
        private System.Windows.Forms.Label lblFilesSource;
        private System.Windows.Forms.Button btnSendEmails;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFilesDest;
        private System.Windows.Forms.ListView lvFilesPdf;
        private System.Windows.Forms.Label lblDestDir;
        private System.Windows.Forms.TextBox tbDestDir;
        private System.Windows.Forms.Button btnBrowseDestFolder;
        private System.Windows.Forms.CheckBox cbDefSourceDir;
        private System.Windows.Forms.CheckBox cbDefDestDir;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectDestDir;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbDefaultUserPW;
        private System.Windows.Forms.Label lblDocFilesCount;
        private System.Windows.Forms.Label lblPdfFilesCount;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbDelFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.ToolStripMenuItem switchToInstantPotToolStripMenuItem;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

