using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Main.yonor;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class Edit_ad : Form
    {
        Advertisement myAdToEdit = new Advertisement();//Instance of Advertisement to be used in the edition.
        string myAdEditName;//Name of Ad to be edited.
        public Edit_ad(string myAdToEdit)//Binds the Ad data to Form and sets Ad name to be used in edition.
        {
            myAdEditName = myAdToEdit;
            InitializeComponent();
            bindDataToAd();
        }
        public void bindDataToAd()//Binds the data of the Ad to be edited. Data is loaded from XML-Ads.xml
        {
            foreach (XElement xe in (XDocument.Load(ma_controller.XmlParser.xmlAds).XPathSelectElements("//Ad")))
            {
                if (xe.Element("CompanyName").Value.Equals(myAdEditName))
                {
                    //AddButtonToCategoryAppetizer(xe.Element("Name").Value);
                    //comboBox1DishTypeEdit.SelectedIndex = 0;
                    //                    comboBox1DishTypeEdit.SelectedItem = xe.Element("Type").Value;
                    textBox1EditAdCompanyName.Text = xe.Element("CompanyName").Value;
                    textBox4EditAdPrice.Text = xe.Element("Price").Value;
                    textBox5EditAdURL.Text = xe.Element("URL").Value;
                    DateTime adExpTime = DateTime.Parse(xe.Element("ExpirationDate").Value);
                    DateTime adCrTime = DateTime.Parse(xe.Element("CreationDate").Value);

                    dateTimePicker1ExpDateEdit.Value = adExpTime;
                    textBox2EditAdDescription.Text = xe.Element("AdBody").Value;

                }
            }
        }
        private void SetValuesToAdInstance()//When edited it sets the values to the instance.
        {
            myAdToEdit.CompanyName = textBox1EditAdCompanyName.Text;
            myAdToEdit.AdBody = textBox2EditAdDescription.Text;
            myAdToEdit.Price = Convert.ToInt32(textBox4EditAdPrice.Text);
            myAdToEdit.Url = textBox5EditAdURL.Text;
            myAdToEdit.ExpirationDate = dateTimePicker1ExpDateEdit.Value;

        }
        private void WriteInstanceToXml()//Write to XML the instances properties.
        {

            var doc = XElement.Load(ma_controller.XmlParser.xmlAds);

            var adEdition = doc.XPathSelectElements("//Ad").Where(c => c.Element("CompanyName").Value == myAdEditName).Single();
            adEdition.SetElementValue("CompanyName", myAdToEdit.CompanyName);
            adEdition.SetElementValue("Price", myAdToEdit.Price);
            adEdition.SetElementValue("Active", myAdToEdit.Active);
            adEdition.SetElementValue("AdBody", myAdToEdit.AdBody);
            adEdition.SetElementValue("Image", myAdToEdit.ImgPath);
            adEdition.SetElementValue("ExpirationDate", myAdToEdit.ExpirationDate);
            adEdition.SetElementValue("URL", myAdToEdit.Url);
            doc.Save(ma_controller.XmlParser.xmlAds);
            MessageBox.Show($"Your {myAdToEdit.CompanyName} Ad has been edited.", "Edit Ad!");

        }
        private void Button2EditAdCreate_Click(object sender, EventArgs e)//Sets and writes Ad instance to XML.
        {
            SetValuesToAdInstance();
            WriteInstanceToXml();
            this.Close();
        }
        private void Button3EditAdCancel_Click(object sender, EventArgs e)//Exits form.
        {
            this.Close();
        }
        private void Button1EditBrowseAdImage_Click(object sender, EventArgs e)//Sets edited image path to Ad instance to be written.
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                // image file path  
                myAdToEdit.ImgPath = open.FileName;
                label8AdEditImgLoaded.Text = "* Image Loaded *";

            }
        }
    }
}
