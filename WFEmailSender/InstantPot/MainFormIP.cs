using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;

namespace WFEmailSender.InstantPot
{
    public partial class MainFormIP : Form
    {

        #region helper vars
        // error messages
        public string caption = "Error";
        public string captionWarning = "Warning";
        public string captionSuccess = "Success";
        public string msgNoSourceDirSelected = "Source folder is not selected! Please configure default source path in the settings or click the browse button.";
        public string msgNoDestDirSelected = "Destination folder is not selected! Please configure default destination path in the settings or click the browse button.";
        public string msgNoEmail = "Please enter email!";
        public string msgNoPassword = "Please enter password!";
        public string msgSendCompleted = "Email sending completed!";
        public string msgWrongDocType = "Property subject must contain one of the following types: Invoice, Фактура, Bill of Goods, Стокова Разписка. File {0} will not be sent!";
        public string msgSourceDirDeleted = "Previously selected source directory is deleted! Could not load files!";
        public string msgDestDirDeleted = "Previously selected destination directory is deleted! Could not load files!";
        public string msgNoAlias = "Alias is empty! If you click ok, the email recipients will see the actual email sender!";
        public string msgSwitchToZonaGas = "Switch to Zona Gas?";
        public string msgEmptyEmail = "Property Tags must contain atleast one email. File {0} will not be sent!";

        // html templates
        public string accessoariesTemplatePath = "Data/instantPotAccessoariesTemplate.html";
        public string instantPotTemplatePath = "Data/InstantPotTrackingTemplate.html";
        public string airFryerTemplatePath = "Data/AirFryerTrackingTemplate.html";
        public string airPurifierTemplatePath = "Data/AirPurifierTrackingTemplate.html";
        public string sparePartsTemplatePath = "Data/SparePartsTrackingTemplate.html";

        // helper variables
        public List<string> docFileNames = new List<string>();
        private List<DocumentPropertiesIP> allDocumentsProperties = new List<DocumentPropertiesIP>();

        public string xmlPath = "Data/Settings.xml";

        public string logPath = "Data/log.txt";

        public string mainSubject = "Документи от Instant Bulgaria към поръчка";

        public string defSourceDir = "";
        public string defDestDir = "";
        public string defEmail = "";
        public string defPassword = "";
        public string defAlias = "";

        public string sourceFilesFormat = "";

        // html locations
        string accessoariesTrackingDiv = "id='accessoariesTrackingDiv'";
        string accessoariesTrackingNumber = "accessoariesTrackingNumber";

        string tbiTrackingDiv = "id='tbiTrackingDiv'";
        string tbiTrackingNumber = "tbiTrackingNumber";

        string instantPotTrackingDiv = "id='instantPotTrackingDiv'";
        string instantPotTrackingNumber = "instantPotTrackingNumber";

        // email settings
        public string smtpServer = "";
        public int port = 0;
        public bool isBodyHtml = false;
        public bool useDefaultCredentials = false;
        public bool enableSsl = false;

        //fiscal receipt
        public string fiscalReceiptPartialName = "Касов бон номер ";
        public string fiscalReceiptFileFormat = ".pdf";
        #endregion

        public MainFormIP()
        {
            InitializeComponent();
        }

        private void MainFormIP_Load(object sender, EventArgs e)
        {
            getSourceFilesFormat();
            tbSourceDir.ReadOnly = true;
            tbDestDir.ReadOnly = true;
            cbDefSourceDir.Checked = true;
            cbDefDestDir.Checked = true;
            cbDefaultUserPW.Checked = true;
            cbDelFiles.Checked = true;
        }

        #region Events

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (fbdSelectSourceDir.ShowDialog() == DialogResult.OK)
            {
                tbSourceDir.Text = fbdSelectSourceDir.SelectedPath;

                var files = Directory.GetFiles(tbSourceDir.Text, sourceFilesFormat);
                foreach (string file in files)
                {
                    lvFilesDoc.Items.Add(Path.GetFileName(file) + Environment.NewLine);
                    lblDocFilesCount.Text = lvFilesDoc.Items.Count.ToString();
                }
            }
        }

        private void btnBrowseDestFolder_Click(object sender, EventArgs e)
        {
            if (fbdSelectDestDir.ShowDialog() == DialogResult.OK)
            {
                tbDestDir.Text = fbdSelectDestDir.SelectedPath;

                var files = Directory.GetFiles(tbDestDir.Text, "*.pdf");
                foreach (string file in files)
                {
                    lvFilesPdf.Items.Add(Path.GetFileName(file) + Environment.NewLine);
                    //lblPdfFilesCount.Text = lvFilesPdf.Items.Count.ToString();
                }
            }
        }

        private void cbDefSourceDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDefSourceDir.Checked)
            {
                lvFilesDoc.Items.Clear();
                lblDocFilesCount.Text = "";
                btnBrowseSourceFolder.Enabled = false;

                XDocument doc = XDocument.Load(xmlPath);
                var dirQ = from x in doc.Root.Descendants("DefaultDirIP")
                           where (string)x.Attribute("id") == "c696fe9c-95c0-44b2-a1a1-c586499e5187"
                           select x.Element("Directory").Value;

                defSourceDir = dirQ.FirstOrDefault();

                if (defSourceDir.Trim().Length > 0)
                {
                    tbSourceDir.Text = defSourceDir.Trim();

                    try
                    {
                        var files = Directory.GetFiles(tbSourceDir.Text, sourceFilesFormat);
                        foreach (string file in files)
                        {
                            lvFilesDoc.Items.Add(Path.GetFileName(file) + Environment.NewLine);
                            lblDocFilesCount.Text = lvFilesDoc.Items.Count.ToString();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(msgSourceDirDeleted, caption, MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    tbSourceDir.Text = "No default source directory configured!";
                }

            }
            else
            {
                btnBrowseSourceFolder.Enabled = true;
                tbSourceDir.Text = "";

                lvFilesDoc.Items.Clear();
                lblDocFilesCount.Text = "";
            }

            #region Old logic with db
            /*
            if (cbDefSourceDir.Checked)
            {
                lvFilesDoc.Items.Clear();
                lblDocFilesCount.Text = "";
                btnBrowseSourceFolder.Enabled = false;

                string connectionString = getConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sourceDirSelect = "SELECT * FROM [DefaultDir] WHERE Type = 'Source'";
                    SqlCommand sourceDirCommand = new SqlCommand(sourceDirSelect, connection);
                    SqlDataReader sourceDirReader = sourceDirCommand.ExecuteReader();
                    if (sourceDirReader.HasRows)
                    {
                        while (sourceDirReader.Read())
                        {
                            defSourceDir = sourceDirReader["Directory"].ToString();
                        }
                    }
                    sourceDirReader.Close();
                    connection.Close();
                }

                if (defSourceDir.Trim().Length > 0) 
                {
                    tbSourceDir.Text = defSourceDir.Trim();

                    var files = Directory.GetFiles(tbSourceDir.Text, "*.docx");
                    foreach (string file in files)
                    {
                        lvFilesDoc.Items.Add(Path.GetFileName(file));
                        lblDocFilesCount.Text = lvFilesDoc.Items.Count.ToString();
                    }
                } 
                else
                {
                    tbSourceDir.Text = "No default source directory configured!";
                }

            } 
            else
            {
                btnBrowseSourceFolder.Enabled = true;
                tbSourceDir.Text = "";

                lvFilesDoc.Items.Clear();
                lblDocFilesCount.Text = "";
            }
            */
            #endregion
        }

        private void cbDefDestDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDefDestDir.Checked)
            {
                lvFilesPdf.Items.Clear();
                lblPdfFilesCount.Text = "";
                btnBrowseDestFolder.Enabled = false;

                XDocument doc = XDocument.Load(xmlPath);
                var dirQ = from x in doc.Root.Descendants("DefaultDirIP")
                           where (string)x.Attribute("id") == "35476b9b-dd2d-4c40-941d-b83136d32708"
                           select x.Element("Directory").Value;

                defDestDir = dirQ.FirstOrDefault();

                if (defDestDir.Trim().Length > 0)
                {
                    tbDestDir.Text = defDestDir.Trim();

                    try
                    {
                        var files = Directory.GetFiles(tbDestDir.Text, "*.pdf");
                        foreach (string file in files)
                        {
                            lvFilesPdf.Items.Add(Path.GetFileName(file) + Environment.NewLine);
                            //lblPdfFilesCount.Text = lvFilesPdf.Items.Count.ToString();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(msgDestDirDeleted, caption, MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    tbDestDir.Text = "No default destination directory configured!";
                }

            }
            else
            {
                btnBrowseDestFolder.Enabled = true;
                tbDestDir.Text = "";

                lvFilesPdf.Items.Clear();
                lblPdfFilesCount.Text = "";
            }

            #region Old logic with db
            /*
            if (cbDefDestDir.Checked)
            {
                lvFilesPdf.Items.Clear();
                lblPdfFilesCount.Text = "";
                btnBrowseDestFolder.Enabled = false;

                string connectionString = getConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string destDirSelect = "SELECT * FROM [DefaultDir] WHERE Type = 'Destination'";
                    SqlCommand destDirCommand = new SqlCommand(destDirSelect, connection);
                    SqlDataReader destDirReader = destDirCommand.ExecuteReader();
                    if (destDirReader.HasRows)
                    {
                        while (destDirReader.Read())
                        {
                            defDestDir = destDirReader["Directory"].ToString();
                        }
                    }
                    destDirReader.Close();
                    connection.Close();
                }

                if (defDestDir.Trim().Length > 0)
                {
                    tbDestDir.Text = defDestDir.Trim(); ;

                    var files = Directory.GetFiles(tbDestDir.Text, "*.pdf");
                    foreach (string file in files)
                    {
                        lvFilesPdf.Items.Add(Path.GetFileName(file));
                        //lblPdfFilesCount.Text = lvFilesPdf.Items.Count.ToString();
                    }
                } 
                else
                {
                    tbDestDir.Text = "No default destination directory configured!";
                }

            } else
            {
                btnBrowseDestFolder.Enabled = true;
                tbDestDir.Text = "";

                lvFilesPdf.Items.Clear();
                lblPdfFilesCount.Text = "";
            }
            */
            #endregion
        }

        private void cbDefaultEmailPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDefaultUserPW.Checked)
            {
                tbEmail.Enabled = false;
                tbPassword.Enabled = false;
                tbAlias.Enabled = false;

                XDocument doc = XDocument.Load(xmlPath);
                var emailQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                             where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                             select x.Element("Email").Value;

                var passQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                            where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                            select x.Element("PasswordEncoded").Value;

                var aliasQ = from x in doc.Root.Descendants("DefaultCredentialsIP")
                             where (string)x.Attribute("id") == "a3e9f4b4-eff6-47ae-ac6e-bfaf814668bc"
                             select x.Element("Alias").Value;

                defEmail = emailQ.FirstOrDefault();
                defAlias = aliasQ.FirstOrDefault();

                var b64 = Convert.FromBase64String(passQ.FirstOrDefault());
                var defPassword = System.Text.Encoding.UTF8.GetString(b64);

                if (defEmail.Trim().Length > 0)
                {
                    tbEmail.Text = defEmail.Trim();
                }
                else
                {
                    tbEmail.Text = "Not configured!";
                }

                if (defPassword.Trim().Length > 0)
                {
                    tbPassword.Text = defPassword.Trim();
                }
                else
                {
                    tbPassword.Text = "";
                }

                if (defAlias.Trim().Length > 0)
                {
                    tbAlias.Text = defAlias.Trim();
                }
                else
                {
                    tbAlias.Text = defEmail.Trim();
                }

            }
            else
            {
                tbEmail.Text = "";
                tbPassword.Text = "";
                tbAlias.Text = "";
                tbEmail.Enabled = true;
                tbPassword.Enabled = true;
                tbAlias.Enabled = true;
            }

            #region Old logic with db
            /*
            if (cbDefaultUserPW.Checked)
            {
                string connectionString = getConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string credSelect = "SELECT * FROM [DefaultCredentials]";
                    SqlCommand credCommand = new SqlCommand(credSelect, connection);
                    SqlDataReader credReader = credCommand.ExecuteReader();

                    if (credReader.HasRows)
                    {
                        while (credReader.Read())
                        {
                            defEmail = credReader["Email"].ToString();
                            defPassword = credReader["Password"].ToString();
                        }
                    }
                    credReader.Close();
                    connection.Close();
                }

                if(defEmail.Trim().Length > 0)
                {
                    tbEmail.Text = defEmail.Trim();
                }
                else
                {
                    tbEmail.Text = "Not configured!";
                }

                if(defPassword.Trim().Length > 0)
                {
                    tbPassword.Text = defPassword.Trim();
                }
                else
                {
                    tbPassword.Text = "";
                }

            } else
            {
                tbEmail.Text = "";
                tbPassword.Text = "";
            }
            */
            #endregion
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsFormIP form = new SettingsFormIP();
            form.Show();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailSettingsForm form = new EmailSettingsForm();
            form.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm();
            form.Show();
        }

        private void btnSendEmails_Click(object sender, EventArgs e)
        {
            // validate user input...
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            if (!isValid(tbSourceDir.Text))
            {
                MessageBox.Show(msgNoSourceDirSelected, caption, buttons);
                return;
            }

            if (!isValid(tbDestDir.Text))
            {
                MessageBox.Show(msgNoDestDirSelected, caption, buttons);
                return;
            }

            if (!isValid(tbEmail.Text))
            {
                MessageBox.Show(msgNoEmail, caption, buttons);
                return;
            }

            if (!isValid(tbPassword.Text))
            {
                MessageBox.Show(msgNoPassword, caption, buttons);
                return;
            }

            if (!isValid(tbAlias.Text))
            {
                DialogResult result = MessageBox.Show(msgNoAlias, captionWarning, MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            progressBar1.Maximum = lvFilesDoc.Items.Count + 2; // easy formule... :D
            progressBar1.Step = 1;

            // convert files: (wile converting files we fill the list of properties for all documents)
            lblStatus.Text = "Processing...";
            lblPdfFilesCount.Text = "0";
            var conversionStatus = convertFiles();
            if (conversionStatus)
            {
                //lblStatus.Text = "Convertion completed.";
            }
            else
            {
                return;
            }

            progressBar1.PerformStep();
            progressBar1.Refresh();

            // delete docx files from the source dir:
            if (cbDelFiles.Checked == true)
            {
                //lblStatus.Text = "Deleting docx files from the source folder...";
                var deleteStatus = deleteFiles();
                if (deleteStatus)
                {
                    //lblStatus.Text = "Docx files deleted.";
                }
                else
                {
                    return;
                }
            }

            progressBar1.PerformStep();
            progressBar1.Refresh();

            getEmailSettings();

            progressBar1.PerformStep();
            progressBar1.Refresh();
            // send emails:
            //lblStatus.Text = "Sending emails...";

            var wrongSubjectTypeFilesList = new List<String>();

             if (allDocumentsProperties.Count > 0)
            {
                for (int i = 0; i < allDocumentsProperties.Count; i++)
                {
                    if (allDocumentsProperties[i].DocumentType.ToUpper() == "INVOICE" || allDocumentsProperties[i].DocumentType.ToUpper() == "ФАКТУРА")
                    {
                        var emails = allDocumentsProperties[i].Emails.Split(';');
                        for (var j = 0; j < emails.Length; j++)
                        {
                            if(emails[j] != "")
                            {
                                var emailTo = emails[j].Trim();
                                sendEmails(allDocumentsProperties[i], emailTo);
                                progressBar1.PerformStep();
                                progressBar1.Refresh();
                            } 
                            else
                            {
                                msgEmptyEmail = String.Format(msgEmptyEmail, allDocumentsProperties[i].DocFileDir);
                                wrongSubjectTypeFilesList.Add(msgEmptyEmail);
                            }

                        }

                    }
                    else if (allDocumentsProperties[i].DocumentType.ToUpper() == "BILL OF GOODS" || allDocumentsProperties[i].DocumentType.ToUpper() == "СТОКОВА РАЗПИСКА")
                    {
                        var emails = allDocumentsProperties[i].Emails.Split(';');
                        for (var k = 0; k < emails.Length; k++)
                        {
                            if(emails[k] != "")
                            {
                                var emailTo = emails[k].Trim();
                                sendEmails(allDocumentsProperties[i], emailTo);
                                progressBar1.PerformStep();
                                progressBar1.Refresh();
                            } 
                            else
                            {
                                msgEmptyEmail = String.Format(msgEmptyEmail, allDocumentsProperties[i].DocFileDir);
                                wrongSubjectTypeFilesList.Add(msgEmptyEmail);
                            }

                        }
                    }
                    else
                    {
                        msgWrongDocType = String.Format(msgWrongDocType, allDocumentsProperties[i].DocFileDir);
                        wrongSubjectTypeFilesList.Add(msgWrongDocType);
                        progressBar1.PerformStep();
                        progressBar1.Refresh();
                        continue;
                    }
                }

                lblStatus.Text = "Completed.";
                progressBar1.Refresh();

                var errMsg = "";
                foreach (var name in wrongSubjectTypeFilesList)
                {
                    errMsg += name + Environment.NewLine + Environment.NewLine;
                }

                if (errMsg != "" && errMsg.Length > 0)
                    MessageBox.Show(errMsg, caption, buttons);
            }
            else
            {
                lblStatus.Text = "No document properties found.";
                progressBar1.Refresh();
            }

            // clear document properties and file names lists

            allDocumentsProperties.Clear();
            docFileNames.Clear();

            if (wrongSubjectTypeFilesList.Count > 0)
            {
                this.Close();
            }
            else if (lblStatus.Text == "No document properties found.")
            {
                MessageBox.Show("No document properties found.", caption, buttons);
                this.Close();
            }
            else
            {
                MessageBox.Show(msgSendCompleted, captionSuccess, buttons);
                this.Close();
            }
        }

        private void MainFormIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the 'real' main form as well...
            MainForm mForm = new MainForm();
            mForm.Close();
            Environment.Exit(1); // exit the application
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(msgSwitchToZonaGas, captionWarning, MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MainForm mForm = new MainForm();
                this.Hide();
                mForm.ShowDialog();
                this.Close();
            }
        }
        #endregion

        #region Core functionality
        // validate user input.
        private bool isValid(string input)
        {
            if (input == null || input.Length == 0 || input == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region Old
        /*
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["WFEmailSender.Properties.Settings.WFdbConnectionString"].ConnectionString;
        }
        */
        #endregion

        ////////////////////////////////////////////////////// convert files ///////////////////////////////////////////////////////////
        private bool convertFiles()
        {
            object missing = System.Reflection.Missing.Value;
            object falseVal = false;

            try
            {
                var files = Directory.GetFiles(tbSourceDir.Text, sourceFilesFormat);
                foreach (string file in files)
                {
                    docFileNames.Add(Path.GetFileName(file));
                }
            }
            catch (Exception err)
            {
                lblStatus.Text = err.Message;
            }

            Application app = new Application();

            try
            {
                foreach (var file in docFileNames)
                {
                    var sourceFilePath = tbSourceDir.Text + "\\" + file;
                    var sourcePathCasted = (Object)sourceFilePath;
                    Document doc = app.Documents.Open(ref sourcePathCasted, ref missing,
                            ref falseVal, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing);

                    doc.Activate();

                    var destinationName = file.Replace(sourceFilesFormat, ".pdf");
                    var destinationPath = tbDestDir.Text + "\\" + destinationName;

                    // get document properties
                    var properties = getProperties(doc);

                    var pdfDestinationName = properties.DocumentNo + " - " + properties.DocumentType + " - " + "InstantPot.pdf";
                    var pdfDestinationPath = tbDestDir.Text + "\\" + pdfDestinationName;

                    properties.DocFileDir = pdfDestinationPath;
                    allDocumentsProperties.Add(properties);

                    var destinationPathCasted = (Object)pdfDestinationPath;
                    doc.AcceptAllRevisions();
                    doc.SaveAs(destinationPathCasted, WdSaveFormat.wdFormatPDF,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing);

                    object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                    ((_Document)doc).Close(ref saveChanges, ref missing, ref missing);

                    var itemFound = false;
                    foreach (var item in lvFilesPdf.Items)
                    {
                        if (item.ToString() == "ListViewItem: {" + pdfDestinationName + "}")
                        {
                            itemFound = true;
                            break;
                        }
                    }

                    if (pdfDestinationName.Contains(".pdf") && !itemFound)
                    {
                        lvFilesPdf.Items.Add(pdfDestinationName + Environment.NewLine);
                        var count = int.Parse(lblPdfFilesCount.Text);
                        count++;
                        lblPdfFilesCount.Text = count.ToString();
                        //lblPdfFilesCount.Text = lvFilesPdf.Items.Count.ToString();
                    }
                }

                ((_Application)app).Quit(ref missing, ref missing, ref missing);
                return true;
            }
            catch (Exception err)
            {
                // word application MUST be closed if error is thrown!!!
                ((_Application)app).Quit(ref missing, ref missing, ref missing);
                lblStatus.Text = err.Message;
                return false;
            }
        }

        ////////////////////////////////////////////////////// get doc properties //////////////////////////////////////////////////////
        private DocumentPropertiesIP getProperties(Document doc)
        {
            object _BuiltInProperties = doc.BuiltInDocumentProperties;
            Type typeDocBuiltInProps = _BuiltInProperties.GetType();

            string docNo;
            string emails;
            string billOfLading;
            string docType;
            string templateType;
            string orderNo;

            try
            {
                // Document no prop
                Object DocNoProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Title" });
                Type typeDocNoProp = DocNoProp.GetType();
                docNo = typeDocNoProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, DocNoProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                docNo = "";
            }

            try
            {
                // billOfLading prop
                Object billOfLadingProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Comments" });
                Type typeBillOfLadingProp = billOfLadingProp.GetType();
                billOfLading = typeBillOfLadingProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, billOfLadingProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                billOfLading = "";
            }

            try
            {
                // Document type prop
                Object DocTypeProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Subject" });
                Type typeDocTypeProp = DocTypeProp.GetType();
                docType = typeDocTypeProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, DocTypeProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                docType = "";
            }

            try
            {
                // templateType prop
                Object templateTypeProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Category" });
                Type typeTemplateTypeProp = templateTypeProp.GetType();
                templateType = typeTemplateTypeProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, templateTypeProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                templateType = "";
            }

            try
            {
                // orderNo prop
                Object orderNoProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Company" });
                Type typeTemplateTypeProp = orderNoProp.GetType();
                orderNo = typeTemplateTypeProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, orderNoProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                orderNo = "";
            }

            try
            {
                // Emails prop
                Object EmailsProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Keywords" });
                Type typeEmailsProp = EmailsProp.GetType();
                emails = typeEmailsProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, EmailsProp, new object[] { }).ToString();
            }
            catch (Exception err)
            {
                emails = "";
            }

            DocumentPropertiesIP properties = new DocumentPropertiesIP(docNo, emails, billOfLading, docType, templateType, orderNo);
            return properties;
        }

        ////////////////////////////////////////////////////// delete files ///////////////////////////////////////////////////////////
        private bool deleteFiles()
        {

            try
            {
                if (tbSourceDir.Text.Length > 0)
                {
                    DirectoryInfo di = new DirectoryInfo(tbSourceDir.Text);

                    foreach (FileInfo file in di.GetFiles(sourceFilesFormat))
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    lvFilesDoc.Items.Clear();
                    lblDocFilesCount.Text = "0";

                    return true;
                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(msgNoSourceDirSelected, caption, buttons);
                    return false;
                }

            }
            catch (Exception err)
            {
                lblStatus.Text = err.Message;
                return false;
            }
        }

        public void getEmailSettings()
        {
            XDocument doc = XDocument.Load(xmlPath);

            var smtpServerQ = from x in doc.Root.Descendants("EmailSettingsIP")
                              where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                              select x.Element("SmtpServer").Value;

            var portQ = from x in doc.Root.Descendants("EmailSettingsIP")
                        where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                        select x.Element("Port").Value;

            var isBodyHtmlQ = from x in doc.Root.Descendants("EmailSettingsIP")
                              where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                              select x.Element("IsBodyHtml").Value;

            var useDefaultCredentialsQ = from x in doc.Root.Descendants("EmailSettingsIP")
                                         where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                                         select x.Element("UseDefaultCredentials").Value;

            var enableSslQ = from x in doc.Root.Descendants("EmailSettingsIP")
                             where (string)x.Attribute("id") == "153c197d-ef77-4b7d-94b8-ec3738e4661c"
                             select x.Element("EnableSsl").Value;

            smtpServer = smtpServerQ.FirstOrDefault();
            port = int.Parse(portQ.FirstOrDefault());
            isBodyHtml = (isBodyHtmlQ.FirstOrDefault() == "true" ? true : false);
            useDefaultCredentials = (useDefaultCredentialsQ.FirstOrDefault() == "true" ? true : false);
            enableSsl = (enableSslQ.FirstOrDefault() == "true" ? true : false);
        }

        public void getSourceFilesFormat()
        {
            XDocument doc = XDocument.Load(xmlPath);

            var formatQ = from x in doc.Root.Descendants("DefaultFilesFormatIP")
                          where (string)x.Attribute("id") == "22be157c-78be-4c59-8cfe-121c464df22c"
                          select x.Element("Format").Value;

            if (formatQ.FirstOrDefault() == "rtf")
            {
                sourceFilesFormat = "*.rtf";
            }
            else
            {
                sourceFilesFormat = "*.docx";
            }
        }

        private string getBodyHtml(DocumentPropertiesIP properties)
        {
            string body = "";
            switch (properties.TemplateType)
            {
                case "InstantPot":
                    body = File.ReadAllText(instantPotTemplatePath);

                    if (properties.BillOfLading != null && properties.BillOfLading != "" && double.TryParse(properties.BillOfLading, out double res) == true)
                    {
                        body = body.Replace(instantPotTrackingNumber, properties.BillOfLading);
                        return body;
                    } else
                    {
                        body = body.Replace(instantPotTrackingDiv, "hidden=\"true\"");
                        body = body.Replace(instantPotTrackingNumber, "");
                        return body;
                    }

                case "Accessory":
                    body = File.ReadAllText(accessoariesTemplatePath);

                    if (properties.BillOfLading != null && properties.BillOfLading != "" && double.TryParse(properties.BillOfLading, out double res2) == true)
                    {
                        body = body.Replace(accessoariesTrackingNumber, properties.BillOfLading);
                        return body;
                    }
                    else
                    {
                        body = body.Replace(accessoariesTrackingDiv, "hidden=\"true\"");
                        body = body.Replace(accessoariesTrackingNumber, "");
                        return body;
                    }

                case "AirFryer":
                    body = File.ReadAllText(airFryerTemplatePath);

                    if (properties.BillOfLading != null && properties.BillOfLading != "" && double.TryParse(properties.BillOfLading, out double res3) == true)
                    {
                        body = body.Replace(tbiTrackingNumber, properties.BillOfLading);
                        return body;
                    }
                    else
                    {
                        body = body.Replace(tbiTrackingDiv, "hidden=\"true\"");
                        body = body.Replace(tbiTrackingNumber, "");
                        return body;
                    }

                case "AirPurifier":
                    body = File.ReadAllText(airPurifierTemplatePath);

                    if (properties.BillOfLading != null && properties.BillOfLading != "" && double.TryParse(properties.BillOfLading, out double res4) == true)
                    {
                        body = body.Replace(tbiTrackingNumber, properties.BillOfLading);
                        return body;
                    }
                    else
                    {
                        body = body.Replace(tbiTrackingDiv, "hidden=\"true\"");
                        body = body.Replace(tbiTrackingNumber, "");
                        return body;
                    }

                case "SpareParts":
                    body = File.ReadAllText(sparePartsTemplatePath);

                    if (properties.BillOfLading != null && properties.BillOfLading != "" && double.TryParse(properties.BillOfLading, out double res5) == true)
                    {
                        body = body.Replace(tbiTrackingNumber, properties.BillOfLading);
                        return body;
                    }
                    else
                    {
                        body = body.Replace(tbiTrackingDiv, "hidden=\"true\"");
                        body = body.Replace(tbiTrackingNumber, "");
                        return body;
                    }

                default:
                    return body;
            }
        }

        public string getFiscalReceiptFileDir(string name)
        {
            var fileName = tbSourceDir.Text + "\\" + fiscalReceiptPartialName + name + fiscalReceiptFileFormat;
            var exists = File.Exists(fileName);
            if (exists)
            {
                return fileName;
            } else
            {
                return null;
            }
        }


        ////////////////////////////////////////////////////// send emails ////////////////////////////////////////////////////////////
        private void sendEmails(DocumentPropertiesIP properties, string emailTo)
        {
            try
            {
                var userEmail = tbEmail.Text;
                var userPw = tbPassword.Text;
                var userAlias = tbAlias.Text;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpServer);
                mail.From = new MailAddress(userEmail, userAlias);

                mail.To.Add(emailTo);
                mail.Subject = mainSubject + " #" + properties.OrderNo;

                //get the right html and edit it accordingly
                mail.Body = getBodyHtml(properties);
                mail.IsBodyHtml = isBodyHtml;

                Attachment attachment = new Attachment(properties.DocFileDir);
                mail.Attachments.Add(attachment);

                //try to attach fiscal receipt
                var fiscalReceiptFileName = getFiscalReceiptFileDir(properties.DocumentNo);
                if(fiscalReceiptFileName != null)
                {
                    Attachment fiscalReceipt = new Attachment(fiscalReceiptFileName);
                    mail.Attachments.Add(fiscalReceipt);
                }

                SmtpServer.Port = port;
                SmtpServer.EnableSsl = enableSsl;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = useDefaultCredentials;
                SmtpServer.Credentials = new System.Net.NetworkCredential(userEmail, userPw);
                SmtpServer.Send(mail);

                /*
                using (StreamWriter writer = File.CreateText(logPath))
                {
                    writer.WriteLine("userMail: " + userEmail);
                    writer.WriteLine("userAlias: " + userAlias);
                    writer.WriteLine("emailTo: " + emailTo);
                    writer.WriteLine("subject: " + mail.Subject);
                    writer.WriteLine("body: " + mail.Body);
                }
                */

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, caption, MessageBoxButtons.OK);
                lblStatus.Text = err.Message.Split('.')[0];
                return;
            }
        }
        #endregion
    }
}
