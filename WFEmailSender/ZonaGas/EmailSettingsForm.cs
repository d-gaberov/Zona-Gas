using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Linq;

namespace WFEmailSender
{
    public partial class EmailSettingsForm : Form
    {
        public string path = "Data/Settings.xml";

        #region Old
        /*
        public bool isInvoiceConfigured = false;
        public bool isCertificateConfigured = false;
        public bool isBannerConfigured = false;
        */
        #endregion

        public EmailSettingsForm()
        {
            InitializeComponent();
        }

        private void EmailSettingsForm_Load(object sender, EventArgs e)
        {
            tbBannerDirectory.ReadOnly = true;

            XDocument doc = XDocument.Load(path);

            populateBannerTab(doc);
            populateInvoiceTab(doc);
            populateCertificateTab(doc);
            populateReportTab(doc);

            #region Old logic with db
            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // banner
                string bannerSelect = "SELECT * FROM [Banner]";
                SqlCommand bannerCommand = new SqlCommand(bannerSelect, connection);
                SqlDataReader bannerReader = bannerCommand.ExecuteReader();

                if (bannerReader.HasRows)
                {
                    isBannerConfigured = true;
                    while (bannerReader.Read())
                    {
                        bannerDir = bannerReader["Directory"].ToString();
                        bannerLink = bannerReader["Link"].ToString();
                    }
                } else
                {
                    isBannerConfigured = false;
                }
                bannerReader.Close();

                // invoice
                string invoiceSelect = "SELECT * FROM [InvoiceEmailMessage]";
                SqlCommand invoiceCommand = new SqlCommand(invoiceSelect, connection);
                SqlDataReader invoiceReader = invoiceCommand.ExecuteReader();
                if (invoiceReader.HasRows)
                {
                    isInvoiceConfigured = true;
                    while (invoiceReader.Read())
                    {
                        invoiceSubject = invoiceReader["Subject"].ToString();
                        invoiceBody = invoiceReader["Message"].ToString();
                        invoiceWaybill = invoiceReader["Waybill"].ToString();
                        invoiceFooter = invoiceReader["Footer"].ToString();
                    }
                } else
                {
                    isInvoiceConfigured = false;
                }
                invoiceReader.Close();

                // certificate
                string certificateSelect = "SELECT * FROM [CertificateEmailMessage]";
                SqlCommand certificateCommand = new SqlCommand(certificateSelect, connection);
                SqlDataReader certificateReader = certificateCommand.ExecuteReader();
                if (certificateReader.HasRows)
                {
                    isCertificateConfigured = true;
                    while (certificateReader.Read())
                    {
                        certificateSubject = certificateReader["Subject"].ToString();
                        certificateBody = certificateReader["Message"].ToString();
                        certificateWaybill = certificateReader["Waybill"].ToString();
                        certificateFooter = certificateReader["Footer"].ToString();
                    }
                } else
                {
                    isCertificateConfigured = false;
                }
                certificateReader.Close();
                connection.Close();

                // set fields
                tbBannerDirectory.Text = bannerDir.Trim();
                if (tbBannerDirectory.Text.Length > 0)
                {
                    try
                    {
                        pbBanner.Image = Image.FromFile(tbBannerDirectory.Text);
                    } catch (Exception err)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show("Banner image was deleted or moved to another directory. Consider selecting the file's new directory or select a new image!", "Error", buttons);
                    }
                }
                tbAdLink.Text = bannerLink.Trim();
                tbInvoiceSubject.Text = invoiceSubject.Trim();
                tbInvoiceBody.Text = invoiceBody.Trim();
                tbInvoiceWaybill.Text = invoiceWaybill.Trim();
                tbInvoiceFooter.Text = invoiceFooter.Trim();
                tbCertSubject.Text = certificateSubject.Trim();
                tbCertBody.Text = certificateBody.Trim();
                tbCertWaybill.Text = certificateWaybill.Trim();
                tbCertFooter.Text = certificateFooter.Trim();
            }
            */
            #endregion
        }

        private void btnChangeBanner_Click(object sender, EventArgs e)
        {
            if(ofdBannerDir.ShowDialog() == DialogResult.OK)
            {
                tbBannerDirectory.Text = ofdBannerDir.FileName;
                pbBanner.Image = Image.FromFile(tbBannerDirectory.Text);
            }
        }

        private void btnSaveEmailSettings_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path);

            saveInvoiceSettings(doc);
            saveCertificateSettings(doc);
            saveReportSettings(doc);
            saveBannerSettings(doc);

            this.Close();

            #region Old logic with db
            /*
            string connectionString = getConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand invoiceCommand = new SqlCommand())
                {
                    invoiceCommand.CommandText = getInvoiceSql();
                    invoiceCommand.Connection = connection;
                    invoiceCommand.ExecuteNonQuery();
                }

                using (SqlCommand certificateCommand = new SqlCommand())
                {
                    certificateCommand.CommandText = getCertificateSql();
                    certificateCommand.Connection = connection;
                    certificateCommand.ExecuteNonQuery();
                }

                using (SqlCommand bannerCommand = new SqlCommand())
                {
                    bannerCommand.CommandText = getBannerSql();
                    bannerCommand.Connection = connection;
                    bannerCommand.ExecuteNonQuery();
                }

                connection.Close();
            }

            this.Close();
            */
            #endregion
        }

        private void saveBannerSettings(XDocument doc)
        {
            var dir =   tbBannerDirectory.Text;
            var link =  tbAdLink.Text;

            var message = doc.Descendants("BannerInfo").Single(x => x.Attribute("id").Value.Equals("375ac8d3-3fe9-4031-b0d4-118125764793"));
            message.SetElementValue("Directory", dir);
            message.SetElementValue("Link", link);
            doc.Save(path);
        }

        private void saveInvoiceSettings(XDocument doc)
        {
            var subject =   tbInvoiceSubject.Text;
            var body =      tbInvoiceBody.Text;
            var waybill =   tbInvoiceWaybill.Text;
            var footer =    tbInvoiceFooter.Text;

            var message = doc.Descendants("InvoiceEmailMessage").Single(x => x.Attribute("id").Value.Equals("a75faaf2-1897-4490-a2d1-0345d78893a7"));
            message.SetElementValue("Subject", subject);
            message.SetElementValue("Body", body);
            message.SetElementValue("Waybill", waybill);
            message.SetElementValue("Footer", footer);
            doc.Save(path);
        }

        private void saveCertificateSettings(XDocument doc)
        {
            var subject =   tbCertSubject.Text;
            var body =      tbCertBody.Text;
            var waybill =   tbCertWaybill.Text;
            var footer =    tbCertFooter.Text;

            var message = doc.Descendants("CertificateEmailMessage").Single(x => x.Attribute("id").Value.Equals("c600e731-ade6-46b7-8989-d2055cc74909"));
            message.SetElementValue("Subject", subject);
            message.SetElementValue("Body", body);
            message.SetElementValue("Waybill", waybill);
            message.SetElementValue("Footer", footer);
            doc.Save(path);
        }

        private void saveReportSettings(XDocument doc)
        {
            var subject = tbReportSubject.Text;
            var body = tbReportBody.Text;
            var waybill = tbReportWaybill.Text;
            var footer = tbReportFooter.Text;

            var message = doc.Descendants("ReportEmailMessage").Single(x => x.Attribute("id").Value.Equals("9b4f85ef-c267-42be-a03b-5ffc8b67c0a0"));
            message.SetElementValue("Subject", subject);
            message.SetElementValue("Body", body);
            message.SetElementValue("Waybill", waybill);
            message.SetElementValue("Footer", footer);
            doc.Save(path);
        }

        private void populateInvoiceTab(XDocument doc)
        {
            var subjectQ =      from x in doc.Root.Descendants("InvoiceEmailMessage")
                                where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                                select x.Element("Subject").Value;

            var bodyQ =         from x in doc.Root.Descendants("InvoiceEmailMessage")
                                where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                                select x.Element("Body").Value;

            var waybillQ =      from x in doc.Root.Descendants("InvoiceEmailMessage")
                                where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                                select x.Element("Waybill").Value;

            var footerQ =       from x in doc.Root.Descendants("InvoiceEmailMessage")
                                where (string)x.Attribute("id") == "a75faaf2-1897-4490-a2d1-0345d78893a7"
                                select x.Element("Footer").Value;

            tbInvoiceSubject.Text =     subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbInvoiceBody.Text =        bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbInvoiceWaybill.Text =     waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbInvoiceFooter.Text =      footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);
        }

        private void populateCertificateTab(XDocument doc)
        {
            var subjectQ =  from x in doc.Root.Descendants("CertificateEmailMessage")
                            where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                            select x.Element("Subject").Value;

            var bodyQ =     from x in doc.Root.Descendants("CertificateEmailMessage")
                            where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                            select x.Element("Body").Value;

            var waybillQ =  from x in doc.Root.Descendants("CertificateEmailMessage")
                            where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                            select x.Element("Waybill").Value;

            var footerQ =   from x in doc.Root.Descendants("CertificateEmailMessage")
                            where (string)x.Attribute("id") == "c600e731-ade6-46b7-8989-d2055cc74909"
                            select x.Element("Footer").Value;

            tbCertSubject.Text =    subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbCertBody.Text =       bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbCertWaybill.Text =    waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbCertFooter.Text =     footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);
        }

        private void populateReportTab(XDocument doc)
        {
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

            tbReportSubject.Text = subjectQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbReportBody.Text = bodyQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbReportWaybill.Text = waybillQ.FirstOrDefault().Replace("\n", Environment.NewLine);
            tbReportFooter.Text = footerQ.FirstOrDefault().Replace("\n", Environment.NewLine);
        }

        private void populateBannerTab(XDocument doc)
        {
            var directoryQ =    from x in doc.Root.Descendants("BannerInfo")
                                where (string)x.Attribute("id") == "375ac8d3-3fe9-4031-b0d4-118125764793"
                                select x.Element("Directory").Value;

            var linkQ =         from x in doc.Root.Descendants("BannerInfo")
                                where (string)x.Attribute("id") == "375ac8d3-3fe9-4031-b0d4-118125764793"
                                select x.Element("Link").Value;

            tbBannerDirectory.Text =    directoryQ.FirstOrDefault();
            tbAdLink.Text =             linkQ.FirstOrDefault();

            if (tbBannerDirectory.Text.Length > 0)
            {
                try
                {
                    pbBanner.Image = Image.FromFile(tbBannerDirectory.Text);
                }
                catch (Exception err)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Banner image was deleted or moved to another directory. Consider selecting the file's new directory or select a new image!", "Error", buttons);
                }
            }
        }

        #region Old logic with db
        /*
        private string getInvoiceSql()
        {
            string id = Guid.NewGuid().ToString();
            string subject = tbInvoiceSubject.Text;
            string body = tbInvoiceBody.Text;
            string waybill = tbInvoiceWaybill.Text;
            string footer = tbInvoiceFooter.Text;

            if (isInvoiceConfigured)
            {
                return String.Format("UPDATE [InvoiceEmailMessage] SET Subject = N'{0}', Message = N'{1}', Waybill = N'{2}', Footer = N'{3}'", subject, body, waybill, footer);
            }
            else
            {
                return String.Format("INSERT INTO [InvoiceEmailMessage] (Id, Subject, Message, Waybill, Footer) values('{0}', N'{1}', N'{2}', N'{3}', N'{4}')", id, subject, body, waybill, footer);
            }
        }

        private string getCertificateSql()
        {
            string id = Guid.NewGuid().ToString();
            string subject = tbCertSubject.Text;
            string body = tbCertBody.Text;
            string waybill = tbCertWaybill.Text;
            string footer = tbCertFooter.Text;

            if (isCertificateConfigured)
            {
                return String.Format("UPDATE [CertificateEmailMessage] SET Subject = N'{0}', Message = N'{1}', Waybill = N'{2}', Footer = N'{3}'", subject, body, waybill, footer);
            }
            else
            {
                return String.Format("INSERT INTO [CertificateEmailMessage] (Id, Subject, Message, Waybill, Footer) values('{0}', N'{1}', N'{2}', N'{3}', N'{4}')", id, subject, body, waybill, footer);
            }
        }

        private string getBannerSql()
        {
            string id = Guid.NewGuid().ToString();
            string dir = tbBannerDirectory.Text;
            string link = tbAdLink.Text;

            if (isBannerConfigured)
            {
                return String.Format("UPDATE [Banner] SET Directory = '{0}', Link = '{1}'", dir, link);
            }
            else
            {
                return String.Format("INSERT INTO [Banner] (Id, Directory, Link) values('{0}', '{1}', '{2}')", id, dir, link);
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
