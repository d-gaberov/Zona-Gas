using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WFEmailSender
{
    public partial class SettingsForm : Form
    {
        public string path = "Data/Settings.xml";

        #region Old
        /*
        public bool areCredentialsConfigured = false;
        public bool isDefSourceDirConfigured = false;
        public bool isDefDestDirConfigured = false;
        */
        #endregion
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path);

            populateCredentials(doc);
            populateDefaultSourceDir(doc);
            populateDefaultDestDir(doc);
            populateDefaultFilesFormat(doc);

            #region Old logic with db
            /*
            string connectionString = getConnectionString();
            string email = "";
            string password = "";
            string defSourceDir = "";
            string defDestDir = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // credentials
                string credSelect = "SELECT * FROM [DefaultCredentials]";
                SqlCommand credCommand = new SqlCommand(credSelect, connection);
                SqlDataReader credReader = credCommand.ExecuteReader();
                if (credReader.HasRows)
                {
                    areCredentialsConfigured = true;
                    while (credReader.Read())
                    {
                        email = credReader["Email"].ToString();
                        password = credReader["Password"].ToString();
                    }
                } else
                {
                    areCredentialsConfigured = false;
                }
                credReader.Close();

                // source dir
                string sourceDirSelect = "SELECT * FROM [DefaultDir] WHERE Type = 'Source'";
                SqlCommand sourceDirCommand = new SqlCommand(sourceDirSelect, connection);
                SqlDataReader sourceDirReader = sourceDirCommand.ExecuteReader();
                if (sourceDirReader.HasRows)
                {
                    isDefSourceDirConfigured = true;
                    while (sourceDirReader.Read())
                    {
                        defSourceDir = sourceDirReader["Directory"].ToString();
                    }
                } else
                {
                    isDefSourceDirConfigured = false;
                }
                sourceDirReader.Close();

                // destination dir
                string destDirSelect = "SELECT * FROM [DefaultDir] WHERE Type = 'Destination'";
                SqlCommand destDirCommand = new SqlCommand(destDirSelect, connection);
                SqlDataReader destDirReader = destDirCommand.ExecuteReader();
                if (destDirReader.HasRows)
                {
                    isDefDestDirConfigured = true;
                    while (destDirReader.Read())
                    {
                        defDestDir = destDirReader["Directory"].ToString();
                    }
                } else
                {
                    isDefDestDirConfigured = false;
                }
                destDirReader.Close();
                connection.Close();
            }

            // set fields
            tbEmail.Text = email.Trim();
            tbPassword.Text = password.Trim();
            tbDefSourceDir.Text = defSourceDir.Trim();
            tbDefDestDir.Text = defDestDir.Trim();
            */
            #endregion
        }

        private void btnDefSourceDir_Click(object sender, EventArgs e)
        {
            if(fbdDefSourceDir.ShowDialog() == DialogResult.OK)
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

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path);

            saveCredentials(doc);
            saveDefaultSourceDir(doc);
            saveDefaultDestDir(doc);
            saveDefaultFilesFormat(doc);

            // Restart the application after saving settings so they can take effect
            Application.Restart(); 

            #region Old logic with db
            /*
            string connectionString = getConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand credentialsCommand = new SqlCommand())
                {
                    credentialsCommand.CommandText = getCredentialsSql();
                    credentialsCommand.Connection = connection;
                    credentialsCommand.ExecuteNonQuery();
                }

                using (SqlCommand sourceDirCommand = new SqlCommand())
                {
                    sourceDirCommand.CommandText = getDefaultSourceDirSql();
                    sourceDirCommand.Connection = connection;
                    sourceDirCommand.ExecuteNonQuery();
                }

                using (SqlCommand destDirCommand = new SqlCommand())
                {
                    destDirCommand.CommandText = getDefaultDestDirSql();
                    destDirCommand.Connection = connection;
                    destDirCommand.ExecuteNonQuery();
                }

                connection.Close();
            }

            this.Close();
            */
            #endregion
        }

        private void saveCredentials(XDocument doc)
        {
            var email =     tbEmail.Text;
            var password =  tbPassword.Text;
            var alias = tbAlias.Text;

            if(alias.Length == 0 || alias == "")
            {
                alias = email;
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var b64Password = Convert.ToBase64String(plainTextBytes);

            var message = doc.Descendants("DefaultCredentials").Single(x => x.Attribute("id").Value.Equals("43e02680-4651-4ea5-a37c-c87b5761a6d6"));
            message.SetElementValue("Email", email);
            message.SetElementValue("PasswordEncoded", b64Password);
            message.SetElementValue("Alias", alias);
            doc.Save(path);
        }

        private void saveDefaultSourceDir(XDocument doc)
        {
            var type =  "Source";
            var dir =   tbDefSourceDir.Text;

            var message = doc.Descendants("DefaultDir").Single(x => x.Attribute("id").Value.Equals("2f386cf4-633b-4674-88be-d5782bf7445d"));
            message.SetElementValue("Type", type);
            message.SetElementValue("Directory", dir);
            doc.Save(path);
        }

        private void saveDefaultDestDir(XDocument doc)
        {
            var type =  "Destination";
            var dir =   tbDefDestDir.Text;

            var message = doc.Descendants("DefaultDir").Single(x => x.Attribute("id").Value.Equals("ce832671-f6a8-46fa-ae08-ff3be59fef8f"));
            message.SetElementValue("Type", type);
            message.SetElementValue("Directory", dir);
            doc.Save(path);
        }

        private void saveDefaultFilesFormat(XDocument doc)
        {
            string format;
            if(cbRtf.Checked == true)
            {
                format = "rtf";
            }
            else
            {
                format = "docx";
            }

            var formatQ = doc.Descendants("DefaultFilesFormat").Single(x => x.Attribute("id").Value.Equals("868b49e0-b64a-40c7-9965-12fc0db7e2fe"));
            formatQ.SetElementValue("Format", format);
            doc.Save(path);
        }

        private void populateCredentials(XDocument doc)
        {
            var emailQ =        from x in doc.Root.Descendants("DefaultCredentials")
                                where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
                                select x.Element("Email").Value;

            var passQ =         from x in doc.Root.Descendants("DefaultCredentials")
                                where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
                                select x.Element("PasswordEncoded").Value;

            var aliasQ =         from x in doc.Root.Descendants("DefaultCredentials")
                                where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
                                select x.Element("Alias").Value;

            tbEmail.Text =      emailQ.FirstOrDefault();
            tbAlias.Text =      aliasQ.FirstOrDefault();

            var b64 = Convert.FromBase64String(passQ.FirstOrDefault());
            var password = System.Text.Encoding.UTF8.GetString(b64);
            tbPassword.Text = password;
        }

        private void populateDefaultSourceDir(XDocument doc)
        {
            var dirQ =              from x in doc.Root.Descendants("DefaultDir")
                                    where (string)x.Attribute("id") == "2f386cf4-633b-4674-88be-d5782bf7445d"
                                    select x.Element("Directory").Value;

            tbDefSourceDir.Text =   dirQ.FirstOrDefault();
        }

        private void populateDefaultDestDir(XDocument doc)
        {
            var dirQ =          from x in doc.Root.Descendants("DefaultDir")
                                where (string)x.Attribute("id") == "ce832671-f6a8-46fa-ae08-ff3be59fef8f"
                                select x.Element("Directory").Value;

            tbDefDestDir.Text = dirQ.FirstOrDefault();
        }

        private void populateDefaultFilesFormat(XDocument doc)
        {
            var formatQ = from x in doc.Root.Descendants("DefaultFilesFormat")
                        where (string)x.Attribute("id") == "868b49e0-b64a-40c7-9965-12fc0db7e2fe"
                        select x.Element("Format").Value;

            if(formatQ.FirstOrDefault() == "rtf")
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

        #region Old logic with db
        /*
        private string getCredentialsSql()
        {
            string id = Guid.NewGuid().ToString();
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            if(areCredentialsConfigured)
            {
                return String.Format("UPDATE [DefaultCredentials] SET Email = '{0}', Password = '{1}'", email, password);
            }
            else
            {
                return String.Format("INSERT INTO [DefaultCredentials] (Id, Email, Password) values('{0}', '{1}', '{2}')", id, email, password);
            }
        }

        private string getDefaultSourceDirSql()
        {
            string id = Guid.NewGuid().ToString();
            string dir = tbDefSourceDir.Text;
            string type = "Source";
            if (isDefSourceDirConfigured)
            {
                return String.Format("UPDATE [DefaultDir] SET Directory = '{0}' WHERE Type = '{1}'", dir, type);
            } 
            else
            {
                return String.Format("INSERT INTO [DefaultDir] (Id, Directory, Type) values('{0}', '{1}', '{2}')", id, dir, type);
            }
        }

        private string getDefaultDestDirSql()
        {
            string id = Guid.NewGuid().ToString();
            string dir = tbDefDestDir.Text;
            string type = "Destination";
            if (isDefDestDirConfigured)
            {
                return String.Format("UPDATE [DefaultDir] SET Directory = '{0}' WHERE Type = '{1}'", dir, type);
            }
            else
            {
                return String.Format("INSERT INTO [DefaultDir] (Id, Directory, Type) values('{0}', '{1}', '{2}')", id, dir, type);
            }
        }

        private string getConnectionString() 
        { 
            return ConfigurationManager.ConnectionStrings["WFEmailSender.Properties.Settings.WFdbConnectionString"].ConnectionString;
        }
        */
        #endregion
    }
}
