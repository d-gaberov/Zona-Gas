namespace WFEmailSender
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblDefEmail = new System.Windows.Forms.Label();
            this.lblDefPW = new System.Windows.Forms.Label();
            this.lblEmailAndPwDescr = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblDefSourceDir = new System.Windows.Forms.Label();
            this.fbdDefSourceDir = new System.Windows.Forms.FolderBrowserDialog();
            this.tbDefSourceDir = new System.Windows.Forms.TextBox();
            this.btnDefSourceDir = new System.Windows.Forms.Button();
            this.btnDefDestDir = new System.Windows.Forms.Button();
            this.tbDefDestDir = new System.Windows.Forms.TextBox();
            this.lblDefDestDir = new System.Windows.Forms.Label();
            this.fbdDefDestDir = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDocx = new System.Windows.Forms.CheckBox();
            this.cbRtf = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbSmtp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsHtml = new System.Windows.Forms.CheckBox();
            this.cbEnableSsl = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDefEmail
            // 
            this.lblDefEmail.AutoSize = true;
            this.lblDefEmail.Location = new System.Drawing.Point(26, 49);
            this.lblDefEmail.Name = "lblDefEmail";
            this.lblDefEmail.Size = new System.Drawing.Size(32, 13);
            this.lblDefEmail.TabIndex = 0;
            this.lblDefEmail.Text = "Email";
            // 
            // lblDefPW
            // 
            this.lblDefPW.AutoSize = true;
            this.lblDefPW.Location = new System.Drawing.Point(26, 79);
            this.lblDefPW.Name = "lblDefPW";
            this.lblDefPW.Size = new System.Drawing.Size(53, 13);
            this.lblDefPW.TabIndex = 1;
            this.lblDefPW.Text = "Password";
            // 
            // lblEmailAndPwDescr
            // 
            this.lblEmailAndPwDescr.AutoSize = true;
            this.lblEmailAndPwDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAndPwDescr.Location = new System.Drawing.Point(26, 21);
            this.lblEmailAndPwDescr.Name = "lblEmailAndPwDescr";
            this.lblEmailAndPwDescr.Size = new System.Drawing.Size(167, 13);
            this.lblEmailAndPwDescr.TabIndex = 2;
            this.lblEmailAndPwDescr.Text = "Default email and password:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(90, 46);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(188, 20);
            this.tbEmail.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(90, 72);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(188, 20);
            this.tbPassword.TabIndex = 4;
            // 
            // lblDefSourceDir
            // 
            this.lblDefSourceDir.AutoSize = true;
            this.lblDefSourceDir.Location = new System.Drawing.Point(26, 146);
            this.lblDefSourceDir.Name = "lblDefSourceDir";
            this.lblDefSourceDir.Size = new System.Drawing.Size(122, 13);
            this.lblDefSourceDir.TabIndex = 5;
            this.lblDefSourceDir.Text = "Default source directory:";
            // 
            // tbDefSourceDir
            // 
            this.tbDefSourceDir.Location = new System.Drawing.Point(29, 162);
            this.tbDefSourceDir.Name = "tbDefSourceDir";
            this.tbDefSourceDir.ReadOnly = true;
            this.tbDefSourceDir.Size = new System.Drawing.Size(277, 20);
            this.tbDefSourceDir.TabIndex = 6;
            // 
            // btnDefSourceDir
            // 
            this.btnDefSourceDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefSourceDir.BackgroundImage")));
            this.btnDefSourceDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefSourceDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDefSourceDir.Location = new System.Drawing.Point(312, 160);
            this.btnDefSourceDir.Name = "btnDefSourceDir";
            this.btnDefSourceDir.Size = new System.Drawing.Size(75, 23);
            this.btnDefSourceDir.TabIndex = 7;
            this.btnDefSourceDir.Text = "Browse";
            this.btnDefSourceDir.UseVisualStyleBackColor = true;
            this.btnDefSourceDir.Click += new System.EventHandler(this.btnDefSourceDir_Click);
            // 
            // btnDefDestDir
            // 
            this.btnDefDestDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefDestDir.BackgroundImage")));
            this.btnDefDestDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefDestDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDefDestDir.Location = new System.Drawing.Point(312, 215);
            this.btnDefDestDir.Name = "btnDefDestDir";
            this.btnDefDestDir.Size = new System.Drawing.Size(75, 23);
            this.btnDefDestDir.TabIndex = 10;
            this.btnDefDestDir.Text = "Browse";
            this.btnDefDestDir.UseVisualStyleBackColor = true;
            this.btnDefDestDir.Click += new System.EventHandler(this.btnDefDestDir_Click);
            // 
            // tbDefDestDir
            // 
            this.tbDefDestDir.Location = new System.Drawing.Point(29, 217);
            this.tbDefDestDir.Name = "tbDefDestDir";
            this.tbDefDestDir.ReadOnly = true;
            this.tbDefDestDir.Size = new System.Drawing.Size(277, 20);
            this.tbDefDestDir.TabIndex = 9;
            // 
            // lblDefDestDir
            // 
            this.lblDefDestDir.AutoSize = true;
            this.lblDefDestDir.Location = new System.Drawing.Point(26, 201);
            this.lblDefDestDir.Name = "lblDefDestDir";
            this.lblDefDestDir.Size = new System.Drawing.Size(141, 13);
            this.lblDefDestDir.TabIndex = 8;
            this.lblDefDestDir.Text = "Default destination directory:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(333, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDocx
            // 
            this.cbDocx.AutoSize = true;
            this.cbDocx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDocx.Location = new System.Drawing.Point(331, 49);
            this.cbDocx.Name = "cbDocx";
            this.cbDocx.Size = new System.Drawing.Size(49, 17);
            this.cbDocx.TabIndex = 12;
            this.cbDocx.Text = "docx";
            this.cbDocx.UseVisualStyleBackColor = true;
            this.cbDocx.CheckedChanged += new System.EventHandler(this.cbDocx_CheckedChanged);
            // 
            // cbRtf
            // 
            this.cbRtf.AutoSize = true;
            this.cbRtf.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRtf.Location = new System.Drawing.Point(333, 75);
            this.cbRtf.Name = "cbRtf";
            this.cbRtf.Size = new System.Drawing.Size(47, 17);
            this.cbRtf.TabIndex = 13;
            this.cbRtf.Text = "rtf    ";
            this.cbRtf.UseVisualStyleBackColor = true;
            this.cbRtf.CheckedChanged += new System.EventHandler(this.cbRtf_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Source files format:";
            // 
            // tbAlias
            // 
            this.tbAlias.Location = new System.Drawing.Point(90, 98);
            this.tbAlias.Name = "tbAlias";
            this.tbAlias.Size = new System.Drawing.Size(188, 20);
            this.tbAlias.TabIndex = 16;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(26, 105);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 15;
            this.lblAlias.Text = "Alias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Server settings";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(118, 344);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(87, 20);
            this.tbPort.TabIndex = 21;
            // 
            // tbSmtp
            // 
            this.tbSmtp.Location = new System.Drawing.Point(118, 318);
            this.tbSmtp.Name = "tbSmtp";
            this.tbSmtp.Size = new System.Drawing.Size(188, 20);
            this.tbSmtp.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Smtp Server";
            // 
            // cbIsHtml
            // 
            this.cbIsHtml.AutoSize = true;
            this.cbIsHtml.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.cbIsHtml.Location = new System.Drawing.Point(26, 376);
            this.cbIsHtml.Name = "cbIsHtml";
            this.cbIsHtml.Size = new System.Drawing.Size(106, 17);
            this.cbIsHtml.TabIndex = 22;
            this.cbIsHtml.Text = "Is Html                ";
            this.cbIsHtml.UseVisualStyleBackColor = true;
            // 
            // cbEnableSsl
            // 
            this.cbEnableSsl.AutoSize = true;
            this.cbEnableSsl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbEnableSsl.Location = new System.Drawing.Point(26, 399);
            this.cbEnableSsl.Name = "cbEnableSsl";
            this.cbEnableSsl.Size = new System.Drawing.Size(106, 17);
            this.cbEnableSsl.TabIndex = 24;
            this.cbEnableSsl.Text = "Enable Ssl          ";
            this.cbEnableSsl.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 460);
            this.Controls.Add(this.cbEnableSsl);
            this.Controls.Add(this.cbIsHtml);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbSmtp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
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
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDefEmail;
        private System.Windows.Forms.Label lblDefPW;
        private System.Windows.Forms.Label lblEmailAndPwDescr;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblDefSourceDir;
        private System.Windows.Forms.FolderBrowserDialog fbdDefSourceDir;
        private System.Windows.Forms.TextBox tbDefSourceDir;
        private System.Windows.Forms.Button btnDefSourceDir;
        private System.Windows.Forms.Button btnDefDestDir;
        private System.Windows.Forms.TextBox tbDefDestDir;
        private System.Windows.Forms.Label lblDefDestDir;
        private System.Windows.Forms.FolderBrowserDialog fbdDefDestDir;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbDocx;
        private System.Windows.Forms.CheckBox cbRtf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbSmtp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbIsHtml;
        private System.Windows.Forms.CheckBox cbEnableSsl;
    }
}