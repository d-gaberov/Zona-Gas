using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WFEmailSender.InstantPot
{
    public partial class SettingsFormIP : Form
    {
        public string path = "Data/Settings.xml";
        public SettingsFormIP()
        {
            InitializeComponent();
        }

        private void SettingsFormIP_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path);

            populateCredentials(doc);
            populateDefaultSourceDir(doc);
            populateDefaultDestDir(doc);
            populateDefaultFilesFormat(doc);
            populateServerSettings(doc);

        }

        private void btnDefSourceDir_Click(object sender, EventArgs e)
        {
            if (fbdDefSourceDir.ShowDialog() == DialogResult.OK)
            {
                tbDefSourceDir.Text = fbdDefSourceDir.SelectedPath;
            }
        }

        private void btnDefDestDir_Click(object sender, EventArgs e)
        {
            if (fbdDefDestDir.ShowDialog() == DialogResult.OK)
            {
                tbDefDestDir.Text = fbdDefDestDir.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path);

            saveCredentials(doc);
            saveDefaultSourceDir(doc);
            saveDefaultDestDir(doc);
            saveDefaultFilesFormat(doc);
            saveServerSettings(doc);

            // Restart the application after saving settings so they can take effect
            //Application.Restart();
            MainFormIP mForm = new MainFormIP();
            this.Hide();
            mForm.ShowDialog();
            this.Close();

        }

        private void saveCredentials(XDocument doc)
        {
            var email = tbEmail.Text;
            var password = tbPassword.Text;
            var alias = tbAlias.Text;

            if (alias.Length == 0 || alias == "")
            {
                alias = email;
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var b64Password = Convert.ToBase64String(plainTextBytes);

            var message = doc.Descendants("DefaultCredentialsIP").Single(x => x.Attribute("id").Value.Equals("a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"));
            message.SetElementValue("Email", email);
            message.SetElementValue("PasswordEncoded", b64Password);
            message.SetElementValue("Alias", alias);
            doc.Save(path);
        }

        private void saveDefaultSourceDir(XDocument doc)
        {
            var type = "Source";
            var dir = tbDefSourceDir.Text;

            var message = doc.Descendants("DefaultDirIP").Single(x => x.Attribute("id").Value.Equals("c696fe9c-95c0-44b2-a1a1-c586499e5187"));
            message.SetElementValue("Type", type);
            message.SetElementValue("Directory", dir);
            doc.Save(path);
        }

        private void saveDefaultDestDir(XDocument doc)
        {
            var type = "Destination";
            var dir = tbDefDestDir.Text;

            var message = doc.Descendants("DefaultDirIP").Single(x => x.Attribute("id").Value.Equals("35476b9b-dd2d-4c40-941d-b83136d32708"));
            message.SetElementValue("Type", type);
            message.SetElementValue("Directory", dir);
            doc.Save(path);
        }

        private void saveDefaultFilesFormat(XDocument doc)
        {
            string format;
            if (cbRtf.Checked == true)
            {
                format = "rtf";
            }
            else
            {
                format = "docx";
            }

            var formatQ = doc.Descendants("DefaultFilesFormatIP").Single(x => x.Attribute("id").Value.Equals("22be157c-78be-4c59-8cfe-121c464df22c"));
            formatQ.SetElementValue("Format", format);
            doc.Save(path);
        }

        private void saveServerSettings(XDocument doc)
        {
            var smtp = tbSmtp.Text;
            var port = tbPort.Text;
            var isHtml = cbIsHtml.Checked;
            var enableSsl = cbEnableSsl.Checked;

            var tag = doc.Descendants("EmailSettingsIP").Single(x => x.Attribute("id").Value.Equals("153c197d-ef77-4b7d-94b8-ec3738e4661c"));
            tag.SetElementValue("SmtpServer", smtp);
            tag.SetElementValue("Port", port);
            tag.SetElementValue("IsBodyHtml", isHtml);
            tag.SetElementValue("EnableSsl", enableSsl);
            doc.Save(path);
        }

        private void populateServerSettings(XDocument doc)
        {
            var smtpQ = from x in doc.Root.Descendants("EmailSettingsIP")
                        where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                        select x.Element("SmtpServer").Value;

            var portQ = from x in doc.Root.Descendants("EmailSettingsIP")
                        where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                        select x.Element("Port").Value;

            var isHtmlQ = from x in doc.Root.Descendants("EmailSettingsIP")
                          where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                          select x.Element("IsBodyHtml").Value;

            var enableSslQ = from x in doc.Root.Descendants("EmailSettingsIP")
                             where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                             select x.Element("EnableSsl").Value;

            tbSmtp.Text = smtpQ.FirstOrDefault();
            tbPort.Text = portQ.FirstOrDefault();

            if (isHtmlQ.FirstOrDefault() == "true")
            {
                cbIsHtml.Checked = true;
            }
            else
            {
                cbIsHtml.Checked = false;
            }

            if (enableSslQ.FirstOrDefault() == "true")
            {
                cbEnableSsl.Checked = true;
            }
            else
            {
                cbEnableSsl.Checked = false;
            }
        }

        private void populateCredentials(XDocument doc)
        {
            var emailQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                         where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                         select x.Element("Email").Value;

            var passQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                        where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                        select x.Element("PasswordEncoded").Value;

            var aliasQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                         where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                         select x.Element("Alias").Value;

            tbEmail.Text = emailQ.FirstOrDefault();
            tbAlias.Text = aliasQ.FirstOrDefault();

            var b64 = Convert.FromBase64String(passQ.FirstOrDefault());
            var password = System.Text.Encoding.UTF8.GetString(b64);
            tbPassword.Text = password;
        }

        private void populateDefaultSourceDir(XDocument doc)
        {
            var dirQ = from x in doc.Root.Descendants("DefaultDirIP")
                       where (string)x.Attribute("id") == "c696fe9c-95c0-44b2-a1a1-c586499e5187"
                       select x.Element("Directory").Value;

            tbDefSourceDir.Text = dirQ.FirstOrDefault();
        }

        private void populateDefaultDestDir(XDocument doc)
        {
            var dirQ = from x in doc.Root.Descendants("DefaultDirIP")
                       where (string)x.Attribute("id") == "35476b9b-dd2d-4c40-941d-b83136d32708"
                       select x.Element("Directory").Value;

            tbDefDestDir.Text = dirQ.FirstOrDefault();
        }

        private void populateDefaultFilesFormat(XDocument doc)
        {
            var formatQ = from x in doc.Root.Descendants("DefaultFilesFormatIP")
                          where (string)x.Attribute("id") == "22be157c-78be-4c59-8cfe-121c464df22c"
                          select x.Element("Format").Value;

            if (formatQ.FirstOrDefault() == "rtf")
            {
                cbRtf.Checked = true;
                cbDocx.Checked = false;
            }
            else
            {
                cbDocx.Checked = true;
                cbRtf.Checked = false;
            }
        }

        private void cbDocx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDocx.Checked == true)
            {
                cbRtf.Checked = false;
            }
            else
            {
                cbRtf.Checked = true;
            }
        }

        private void cbRtf_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRtf.Checked == true)
            {
                cbDocx.Checked = false;
            }
            else
            {
                cbDocx.Checked = true;
            }
        }
    }
}
