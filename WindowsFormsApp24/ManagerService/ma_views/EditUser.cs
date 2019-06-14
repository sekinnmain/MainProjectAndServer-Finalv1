﻿using main;
using NewUsers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Edit existing User form.
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class EditUser : Form
    {
        private VipCustomer myVipCustomer = new VipCustomer();//Instance of user to be edited
        private ma_controller.Manager myManager = new ma_controller.Manager();//Instance of user to be edited
        private int indexUserToEdit;
        private string userEditType;
        private string myUserToEditName;//Name of user to be edited
        User userToEdit = new User();//Instance of user to be edited
        VipCustomer vipUserToEdit = new VipCustomer();//Instance of user to be edited
        Employee emplUserToEdit = new Employee();//Instance of user to be edited
        public EditUser(int userIndex, string userToEditName)
        {
            myUserToEditName = userToEditName;
            InitializeComponent();
            indexUserToEdit = userIndex;
            BindDataEditUser(userToEditName);
        }
        private void BindDataEditUser(string myUser)//Binds data to be edited
        {


            foreach (XElement xe in (XDocument.Load(ma_controller.XmlParser.xmlUsers).XPathSelectElements($"//RegisteredUser")))
            {
                if (xe.Element("FirstName").Value.Equals(myUser))
                {

                    textBox1editUserName.Text = xe.Element("FirstName").Value;
                    textBoeditUserLastName.Text = xe.Element("LastName").Value;
                    textBox3Addressedit.Text = xe.Element("Address").Value;
                    textBox4PhoneNumberedit.Text = xe.Element("PhoneNumber").Value;
                    textBox5EmailUseredit.Text = xe.Element("Email").Value;
                    if (xe.Element("Type").Value.Equals("Vipuser"))
                    {
                        textBox7editserUsername.Text = xe.Element("UserName").Value;

                    }
                    else if (xe.Element("Type").Value.Equals("Employee"))
                    {
                        textBox6editUserID.Text = xe.Element("ID").Value;

                    }
                    else if (xe.Element("Type").Value.Equals("Manager"))
                    {
                        textBox1editUserName.Text = xe.Element("UserName").Value;


                    }
                }
            }



        }
        private void DeleteUserFromXml(string myUser)//Deletes current user from XML
        {

            XDocument xdoc = XDocument.Load(ma_controller.XmlParser.xmlUsers);
            xdoc.Descendants("Users")
                .Elements("RegisteredUser")
                .Where(x => (string)x.Element("FirstName") == myUser)
                .Remove();


            MessageBox.Show($"User {myUser} has been deleted", "User deletion.",
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
        private void ChangeUserPass()//Changes users password
        {
            if (checkBox1EditPasswordEditForm.Checked == true)
            {
                textBox8editUserPassword.ReadOnly = false;
                textBox9editPassVerify.ReadOnly = false;
            }
            else
            {
                textBox8editUserPassword.ReadOnly = true;
                textBox9editPassVerify.ReadOnly = true;
            }



        }
        private bool PassMatch()//Checks if both passwords match
        {
            if ((comboBox1EditUser.SelectedItem.Equals("Vipuser")))
            {
                if (!textBox8editUserPassword.Text.Equals(textBox9editPassVerify.Text))
                {
                    MessageBox.Show("Passwords don't match, please try again", "Password miss match",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    myVipCustomer.PassWord = textBox8editUserPassword.Text;
                return true;
            }

            return true;
        }
        private void LoadDefaultValuesForComponents()//Loads values for ComboBox

        {
            checkBox1EditPasswordEditForm.Checked = false;
            comboBox1EditUser.Items.Add("Vipuser");
            comboBox1EditUser.Items.Add("Employee");
            comboBox1EditUser.Items.Add("Manager");
            comboBox1EditUser.SelectedIndex = 1;
            textBox8editUserPassword.ReadOnly = true;
            textBox9editPassVerify.ReadOnly = true;
            textBox8editUserPassword.Text = "";
            textBox9editPassVerify.Text = "";
            textBox8editUserPassword.PasswordChar = '*';
            textBox9editPassVerify.PasswordChar = '*';

            if (comboBox1EditUser.SelectedItem.Equals("Vipuser"))
            {
                textBox8editUserPassword.ReadOnly = true;
                textBox9editPassVerify.ReadOnly = true;
                checkBox1EditPasswordEditForm.Visible = true;
                label10EditUserVrfyPass.Visible = true;
                label9EditUserPassword.Visible = true;


            }




        }
        private void hideElementsByType()//Hide elements by category
        {
            if (comboBox1EditUser.SelectedItem.Equals("Vipuser"))
            {

                showElements(true);

            }
            else if (comboBox1EditUser.SelectedItem.Equals("Employee"))
            {
                showElements(false);
                ShowIdToEmployee(true);

            }
            else if (comboBox1EditUser.SelectedItem.Equals("Manager"))
            {
                showElements(false);
            }
        }
        private void showElements(bool state)//Sets Visibility for components according to state
        {
            textBox7editserUsername.Visible = state;
            textBox8editUserPassword.Visible = state;
            textBox9editPassVerify.Visible = state;
            textBox6editUserID.Visible = state;
            label10EditUserVrfyPass.Visible = state;
            label9EditUserPassword.Visible = state;
            label7EditUserID.Visible = state;
            checkBox1EditPasswordEditForm.Visible = state;
            label8EdituserUsername.Visible = state;
        }
        private void ShowIdToEmployee(bool state)//Show ID when editing Employee
        {
            label7EditUserID.Visible = state;
            textBox6editUserID.Visible = state;

        }
        private void CheckBox1EditPasswordEditForm_CheckedChanged(object sender, EventArgs e)//calls ChangeUserPass
        {
            ChangeUserPass();
        }
        private void EditUser_Load(object sender, EventArgs e)//calls LoadDefaultValuesForComponents
        {

            LoadDefaultValuesForComponents();

        }
        private void Button2CanceleditUser_Click(object sender, EventArgs e)//closes form
        {
            this.Close();
        }
        private void ComboBox1EditUser_SelectedIndexChanged(object sender, EventArgs e)//calls hideElementsByType
        {
            hideElementsByType();
        }
        private void Button1editUser_Click(object sender, EventArgs e)//Edit users if password match
        {

            if (PassMatch())
            {
                SetValuesToUserInstance();
                WriteInstanceToXml();
                this.Close();
            }


        }
        private void SetValuesToUserInstance()//sets values to instance to be edited and written
        {
            userToEdit.userType = comboBox1EditUser.SelectedItem.ToString();
            userToEdit.FirstName = textBox1editUserName.Text;
            userToEdit.LastName = textBoeditUserLastName.Text;
            userToEdit.PhoneNumber = textBox4PhoneNumberedit.Text;
            userToEdit.Email = textBox5EmailUseredit.Text;
            userToEdit.Address = textBox3Addressedit.Text;
            if (comboBox1EditUser.SelectedItem.ToString().Equals("Vipuser"))
            {
                vipUserToEdit.UserName = textBox7editserUsername.Text;
                vipUserToEdit.PassWord = textBox8editUserPassword.Text;
            }
            else if (comboBox1EditUser.SelectedItem.ToString().Equals("Employee"))
            {
                emplUserToEdit.ID = textBox6editUserID.Text;
            }
        }
        private void WriteInstanceToXml()//Writes instance user to XML
        {

            var doc = XElement.Load(ma_controller.XmlParser.xmlUsers);

            var userEdition = doc.XPathSelectElements("//RegisteredUser").Where(c => c.Element("FirstName").Value == myUserToEditName).Single();
            userEdition.SetElementValue("Name", userToEdit.FirstName);

            userEdition.SetElementValue("LastName", userToEdit.LastName);
            userEdition.SetElementValue("PhoneNumber", userToEdit.PhoneNumber);
            userEdition.SetElementValue("Type", userToEdit.userType);
            userEdition.SetElementValue("Email", userToEdit.Email);
            userEdition.SetElementValue("Address", userToEdit.Address);
            if (comboBox1EditUser.SelectedItem.ToString().Equals("Vipuser"))
            {
                userEdition.SetElementValue("Username", vipUserToEdit.UserName);
                userEdition.SetElementValue("Password", vipUserToEdit.PassWord);
            }
            else if (comboBox1EditUser.SelectedItem.ToString().Equals("Employee"))
            {
                userEdition.SetElementValue("ID", emplUserToEdit.ID);
            }
            //dishEdition.Element("balance").Value = "50";
            doc.Save(ma_controller.XmlParser.xmlUsers);
            MessageBox.Show($"Your {userToEdit.FirstName} user has been edited.", "Edit created!");

        }
        private void Button1DeleteUser_Click(object sender, EventArgs e)//Delete current user from XML
        {
            DeleteUserFromXml(myUserToEditName);
        }
    }
}
