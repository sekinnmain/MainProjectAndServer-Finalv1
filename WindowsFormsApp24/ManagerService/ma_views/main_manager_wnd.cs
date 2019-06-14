using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Main.yonor;
using System.Xml.Linq;
using System.Xml.XPath;
using MAIN_GUI_Mangaer_window.ma_controller;

namespace MAIN_GUI_Mangaer_window
{
    /// <summary>
    /// This form contains the following tabs:
    /// Dishes: It allow the creation, edition and deletion of Dishes.
    /// Users: It allow the creation, edition and deletion of Users.
    /// Ads: It allow the creation, edition and deletion of Ads. Also enables/disables the MailingList.
    /// Reports: Show available docs by Amit Dahary
    /// StockManagement: It allows the update of raw materials.

    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class main_manager_wnd : Form
    {

        public main_manager_wnd()
        {
            loadDefaultsData();
            //comboBoxLoad();
            InitializeComponent();

        }
        #region Initial declarations
        DataTable dt = new DataTable(); //Data table used to populate the StockManagement DataGrid.
        public string DtColumns { set { dt.Columns.Add(value); } }// Adds columns to the dt DataTable of the StockManagement.
        StockManagement mst = new StockManagement();//Instance of the StockManagement class.
        MailingList adsCampeingToAllCustomers = new MailingList(false);//MailingList instance loads and waits to the CheckBox to start sending emails to all customers. 
        public static string AdSelectedToEdit;//Name of the Ad selected by the ComboBox to be edit in the EditAd form.
        #endregion
        #region Dishes
        public void loadDishesComboEdit()//Method loads the names of the existing dishes in the XML file Dishes.xml
        {
            DataSet DishLoad = new DataSet();
            DishLoad.ReadXml(ma_controller.XmlParser.xmlDishPath);
            comboBox6EditListDish.DisplayMember = "Name";
            comboBox6EditListDish.DataSource = DishLoad.Tables[0];

        }
        private void Button8DishEdit_Click(object sender, EventArgs e)//Open the EditDish form
        {
            ma_views.Edit_Dish myDishEdit = new ma_views.Edit_Dish(comboBox6EditListDish.Text);
            myDishEdit.ShowDialog();
            loadDishesComboEdit();

        }
        private void Button6DishCreate_Click(object sender, EventArgs e)//Open the CreateDish form
        {
            ma_views.CreateDish myDishToCreate = new ma_views.CreateDish();
            myDishToCreate.ShowDialog();
            loadDishesComboEdit();
        }
        #endregion
        #region Ads
        public void loadAdsComboEdit() //Method loads the names of the existing Ads in the XML file Ads.xml
        {
            DataSet adLoad = new DataSet();
            adLoad.ReadXml(ma_controller.XmlParser.xmlAds);
            comboBox8EditAds.DisplayMember = "CompanyName";
            comboBox8EditAds.DataSource = adLoad.Tables[0];

        }
        private void ComboBox8Edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdSelectedToEdit = comboBox8EditAds.SelectedItem.ToString();
        }
        private void Button9EditAds_Click_1(object sender, EventArgs e)//Button opens the Edit Ad form.
        {
            ma_views.Edit_ad formEditMyAd = new ma_views.Edit_ad(comboBox8EditAds.Text);
            formEditMyAd.ShowDialog();
        }
        private void Button10CreateAds_Click_1(object sender, EventArgs e)//Button opens the Create Ad form.
        {
            ma_views.create_ad myAdCreation = new ma_views.create_ad();
            myAdCreation.ShowDialog();
            loadAdsComboEdit();
        }
        private void CheckBox1OnOffCampaign_CheckedChanged(object sender, EventArgs e)//CheckBox fires the campaign Ads sending
        {
            if (checkBox1OnOffCampaign.Checked == true)
            {
                adsCampeingToAllCustomers.scheduleState = true;
                label3StatusMailingList.Text = "Sending Ads every 10 min to customers";
            }
            else
            {
                adsCampeingToAllCustomers.scheduleState = false;
                label3StatusMailingList.Text = "Currently not sending ads.";

            }
        }
        #endregion
        #region Users
        public void loadUsersComboEdit()//Method loads the names of the existing users in the XML file Users.xml
        {

            DataSet UserLoad = new DataSet();
            UserLoad.ReadXml(ma_controller.XmlParser.xmlUsers);
            comboBox2EditUserMainWnd.DisplayMember = "FirstName";
            comboBox2EditUserMainWnd.DataSource = UserLoad.Tables[0];
        }
        private void Button1CreateUserMainForm_Click(object sender, EventArgs e)//Button opens the Create user form.
        {
            ma_views.CreateUser myNewUser = new ma_views.CreateUser();
            myNewUser.ShowDialog();
            loadUsersComboEdit();

        }
        private void Button2EditUserMainForm_Click(object sender, EventArgs e)//Button opens the Edit user form.
        {
            ma_views.EditUser myUserToEdit = new ma_views.EditUser(comboBox2EditUserMainWnd.SelectedIndex, comboBox2EditUserMainWnd.Text);
            myUserToEdit.ShowDialog();
            loadUsersComboEdit();
        }
        #endregion
        #region SMTP
        private void SetSmtpSettings()//Method sets the host SMTP details for Mail delivery in the XML file SMTP.xml
        {

            var doc = XElement.Load(ma_controller.XmlParser.xmlSmtpSettings);

            var hostEdition = doc.XPathSelectElements("//Host").Where(c => c.Element("HostIP").Value == textBox1SmtpIp.Text).Single();
            hostEdition.SetElementValue("HostIP", textBox1SmtpIp.Text);
            hostEdition.SetElementValue("Port", textBox4SmtpPort.Text);
            hostEdition.SetElementValue("Username", textBox3SmtpUsername.Text);
            hostEdition.SetElementValue("Password", textBox2SmtpPassword.Text);
            doc.Save(ma_controller.XmlParser.xmlSmtpSettings);
            MessageBox.Show("Smtp settings have been set, please test your connection.", "Smtp settings");

        }
        public void LoadSmtpValues()//Method gets the connection details from the XML file Stmp.xml
        {
            textBox2SmtpPassword.PasswordChar = '*';
            DataSet smtpLoadSe = new DataSet();
            smtpLoadSe.ReadXml(ma_controller.XmlParser.xmlSmtpSettings);
            textBox1SmtpIp.Text = smtpLoadSe.Tables[0].Rows[0][0].ToString();
            textBox4SmtpPort.Text = smtpLoadSe.Tables[0].Rows[0][1].ToString();
            textBox3SmtpUsername.Text = smtpLoadSe.Tables[0].Rows[0][2].ToString();
            textBox2SmtpPassword.Text = smtpLoadSe.Tables[0].Rows[0][3].ToString();

        }
        private void Button12smtpSetCreds_Click(object sender, EventArgs e)//Button set SMTP values.
        {
            SetSmtpSettings();
            LoadSmtpValues();
            Mailer.SetHostValuesFromXml();//Upadate change values in the mailer.
        }
        private void Button1SmtpTestConn_Click(object sender, EventArgs e)//Button tests the connection to the SMTP server
        {
            Mailer.TestConection($"{textBox5SmtpTestEmail.Text}");

            MessageBox.Show("Message sent.", "Password recovery");

        }
        #endregion
        #region StockManagement
        //This methods updates the StockManagement instance in the program.
        //Contrary to the rest of W/R classes that are written or read (to/from XML file), the StockManagemnet Class works only in memory. 
        private void BtnUpdateStock_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to update the stock?  This operation cannot be undone.", "Updating Main stock",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
     MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Item"].Equals("Hamburger"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown1Burger.Value);

                    }
                    else if (dr["Item"].Equals("Pullet"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown3Pullet.Value);
                    }
                    else if (dr["Item"].Equals("Steak"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown2Steak.Value);
                    }
                    else if (dr["Item"].Equals("Water"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown5Water.Value);
                    }
                    else if (dr["Item"].Equals("Soda"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown4Soda.Value);
                    }
                    else if (dr["Item"].Equals("Cola"))
                    {
                        dr["Amount"] = Decimal.ToInt32(numericUpDown6Cola.Value);
                    }
                }


                dt.AcceptChanges();
                updateData();
            }
        }
        public void addRows(string name, int amount)//Adds rows to the DataTable dt to be added in the StockManagement DataGrid 
        {
            dt.Rows.Add(name, amount);
            Console.WriteLine($"{name} , {amount} added. <<< DEBUGGING");
        }
        public void loadDefaultsData()//Loads default data to the SockManagemnet 
        {
            mst.pulletStock = 14;
            mst.sodaStock = 11;
            mst.steakStock = 22;
            mst.waterStock = 13;
            mst.burgetStock = 12;
            mst.colaStock = 12;
            DtColumns = "Item";
            DtColumns = "Amount";
            addRows("Hamburger", mst.burgetStock);
            addRows("Pullet", mst.pulletStock);
            addRows("Steak", mst.steakStock);
            addRows("Water", mst.waterStock);
            addRows("Soda", mst.sodaStock);
            addRows("Cola", mst.colaStock);
            dt.AcceptChanges();

        }
        private void updateData()//Method update the StockManagement DataGrid Data.
        {
            dt.GetChanges();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
        #endregion
        #region other Designer generated methods.
        private void Main_manager_wnd_Load(object sender, EventArgs e)
        {
            updateData();
            loadDishesComboEdit();
            loadUsersComboEdit();
            loadAdsComboEdit();
            LoadSmtpValues();
            Mailer.SetHostValuesFromXml();

        }

        private void Button14_Click(object sender, EventArgs e)//Exit Button for the Manager Form.
        {
            if ((MessageBox.Show("Do you really want to exit?", "Exit MAIN app",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
     MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {


                Application.Exit();
            }
        }
        #endregion
        #region Exceptions handling
        public static void RaiseOnSmtpNotConnected(string e)//Method takes care of exception generated by an not reachable  SMTP server.
        {
            MessageBox.Show("Smtp server not ready. \n Check Creds and try again.", "Smtp error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);

        }
        #endregion
        #region Reports
        //Report Service implemented by Amit Dahari.

        private void Button3GenerateReport_Click(object sender, EventArgs e)
        {
            if (Choose_Report_comboBox.Text == "Customer feedback")
            {
                foreach (XElement xe in (XDocument.Load(XmlParser.xmlFeedBack).XPathSelectElements("//Feedback"))) //Patch each element from Feedback elements
                {
                    string startDate = this.Date_Picker_From.Value.ToShortDateString();
                    string endDate = this.Date_Picker_To.Value.ToShortDateString();

                    if (Convert.ToDateTime(xe.Element("FeedbackDate").Value) >= Convert.ToDateTime(startDate) && Convert.ToDateTime(xe.Element("FeedbackDate").Value) <= Convert.ToDateTime(endDate))
                    {
                        Customer_feedback_txtbox.AppendText("Rated: ");
                        Customer_feedback_txtbox.AppendText(xe.Element("RatedFeedback").Value);
                        Customer_feedback_txtbox.AppendText(Environment.NewLine);

                        Customer_feedback_txtbox.AppendText("Customer reply: ");
                        Customer_feedback_txtbox.AppendText(xe.Element("CustomerReply").Value);
                        Customer_feedback_txtbox.AppendText(Environment.NewLine);

                        Customer_feedback_txtbox.AppendText("Feed back Date: ");
                        Customer_feedback_txtbox.AppendText(xe.Element("FeedbackDate").Value);
                        Customer_feedback_txtbox.AppendText(Environment.NewLine);
                    }


                    Customer_feedback_txtbox.AppendText(Environment.NewLine);
                    Customer_feedback_txtbox.AppendText("------------------------------"); //Separate between each feedback
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                }
            }

            if (Choose_Report_comboBox.Text == "Total sold dishes")
            {
                int total_day_earned = 0;
                foreach (XElement xe in (XDocument.Load(XmlParser.xmlOrder).XPathSelectElements("//Order")))
                {

                    Customer_feedback_txtbox.AppendText("Time of order: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("TimeOrder").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    Customer_feedback_txtbox.AppendText("Order id: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("idOrder").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    Customer_feedback_txtbox.AppendText("User: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("user").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    Customer_feedback_txtbox.AppendText("Table number: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("tableBnum").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    Customer_feedback_txtbox.AppendText("Order dish: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("dishes").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    Customer_feedback_txtbox.AppendText("Table total: ");
                    Customer_feedback_txtbox.AppendText(xe.Element("Price").Value);
                    Customer_feedback_txtbox.AppendText(Environment.NewLine);

                    total_day_earned += Convert.ToInt32(xe.Element("Price").Value); // Total day earned

                }

                Customer_feedback_txtbox.AppendText(Environment.NewLine);
                Customer_feedback_txtbox.AppendText(Environment.NewLine);
                Customer_feedback_txtbox.AppendText("...........................Summery................................");
                Customer_feedback_txtbox.AppendText(Environment.NewLine);
                Customer_feedback_txtbox.AppendText("Total day earned: ");
                Customer_feedback_txtbox.AppendText(total_day_earned.ToString());
                Customer_feedback_txtbox.AppendText(" Shekels ");

            }
        }
        private void SearchUsingDateTimePicker()
        {
            throw new NotImplementedException();
        }
        private void Choose_Report_comboBox_TextChanged(object sender, EventArgs e) // Once the manager decided what kind of service he wants the tools are available
        {
            if (Choose_Report_comboBox.Text == "Customer feedback")
            {
                Custromer_FeedBack_Date_To_lbl.Visible = true;
                Custromer_FeedBack_Date_From_lbl.Visible = true;
                Date_Picker_From.Visible = true;
                Date_Picker_To.Visible = true;
                Customer_feedback_txtbox.Visible = true;
            }

            if (Choose_Report_comboBox.Text == "Total sold dishes")
            {
                Customer_feedback_txtbox.Visible = true;

            }
        }



        #endregion


    }
}
