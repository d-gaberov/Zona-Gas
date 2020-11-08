namespace WFEmailSender
{
    class DocumentProperties
    {
        private string docFileDir;
        public DocumentProperties(string documentNo, string documentType, string emails, string waybill)
        {
            this.DocumentNo = documentNo;
            this.DocumentType = documentType;
            this.Emails = emails;
            this.Waybill = waybill;
        }

        public string DocumentNo { get; set; }
        public string DocumentType { get; set; }
        public string Emails { get; set; }
        public string Waybill { get; set; }
        public string DocFileDir { get; set; }
    }
}
