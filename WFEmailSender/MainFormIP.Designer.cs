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

namespace WFEmailSender
{
    public partial class MainFormIP : Form
    {
        public MainFormIP()
        {
            InitializeComponent();
        }
    }
}

