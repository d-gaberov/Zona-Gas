using System;
using System.Windows.Forms;

namespace WFEmailSender
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            tbGuide.ReadOnly = true;
            label1.Select();

            string guide = @"

                                        Basic user guide / possible errors

        Before using the application, the email account that will be used to send emails from needs to be allowed to be used from a third party software like this app. This can be done following these steps:
            1. Sign in to Gmail
            2. Visit this link: https://myaccount.google.com/lesssecureapps , to access Less Secure App Access in My Account.
            3. Next to “Allow less secure apps: OFF,” select the toggle switch to turn ON.
            4. Visit the Display Unlock Captcha page and click Continue to remove the security block.
        The Allow less secure apps setting may not be available for:
            - Accounts with 2-Step Verification (2FA) enabled. If 2FA is already enabled on your account, you should create an application-specific password and use this password for your application. If you still can’t access your account with an app password, visit the Display Unlock Captcha page and click Continue to remove the security block.
            - G Suite users: This setting may not be available if your G Suite administrator has locked less secure app account access.
        
        The minimum .Net Framework Runtime version required for this app is 4.7.2. Windows allows multiple .Net Framework versions installed on one machine. To check what version you have, simply open start menu and type cmd in the search box. Open cmd as administrator and in the console type: dir %windir%\Microsoft.NET\Framework /AD. It will show the list of all the directories with all the versions installed along with the latest ones. Here is a link of .Net Framework Runtime 4.7.2 from Microsoft if you dont have it installed: https://dotnet.microsoft.com/download/dotnet-framework/net472.

        The app also needs Microsoft Office Word installed on the machine to convert docx files to pdf. It is used as a background process.

        The app reads the following properties from the docx/rtf files:
            ZonaGas documents:
                - Title : This property will be used for the document number.
                - Subject : This property will be used for the document type e.g. Invoice or Certificate.
                - Tags : This property will be used for the email(s) where the doc needs to be sent. The emails can be more than one separated by ';' !
                - Comments (optional) : This property will be used for the waybill number. If this property is empty or the text inside is not composed only from numbers, the email send will not have waybill tracking text.
            InstantPot Documents:
                - Title : This property will be used for the document number.
                - Tags : This property will be used for the email(s) where the doc needs to be sent. The emails can be more than one separated by ';' !
                - Comments : This property will be used for the bill of lading number.                         
                - Subject : This property will be used for the document type e.g. Invoice or Bill of Goods.
                - Categories : This property will be used to identofy which html template will be sent as email e.g. InstantPot, Accessory or TBI.
                - Company : This property will be used for the order number.

        There are three main screens in the app: Main view, Email settings view and General settings view.

        The Main View is pretty self explanatory. The user selects source directory which is the folder where the app should get the docx files, destination directory which is the folder where the converted pdf files are saved and enters emal credentials of the email used to send the documents.

            IMPORTANT: The number of emails sent is based on the docx files and not on the pdf files because that is where the app gets the necessary properties. The pdf file name generated is based on the Document number and Document type which means that if there are two docx files that have the same document number for example 123 and both have the same document type for example Invoice only one pdf file will be generated but will be sent two times, one for each corresponding docx file and its email property!

            IMPORTANT: After sending emails with the application once, it is recommended to close the application and restart it if other documents need to be processed and sent. This is due to a conflict that may occur between this application and Microsoft Office Word that is used to open the docx files. Possible error that the application may show is a word dialog box that prompts the user to save changes to the conflicted document, no matter what option the user selects in that dialog box, the status label on the main view will write 'Command failed' and the execution will stop but a still working Microsoft Word process will remain in the task manager. Recommended actions in case of this error are to close the application and termnate the Microsoft Word process from the task manager.
            
        The Settings View is where the user writes default credentials for the email account used to send emails. Here the user also may select default folder directories for docx and pdf files. These default settings are used in the Main View if the user select default checkboxes for source directory, destination directory and credentials.

        The Email Settings View is where the user edits the email contents sent to the customers. 
On the right there are two tabs 'Invoice' and 'Certificate', here the user types subject, body, waybill(disabled) and footer text for the emails sent. These texts are imported in the email message depending on the docx file document type. The waybill field is disabled for now and a text is added automatically to the email if the docx file contains waybill in the properties. The text added is: Можете да проследите пратката си на този линк с номер на товарителница: {the waybill number} where 'този линк' is a hyperlink to Speedy's package tracking page.
On the left is where the user configures the banner image and banner advertisement link to be added email. The banner image will be attached to the end of the email signature and the advertisement link is the link that opens when the image is clicked in the inbox.
        
            IMPORTANT: The banner image must be in jpg format and the recommented maximum dimensions are: Width - up to 300 pixels, Height - up to 100 pixels. These dimensions can be checked by right click on the image -> Properties -> Details tab -> Scroll down to Image.

        Version 1.1.1: 
            - The email template can now be edited. Note that this is a html template so it is hard to do via UI controls. It can be found in the app's root folder/Data/SignatureTemplate.html. Can be opened with any text editor and changed as needed. The basic file layout must be kept and only texts, css properties and links should be changed. Do not change the content Id's (everything that is in a src tag) as these are identificators for the images used in the signature.

        Version 1.1.2: 
            - Added the option to send Report/Справка with a new email template in the Email Settings form.
            - The app now supports both docx and rft files. This option can be selected in the Settings form.

        Version 1.1.3:
            - Added the option to send the emails from a different Alias than the original email address. The alias can be any string and it is not required to have a common email pattern.
            - Can be configured in the setting screen where the user configures default email and password. If the alias is left empty when the button save is clicked, the alias will be automatically saved as the original email address.
        
        Version 1.2.4:
            - Minor bug fixes in ZonaGas part of the app.
            - Improved UI.
            - Added InstantPot functionality.

        Version 1.2.5:
            - Bug fixes.
            - Server settings can now be configured in the app.
            - There are different server settings: One for ZonaGas, one for InstantPot.

        Version 1.2.6:
            - InstantPotTBILisingTemplate renamed to 'AirFryerTrackingTemplate.html'. Renamed the string in 'Categories' tab from 'TBI' to 'AirFryer'. 
            - Added new template 'AirPurifierTrackingTemplate.html' for Air Purifiers. The string in 'Categories' tab should be 'AirPurifier'.
            - Added new template 'SparePartsTrackingTemplate.html' for Spare Parts. The string in 'Categories' tab should be 'SpareParts'. ";


            tbGuide.Text = guide;
        }

        private void tbGuide_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
