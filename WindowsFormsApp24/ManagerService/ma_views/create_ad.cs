using System;
using System.Windows.Forms;
using Main.yonor;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class create_ad : Form
    {
        Advertisement myAd = new Advertisement();//Instance used to the writing of in to the XML file.
        public create_ad()
        {
            InitializeComponent();
        }
        public void adCreation()
        {
            myAd.Active = checkBox1AdState.Checked;
            myAd.AdBody = textBox2AdDescription.Text;
            myAd.CompanyName = textBox1AdName.Text;
            myAd.CreationDate = DateTime.Now;
            myAd.ExpirationDate = dateTimePicker1ExpDate.Value;
            myAd.Url = textBox5AdURL.Text;
            myAd.Price = Convert.ToInt32(textBox4AdPrice.Text);
            ma_controller.XmlParser.XmlParserAds(myAd);
        }
        private void Button2AdCreate_Click(object sender, EventArgs e)//Writes the Ad instance in to the XML, dishes.xml
        {
            if ((MessageBox.Show("Are you sure you want to create this AD?", "MAIN - Create ad",
   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
   MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {

                adCreation();
                AdCreatedMsg(myAd.CompanyName);
                this.Close();

            }
        }
        private void Button1_Click(object sender, EventArgs e)//Loads the path of the Ad image and added it the Ad instance.
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                // image file path  
                myAd.ImgPath = open.FileName;
                label8AdImgLoaded.Text = "* Image Loaded *";

            }
        }
        private void Button3AdCancel_Click(object sender, EventArgs e)//Closes the Ad creation Form
        {
            if ((MessageBox.Show("Close ad creation?", "MAIN - Close ad creation",
  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
  MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {

                this.Close();

            }
        }
        private void AdCreatedMsg(string myCrtAd)//Message to be display upon successfully Ad creation
        {
            MessageBox.Show($"Ad {myCrtAd} was successfully created", "Ad Creation",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
