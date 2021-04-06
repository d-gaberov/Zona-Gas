namespace WFEmailSender
{
    class DocumentPropertiesIP
    {
        private string docFileDir;
        public DocumentPropertiesIP(string documentNo, string emails, string billOfLading, string documentType, string templateType, string orderNo)
        {
            this.DocumentNo = documentNo;
            this.Emails = emails;
            this.BillOfLading = billOfLading;
            this.DocumentType = documentType;
            this.TemplateType = templateType;
            this.OrderNo = orderNo;
        }

        public string DocumentNo { get; set; }
        public string Emails { get; set; }
        public string BillOfLading { get; set; }
        public string DocumentType { get; set; }
        public string TemplateType { get; set; }
        public string OrderNo { get; set; }
        public string DocFileDir { get; set; }
    }
}
