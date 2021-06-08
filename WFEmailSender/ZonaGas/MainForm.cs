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
using WFEmailSender.InstantPot;

namespace WFEmailSender
{
    public partial class MainForm : Form
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
        public string msgWrongDocType = "Property subject must contain one of the following types: Invoice, Фактура, Certificate, Сертификат, Report, Справка. File {0} will not be sent!";
        public string msgSourceDirDeleted = "Previously selected source directory is deleted! Could not load files!";
        public string msgDestDirDeleted = "Previously selected destination directory is deleted! Could not load files!";
        public string msgNoAlias = "Alias is empty! If you click ok, the email recipients will see the actual email sender!";
        public string msgSwitchToInstantPot = "Switch to Instant Pot?";
        public string msgEmptyEmail = "Property Tags must contain atleast one email. File {0} will not be sent!";

        // helper variables
        public List<string> docFileNames = new List<string>();
        private List<DocumentProperties> allDocumentsProperties = new List<DocumentProperties>();

        public string xmlPath = "Data/Settings.xml";
        public string signatureTemplatePath = "Data/SignatureTemplate.html";

        public string defSourceDir = "";
        public string defDestDir = "";
        public string defEmail = "";
        public string defPassword = "";
        public string defAlias = "";

        public string sourceFilesFormat = "";

        // email strings
        public string bannerDir = "";
        public string bannerLink = "";

        public string invoiceSubject = "";
        public string invoiceBody = "";
        public string invoiceWaybill = "";
        public string invoiceFooter = "";

        public string certificateSubject = "";
        public string certificateBody = "";
        public string certificateWaybill = "";
        public string certificateFooter = "";

        public string reportSubject = "";
        public string reportBody = "";
        public string reportWaybill = "";
        public string reportFooter = "";

        public string signatureHtml = "";

        // email settings
        public string smtpServer = "";
        public int port = 0;
        public bool isBodyHtml = false;
        public bool useDefaultCredentials = false;
        public bool enableSsl = false;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region Events
        private void mainForm_Load(object sender, EventArgs e)
        {
            getSourceFilesFormat();
            tbSourceDir.ReadOnly = true;
            tbDestDir.ReadOnly = true;
            cbDefSourceDir.Checked = true;
            cbDefDestDir.Checked = true;
            cbDefaultUserPW.Checked = true;
            cbDelFiles.Checked = true;
        }

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
            if(fbdSelectDestDir.ShowDialog() == DialogResult.OK)
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
                var dirQ = from x in doc.Root.Descendants("DefaultDir")
                           where (string)x.Attribute("id") == "2f386cf4-633b-4674-88be-d5782bf7445d"
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
                    } catch (Exception)
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
                var dirQ = from x in doc.Root.Descendants("DefaultDir")
                           where (string)x.Attribute("id") == "ce832671-f6a8-46fa-ae08-ff3be59fef8f"
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
                    } catch (Exception)
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
                var emailQ = from x in doc.Root.Descendants("DefaultCredentials")
                             where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
                             select x.Element("Email").Value;

                var passQ = from x in doc.Root.Descendants("DefaultCredentials")
                            where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
                            select x.Element("PasswordEncoded").Value;

                var aliasQ = from x in doc.Root.Descendants("DefaultCredentials")
                             where (string)x.Attribute("id") == "43e02680-4651-4ea5-a37c-c87b5761a6d6"
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

                if(defAlias.Trim().Length > 0)
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
            SettingsForm form = new SettingsForm();
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
                if(result == DialogResult.Cancel)
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

            // get email subjects, bodies, waybills and footers from the database:
            //lblStatus.Text = "Collecting document properties...";
            getBannerStrings();
            getInvoiceEmailStrings();
            getCertificateEmailStrings();
            getReportEmailStrings();
            getEmailSettings();
            getSignatureHtml();

            progressBar1.PerformStep();
            progressBar1.Refresh();
            // send emails:
            //lblStatus.Text = "Sending emails...";

            var wrongSubjectTypeFilesList = new List<String>();

            if (allDocumentsProperties.Count > 0)
            {
                for(int i = 0; i < allDocumentsProperties.Count; i++)
                {
                    if(allDocumentsProperties[i].DocumentType.ToUpper() == "INVOICE" || allDocumentsProperties[i].DocumentType.ToUpper() == "ФАКТУРА")
                    {
                        var emails = allDocumentsProperties[i].Emails.Split(';');
                        for(var j = 0; j < emails.Length; j++)
                        {
                            if(emails[j] != "")
                            {
                                var emailTo = emails[j].Trim();
                                sendEmails(allDocumentsProperties[i], emailTo, invoiceSubject, invoiceBody, invoiceWaybill, invoiceFooter, bannerDir, bannerLink);
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
                    else if (allDocumentsProperties[i].DocumentType.ToUpper() == "CERTIFICATE" || allDocumentsProperties[i].DocumentType.ToUpper() == "СЕРТИФИКАТ")
                    {
                        var emails = allDocumentsProperties[i].Emails.Split(';');
                        for (var k = 0; k < emails.Length; k++)
                        {
                            if (emails[k] != "")
                            {
                                var emailTo = emails[k].Trim();
                                sendEmails(allDocumentsProperties[i], emailTo, certificateSubject, certificateBody, certificateWaybill, certificateFooter, bannerDir, bannerLink);
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
                    else if (allDocumentsProperties[i].DocumentType.ToUpper() == "REPORT" || allDocumentsProperties[i].DocumentType.ToUpper() == "СПРАВКА")
                    {
                        var emails = allDocumentsProperties[i].Emails.Split(';');
                        for (var l = 0; l < emails.Length; l++)
                        {
                            if (emails[i] != "")
                            {
                                var emailTo = emails[l].Trim();
                                sendEmails(allDocumentsProperties[i], emailTo, reportSubject, reportBody, reportWaybill, reportFooter, bannerDir, bannerLink);
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

                if(errMsg != "" && errMsg.Length > 0)
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

            if(wrongSubjectTypeFilesList.Count > 0)
            {
                this.Close();
            }
            else if (lblStatus.Text == "No document properties found.")
            {
                MessageBox.Show("No document properties found.", caption, buttons);
                this.Close();
            } else
            {
                MessageBox.Show(msgSendCompleted, captionSuccess, buttons);
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the instant pot form as well...
            MainFormIP ipForm = new MainFormIP();
            ipForm.Close();
            Environment.Exit(1); // exit the application
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(msgSwitchToInstantPot, captionWarning, MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                MainFormIP ipForm = new MainFormIP();
                this.Hide();
                ipForm.ShowDialog();
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
            } catch (Exception err)
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

                    var pdfDestinationName = properties.DocumentNo + " - " + properties.DocumentType + " - " + "ZonaGas.pdf";
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
                        if (item.ToString() == "ListViewItem: {" + pdfDestinationName + "}") {
                            itemFound = true;
                            break;
                        }
                    }

                    if (pdfDestinationName.Contains(".pdf") && !itemFound) {
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
        private DocumentProperties getProperties(Document doc)
        {
            object _BuiltInProperties = doc.BuiltInDocumentProperties;
            Type typeDocBuiltInProps = _BuiltInProperties.GetType();

            string docNo;
            string docType;
            string emails;
            string waybill;

            try
            {
                // Document no prop
                Object DocNoProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Title" });
                Type typeDocNoProp = DocNoProp.GetType();
                docNo = typeDocNoProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, DocNoProp, new object[] { }).ToString();
            } catch (Exception err)
            {
                docNo = "";
            }

            try
            {
                // Document type prop
                Object DocTypeProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Subject" });
                Type typeDocTypeProp = DocTypeProp.GetType();
                docType = typeDocTypeProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, DocTypeProp, new object[] { }).ToString();
            } catch (Exception err)
            {
                docType = "";
            }

            try
            {
                // Emails prop
                Object EmailsProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Keywords" });
                Type typeEmailsProp = EmailsProp.GetType();
                emails = typeEmailsProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, EmailsProp, new object[] { }).ToString();
            } catch (Exception err)
            {
                emails = "";
            }

            try
            {
                // Waybill prop
                Object WaybillProp = typeDocBuiltInProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, _BuiltInProperties, new object[] { "Comments" });
                Type typeWaybillProp = WaybillProp.GetType();
                waybill = typeWaybillProp.InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, WaybillProp, new object[] { }).ToString();
            } catch (Exception err)
            {
                waybill = "";
            }

            DocumentProperties properties = new DocumentProperties(docNo, docType, emails, waybill);
            return properties;
        }

        ////////////////////////////////////////////////////// delete files ///////////////////////////////////////////////////////////
        private bool deleteFiles() {

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

            } catch (Exception err)
            {
                lblStatus.Text = err.Message;
                return false;
            }
        }

        ////////////////////////////////////////////////////// get banner strings /////////////////////////////////////////////////////
        public void getBannerStrings()
        {
            XDocument doc = XDocument.Load(xmlPath);
            var directoryQ = from x in doc.Root.Descendants("BannerInfo")
                             where (string)x.Attribute("id") == "375ac8d3-3fe9-4031-b0d4-118125764793"
                             select x.Element("Directory").Value;

            var linkQ = from x in doc.Root.Descendants("BannerInfo")
                        where (string)x.Attribute("id") == "375ac8d3-3fe9-4031-b0d4-118125764793"
                        select x.Element("Link").Value;

            bannerDir = directoryQ.FirstOrDefault();
            bannerLink = linkQ.FirstOrDefault();

            #region Old logic with db
            /*
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // banner
                string bannerSelect = "SELECT * FROM [Banner]";
                SqlCommand bannerCommand = new SqlCommand(bannerSelect, connection);
                SqlDataReader bannerReader = bannerCommand.ExecuteReader();

                if (bannerReader.HasRows)
                {
                    while (bannerReader.Read())
                    {
                        bannerDir = bannerReader["Directory"].ToString();
                        bannerLink = bannerReader["Link"].ToString();
                    }
                }

                bannerReader.Close();
                connection.Close();
            }
            */
            #endregion
        }

        ////////////////////////////////////////////////////// get invoice email strings //////////////////////////////////////////////
        public void getInvoiceEmailStrings()
        {
            XDocument doc = XDocument.Load(xmlPath);
            var subjectQ = from x in doc.Root.Descendants("InvoiceEmailMessage")
                           where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                           select x.Element("Subject").Value;

            var bodyQ = from x in doc.Root.Descendants("InvoiceEmailMessage")
                        where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                        select x.Element("Body").Value;

            var waybillQ = from x in doc.Root.Descendants("InvoiceEmailMessage")
                           where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                           select x.Element("Waybill").Value;

            var footerQ = from x in doc.Root.Descendants("InvoiceEmailMessage")
                          where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                          select x.Element("Footer").Value;

            invoiceSubject = subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            invoiceBody = bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            invoiceWaybill = waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            invoiceFooter = footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);

            #region Old logic with db
            /*
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string invoiceSelect = "SELECT * FROM [InvoiceEmailMessage]";
                SqlCommand invoiceCommand = new SqlCommand(invoiceSelect, connection);
                SqlDataReader invoiceReader = invoiceCommand.ExecuteReader();
                if (invoiceReader.HasRows)
                {
                    while (invoiceReader.Read())
                    {
                        invoiceSubject = invoiceReader["Subject"].ToString();
                        invoiceBody = invoiceReader["Message"].ToString();
                        invoiceWaybill = invoiceReader["Waybill"].ToString();
                        invoiceFooter = invoiceReader["Footer"].ToString();
                    }
                }

                invoiceReader.Close();
                connection.Close();
            }
            */
            #endregion
        }

        ////////////////////////////////////////////////////// get certificate email strings //////////////////////////////////////////
        public void getCertificateEmailStrings()
        {
            XDocument doc = XDocument.Load(xmlPath);
            var subjectQ = from x in doc.Root.Descendants("CertificateEmailMessage")
                           where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                           select x.Element("Subject").Value;

            var bodyQ = from x in doc.Root.Descendants("CertificateEmailMessage")
                        where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                        select x.Element("Body").Value;

            var waybillQ = from x in doc.Root.Descendants("CertificateEmailMessage")
                           where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                           select x.Element("Waybill").Value;

            var footerQ = from x in doc.Root.Descendants("CertificateEmailMessage")
                          where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                          select x.Element("Footer").Value;

            certificateSubject = subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            certificateBody = bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            certificateWaybill = waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            certificateFooter = footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);

            #region Old logic with db
            /*
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string certificateSelect = "SELECT * FROM [CertificateEmailMessage]";
                SqlCommand certificateCommand = new SqlCommand(certificateSelect, connection);
                SqlDataReader certificateReader = certificateCommand.ExecuteReader();
                if (certificateReader.HasRows)
                {
                    while (certificateReader.Read())
                    {
                        certificateSubject = certificateReader["Subject"].ToString();
                        certificateBody = certificateReader["Message"].ToString();
                        certificateWaybill = certificateReader["Waybill"].ToString();
                        certificateFooter = certificateReader["Footer"].ToString();
                    }
                }

                certificateReader.Close();
                connection.Close();
            }
            */
            #endregion
        }

        public void getReportEmailStrings()
        {
            XDocument doc = XDocument.Load(xmlPath);
            var subjectQ = from x in doc.Root.Descendants("ReportEmailMessage")
                           where (string)x.Attribute("id") == "9b4f85ef-c267-42be-a03b-5ffc8b67c0a0"
                           select x.Element("Subject").Value;

            var bodyQ = from x in doc.Root.Descendants("ReportEmailMessage")
                        where (string)x.Attribute("id") == "9b4f85ef-c267-42be-a03b-5ffc8b67c0a0"
                        select x.Element("Body").Value;

            var waybillQ = from x in doc.Root.Descendants("ReportEmailMessage")
                           where (string)x.Attribute("id") == "9b4f85ef-c267-42be-a03b-5ffc8b67c0a0"
                           select x.Element("Waybill").Value;

            var footerQ = from x in doc.Root.Descendants("ReportEmailMessage")
                          where (string)x.Attribute("id") == "9b4f85ef-c267-42be-a03b-5ffc8b67c0a0"
                          select x.Element("Footer").Value;

            reportSubject = subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            reportBody = bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            reportWaybill = waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            reportFooter = footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);

            #region Old logic with db
            /*
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string certificateSelect = "SELECT * FROM [CertificateEmailMessage]";
                SqlCommand certificateCommand = new SqlCommand(certificateSelect, connection);
                SqlDataReader certificateReader = certificateCommand.ExecuteReader();
                if (certificateReader.HasRows)
                {
                    while (certificateReader.Read())
                    {
                        certificateSubject = certificateReader["Subject"].ToString();
                        certificateBody = certificateReader["Message"].ToString();
                        certificateWaybill = certificateReader["Waybill"].ToString();
                        certificateFooter = certificateReader["Footer"].ToString();
                    }
                }

                certificateReader.Close();
                connection.Close();
            }
            */
            #endregion
        }

        public void getEmailSettings()
        {
            XDocument doc = XDocument.Load(xmlPath);

            var smtpServerQ =               from x in doc.Root.Descendants("EmailSettings")
                                            where (string)x.Attribute("id") == "742ea7be-7593-44a3-b554-ca339296510a"
                                            select x.Element("SmtpServer").Value;

            var portQ =                     from x in doc.Root.Descendants("EmailSettings")
                                            where (string)x.Attribute("id") == "742ea7be-7593-44a3-b554-ca339296510a"
                                            select x.Element("Port").Value;

            var isBodyHtmlQ =               from x in doc.Root.Descendants("EmailSettings")
                                            where (string)x.Attribute("id") == "742ea7be-7593-44a3-b554-ca339296510a"
                                            select x.Element("IsBodyHtml").Value;

            var useDefaultCredentialsQ =    from x in doc.Root.Descendants("EmailSettings")
                                            where (string)x.Attribute("id") == "742ea7be-7593-44a3-b554-ca339296510a"
                                            select x.Element("UseDefaultCredentials").Value;

            var enableSslQ =                from x in doc.Root.Descendants("EmailSettings")
                                            where (string)x.Attribute("id") == "742ea7be-7593-44a3-b554-ca339296510a"
                                            select x.Element("EnableSsl").Value;

            smtpServer =                    smtpServerQ.FirstOrDefault();
            port =                          int.Parse(portQ.FirstOrDefault());
            isBodyHtml =                    (isBodyHtmlQ.FirstOrDefault() == "true" ? true : false);
            useDefaultCredentials =         (useDefaultCredentialsQ.FirstOrDefault() == "true" ? true : false);
            enableSsl =                     (enableSslQ.FirstOrDefault() == "true" ? true : false);
        }

        public void getSignatureHtml()
        {
            string signHtml = File.ReadAllText(signatureTemplatePath);
            signatureHtml = signHtml;
        }

        public void getSourceFilesFormat()
        {
            XDocument doc = XDocument.Load(xmlPath);

            var formatQ = from x in doc.Root.Descendants("DefaultFilesFormat")
                          where (string)x.Attribute("id") == "868b49e0-b64a-40c7-9965-12fc0db7e2fe"
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

    ////////////////////////////////////////////////////// send emails ////////////////////////////////////////////////////////////
    private void sendEmails(DocumentProperties properties, string emailTo, string subject, string body, string waybill, string footer, string bannerDir, string bannerLink)
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
                mail.Subject = subject + " " + properties.DocumentNo;

                string emailBody = "<html>";
                emailBody += "<body'>";
                var parsedBody = body.Replace(Environment.NewLine, "<br>");
                emailBody += "<label>" + parsedBody + "</label><br>";

                if (properties.Waybill.Length > 0 && Regex.IsMatch(properties.Waybill, @"^\d+$"))
                {
                    emailBody += "<label>Пратката си може да проследите на <a href='https://speedy.bg/bg/track-shipment?shipmentNumber'>този линк</a><label> с номер на товарителница: " + properties.Waybill + "</label></label><br><br>";
                }

                var parsedFooter = footer.Replace(Environment.NewLine, "<br>");
                emailBody += "<label>" + parsedFooter + "</label>";

                /*
                // signature
                emailBody += @"<div style='width:25em; font-size: 1em;'>
		                                    <br>
		                                    <br>
		                                    <label>Поздрави,</label>
		                                    <br>
		                                    <br>
		                                    <label style='font-weight: bold;'>Екипът на Зона Газ</label>
		                                    <br><hr>
		                                    <label>тел:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+359 (2) 955 53 84</label><br>
		                                    <label>моб:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+359 878 67 60 36</label><br>
		                                    <label>моб:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+359 878 66 09 25</label><br>
		                                    <label>адрес:&nbsp;&nbsp;&nbsp;&nbsp;София, бул. Братя Бъкстон №40</label><br>
		                                    <label>web:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='http://www.zonagas.bg/'>www.ZonaGas.bg</a></label><br>
		                                    <label>web:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='http://madas.bg/'>www.Madas.bg</a></label><br>
		                                    <label>e-mail:&nbsp;&nbsp;&nbsp;<a href='https://mail.google.com/mail/u/1/#inbox/FMfcgxwGCHCfTBQjRjGVhPtmDdLqwDvd?compose=new'>office@zonagas.bg</a></label><br>
		                                    <img src='cid:zonaGasImgId' width='282' height='69'/>
		                                    <div style='margin-top: -0.5em;'>
			                                    <a href='https://www.facebook.com/ZonaGas.bg/'><img src='cid:fbImgId'/></a>&nbsp;
			                                    <a href='https://www.youtube.com/channel/UCEvb_Dpsg6gVBHTIIAvtVew'><img src='cid:ytImgId'/></a>&nbsp;
			                                    <a href='https://plus.google.com/+ZonaGasBgOnline'><img src='cid:gpImgId'/></a>&nbsp;
			                                    <a href='https://facebook.us14.list-manage.com/subscribe?u=f70ba3c71f72b9eb69cc7a460&id=0df4c4dbce'><img src='cid:nlImgId'/></a>&nbsp;
		                                    </div>
                                        </div>";
                                        */

                emailBody += signatureHtml;

                if (bannerDir.Length > 0 && bannerLink.Length > 0) {
                    emailBody += String.Format("<a href='{0}'><img src='cid:bannerImgId'/></a>&nbsp;", bannerLink);
                }

                //emailBody += "</div>";
                emailBody += "</body>";
                emailBody += "</html>";


                // av html body
                AlternateView av = AlternateView.CreateAlternateViewFromString(emailBody, null, MediaTypeNames.Text.Html);
                // av pics
                LinkedResource zonaGasPic = new LinkedResource("Resources/zonaGasImg.jpg", MediaTypeNames.Image.Jpeg);
                LinkedResource fbPic = new LinkedResource("Resources/facebookPic.jpg", MediaTypeNames.Image.Jpeg);
                LinkedResource ytPic = new LinkedResource("Resources/youtubePic.jpg", MediaTypeNames.Image.Jpeg);
                LinkedResource gpPic = new LinkedResource("Resources/googlePlusPic.jpg", MediaTypeNames.Image.Jpeg);
                LinkedResource nlPic = new LinkedResource("Resources/newsLetterPic.jpg", MediaTypeNames.Image.Jpeg);

                zonaGasPic.ContentId = "zonaGasImgId";
                fbPic.ContentId = "fbImgId";
                ytPic.ContentId = "ytImgId";
                gpPic.ContentId = "gpImgId";
                nlPic.ContentId = "nlImgId";

                av.LinkedResources.Add(zonaGasPic);
                av.LinkedResources.Add(fbPic);
                av.LinkedResources.Add(ytPic);
                av.LinkedResources.Add(gpPic);
                av.LinkedResources.Add(nlPic);

                // add advertisement banner if configured
                if (bannerDir.Length > 0 && bannerLink.Length > 0)
                {
                    LinkedResource banner = new LinkedResource(bannerDir, MediaTypeNames.Image.Jpeg);
                    banner.ContentId = "bannerImgId";
                    av.LinkedResources.Add(banner);
                }

                mail.AlternateViews.Add(av);
                mail.Body = emailBody;
                mail.IsBodyHtml = isBodyHtml;

                Attachment attachment = new Attachment(properties.DocFileDir);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = port;
                SmtpServer.EnableSsl = enableSsl;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = useDefaultCredentials;
                SmtpServer.Credentials = new System.Net.NetworkCredential(userEmail, userPw);

                SmtpServer.Send(mail);

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
