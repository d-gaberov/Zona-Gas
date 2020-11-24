namespace WFEmailSender.InstantPot
{
    partial class SettingsFormIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFormIP));
            this.tbAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRtf = new System.Windows.Forms.CheckBox();
            this.cbDocx = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDefDestDir = new System.Windows.Forms.Button();
            this.tbDefDestDir = new System.Windows.Forms.TextBox();
            this.lblDefDestDir = new System.Windows.Forms.Label();
            this.btnDefSourceDir = new System.Windows.Forms.Button();
            this.tbDefSourceDir = new System.Windows.Forms.TextBox();
            this.lblDefSourceDir = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblEmailAndPwDescr = new System.Windows.Forms.Label();
            this.lblDefPW = new System.Windows.Forms.Label();
            this.lblDefEmail = new System.Windows.Forms.Label();
            this.fbdDefSourceDir = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdDefDestDir = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // tbAlias
            // 
            this.tbAlias.Location = new System.Drawing.Point(89, 97);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(188, 20);
            this.tbAlias.TabIndex = 33;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(25, 104);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 32;
            this.lblAlias.Text = "Alias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Source files format:";
            // 
            // cbRtf
            // 
            this.cbRtf.AutoSize = true;
            this.cbRtf.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRtf.Location = new System.Drawing.Point(332, 74);
            this.cbRtf.Name = "cbRtf";
            this.cbRtf.Size = new System.Drawing.Size(47, 17);
            this.cbRtf.TabIndex = 30;
            this.cbRtf.Text = "rtf    ";
            this.cbRtf.UseVisualStyleBackColor = true;
            this.cbRtf.CheckedChanged += new System.EventHandler(this.cbRtf_CheckedChanged);
            // 
            // cbDocx
            // 
            this.cbDocx.AutoSize = true;
            this.cbDocx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDocx.Location = new System.Drawing.Point(330, 48);
            this.cbDocx.Name = "cbDocx";
            this.cbDocx.Size = new System.Drawing.Size(49, 17);
            this.cbDocx.TabIndex = 29;
            this.cbDocx.Text = "docx";
            this.cbDocx.UseVisualStyleBackColor = true;
            this.cbDocx.CheckedChanged += new System.EventHandler(this.cbDocx_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(364, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 28);
            this.btnSave.TabIndex = 28;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDefDestDir
            // 
            this.btnDefDestDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefDestDir.BackgroundImage")));
            this.btnDefDestDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefDestDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDefDestDir.Location = new System.Drawing.Point(311, 214);
            this.btnDefDestDir.Name = "btnDefDestDir";
            this.btnDefDestDir.Size = new System.Drawing.Size(75, 23);
            this.btnDefDestDir.TabIndex = 27;
            this.btnDefDestDir.Text = "Browse";
            this.btnDefDestDir.UseVisualStyleBackColor = true;
            this.btnDefDestDir.Click += new System.EventHandler(this.btnDefDestDir_Click);
            // 
            // tbDefDestDir
            // 
            this.tbDefDestDir.Location = new System.Drawing.Point(28, 216);
            this.tbDefDestDir.Name = "tbDefDestDir";
            this.tbDefDestDir.ReadOnly = true;
            this.tbDefDestDir.Size = new System.Drawing.Size(277, 20);
            this.tbDefDestDir.TabIndex = 26;
            // 
            // lblDefDestDir
            // 
            this.lblDefDestDir.AutoSize = true;
            this.lblDefDestDir.Location = new System.Drawing.Point(25, 200);
            this.lblDefDestDir.Name = "lblDefDestDir";
            this.lblDefDestDir.Size = new System.Drawing.Size(141, 13);
            this.lblDefDestDir.TabIndex = 25;
            this.lblDefDestDir.Text = "Default destination directory:";
            // 
            // btnDefSourceDir
            // 
            this.btnDefSourceDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefSourceDir.BackgroundImage")));
            this.btnDefSourceDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefSourceDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDefSourceDir.Location = new System.Drawing.Point(311, 159);
            this.btnDefSourceDir.Name = "btnDefSourceDir";
            this.btnDefSourceDir.Size = new System.Drawing.Size(75, 23);
            this.btnDefSourceDir.TabIndex = 24;
            this.btnDefSourceDir.Text = "Browse";
            this.btnDefSourceDir.UseVisualStyleBackColor = true;
            this.btnDefSourceDir.Click += new System.EventHandler(this.btnDefSourceDir_Click);
            // 
            // tbDefSourceDir
            // 
            this.tbDefSourceDir.Location = new System.Drawing.Point(28, 161);
            this.tbDefSourceDir.Name = "tbDefSourceDir";
            this.tbDefSourceDir.ReadOnly = true;
            this.tbDefSourceDir.Size = new System.Drawing.Size(277, 20);
            this.tbDefSourceDir.TabIndex = 23;
            // 
            // lblDefSourceDir
            // 
            this.lblDefSourceDir.AutoSize = true;
            this.lblDefSourceDir.Location = new System.Drawing.Point(25, 145);
            this.lblDefSourceDir.Name = "lblDefSourceDir";
            this.lblDefSourceDir.Size = new System.Drawing.Size(122, 13);
            this.lblDefSourceDir.TabIndex = 22;
            this.lblDefSourceDir.Text = "Default source directory:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(89, 71);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(188, 20);
            this.tbPassword.TabIndex = 21;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(89, 45);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(188, 20);
            this.tbEmail.TabIndex = 20;
            // 
            // lblEmailAndPwDescr
            // 
            this.lblEmailAndPwDescr.AutoSize = true;
            this.lblEmailAndPwDescr.Location = new System.Drawing.Point(25, 20);
            this.lblEmailAndPwDescr.Name = "lblEmailAndPwDescr";
            this.lblEmailAndPwDescr.Size = new System.Drawing.Size(140, 13);
            this.lblEmailAndPwDescr.TabIndex = 19;
            this.lblEmailAndPwDescr.Text = "Default email and password:";
            // 
            // lblDefPW
            // 
            this.lblDefPW.AutoSize = true;
            this.lblDefPW.Location = new System.Drawing.Point(25, 78);
            this.lblDefPW.Name = "lblDefPW";
            this.lblDefPW.Size = new System.Drawing.Size(53, 13);
            this.lblDefPW.TabIndex = 18;
            this.lblDefPW.Text = "Password";
            // 
            // lblDefEmail
            // 
            this.lblDefEmail.AutoSize = true;
            this.lblDefEmail.Location = new System.Drawing.Point(25, 48);
            this.lblDefEmail.Name = "lblDefEmail";
            this.lblDefEmail.Size = new System.Drawing.Size(32, 13);
            this.lblDefEmail.TabIndex = 17;
            this.lblDefEmail.Text = "Email";
            // 
            // SettingsFormIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 295);
            this.Controls.Add(this.tbAlias);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRtf);
            this.Controls.Add(this.cbDocx);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDefDestDir);
            this.Controls.Add(this.tbDefDestDir);
            this.Controls.Add(this.lblDefDestDir);
            this.Controls.Add(this.btnDefSourceDir);
            this.Controls.Add(this.tbDefSourceDir);
            this.Controls.Add(this.lblDefSourceDir);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmailAndPwDescr);
            this.Controls.Add(this.lblDefPW);
            this.Controls.Add(this.lblDefEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFormIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsFormIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbRtf;
        private System.Windows.Forms.CheckBox cbDocx;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDefDestDir;
        private System.Windows.Forms.TextBox tbDefDestDir;
        private System.Windows.Forms.Label lblDefDestDir;
        private System.Windows.Forms.Button btnDefSourceDir;
        private System.Windows.Forms.TextBox tbDefSourceDir;
        private System.Windows.Forms.Label lblDefSourceDir;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblEmailAndPwDescr;
        private System.Windows.Forms.Label lblDefPW;
        private System.Windows.Forms.Label lblDefEmail;
        private System.Windows.Forms.FolderBrowserDialog fbdDefSourceDir;
        private System.Windows.Forms.FolderBrowserDialog fbdDefDestDir;
    }
}