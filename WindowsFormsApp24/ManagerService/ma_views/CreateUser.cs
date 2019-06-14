using System;
using System.Windows.Forms;
using NewUsers;
using main;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class CreateUser : Form
    {
        private VipCustomer myVipCustomer = new VipCustomer();
        private Employee myEmployee = new Employee();
        private ma_controller.Manager myManager = new ma_controller.Manager();
        public CreateUser()
        {
            InitializeComponent();
        }
        private void CreateUser_Load(object sender, EventArgs e)
        {

            LoadDefaultValuesForComponents();

        }
        private void LoadDefaultValuesForComponents()//Loads default values for components to be used.

        {
            comboBox1CreateUser.Items.Add("Vipuser");
            comboBox1CreateUser.Items.Add("Employee");
            comboBox1CreateUser.Items.Add("Manager");
            comboBox1CreateUser.SelectedIndex = 1;
            textBox8CreateUserPassword.Text = "";
            textBox8CreateUserPassword.PasswordChar = '*';
            textBox9CrePassVerify.Text = "";
            textBox9CrePassVerify.PasswordChar = '*';
        }
        private void hideElementsByType()//Sets the visibility property to elements according to category
        {
            if (comboBox1CreateUser.SelectedItem.Equals("Vipuser"))
            {
                showElements(true);
                ShowIdToEmployee(false);
            }
            else if (comboBox1CreateUser.SelectedItem.Equals("Employee"))
            {
                showElements(false);
                ShowIdToEmployee(true);
            }
            else if (comboBox1CreateUser.SelectedItem.Equals("Manager"))
            {
                showElements(true);
            }
        }
        private void showElements(bool state)//Set visibility according to State
        {
            textBox7createUserUsername.Visible = state;
            textBox8CreateUserPassword.Visible = state;
            textBox9CrePassVerify.Visible = state;
            label10CrtUsrPassVrfy.Visible = state;
            label11PasswordDontMatch.Visible = state;
            label9CrtUserPass.Visible = state;
            label8CrtUsername.Visible = state;
        }
        private void ShowIdToEmployee(bool state)//Show ID field when creating Employee
        {
            label7CrtUsrId.Visible = state;
            textBox6CreateUserID.Visible = state;

        }
        private void CreateUserByType()//Creates users according to the type.
        {
            if (comboBox1CreateUser.SelectedItem.Equals("Vipuser"))
            {
                myVipCustomer.FirstName = textBox1CreateUserName.Text;
                myVipCustomer.LastName = textBox2CreUserLastName.Text;
                myVipCustomer.PhoneNumber = textBox4PhoneNumber.Text;
                myVipCustomer.UserName = textBox4PhoneNumber.Text;
                myVipCustomer.PassWord = textBox4PhoneNumber.Text;
                myVipCustomer.Address = textBox5EmailCreateUser.Text;
                myVipCustomer.Email = textBox5EmailCreateUser.Text;
                myVipCustomer.userType = comboBox1CreateUser.SelectedItem.ToString();
                ma_controller.XmlParser.XmlParserVipCustomer(myVipCustomer);
                userCreatedMsg(myVipCustomer.FirstName);

            }
            else if (comboBox1CreateUser.SelectedItem.Equals("Employee"))
            {
                myEmployee.FirstName = textBox1CreateUserName.Text;
                myEmployee.LastName = textBox2CreUserLastName.Text;
                myEmployee.PhoneNumber = textBox4PhoneNumber.Text;
                myEmployee.Address = textBox5EmailCreateUser.Text;
                myEmployee.Email = textBox5EmailCreateUser.Text;
                myEmployee.ID = textBox6CreateUserID.Text;
                myEmployee.userType = comboBox1CreateUser.SelectedItem.ToString();
                ma_controller.XmlParser.XmlParserEmployee(myEmployee);
                userCreatedMsg(myEmployee.FirstName);

            }
            else if (comboBox1CreateUser.SelectedItem.Equals("Manager"))
            {
                myManager.FirstName = textBox1CreateUserName.Text;
                myManager.LastName = textBox2CreUserLastName.Text;
                myManager.PhoneNumber = textBox4PhoneNumber.Text;
                myManager.UserName = textBox4PhoneNumber.Text;
                myManager.PassWord = textBox4PhoneNumber.Text;
                myManager.Address = textBox5EmailCreateUser.Text;
                myManager.Email = textBox5EmailCreateUser.Text;
                myManager.userType = comboBox1CreateUser.SelectedItem.ToString();
                ma_controller.XmlParser.XmlParserManager(myManager);
                userCreatedMsg(myManager.FirstName);

            }
        }
        private bool PassMatch()//Checks if passwords matches. This helps for  password remembering.
        {
            if ((comboBox1CreateUser.SelectedItem.Equals("Vipuser")))
            {
                if (!textBox8CreateUserPassword.Text.Equals(textBox9CrePassVerify.Text))
                {
                    MessageBox.Show("Passwords don't match, please try again", "Password miss match",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    myVipCustomer.PassWord = textBox8CreateUserPassword.Text;
                return true;
            }

            return true;
        }
        private void ComboBox1CreateUser_SelectedIndexChanged(object sender, EventArgs e)//Hides elements according to category when changed
        {
            hideElementsByType();
        }
        private void Button2CancelCreateUser_Click(object sender, EventArgs e)//Closes form
        {
            this.Close();
        }
        private void Button1CreateUser_Click(object sender, EventArgs e)//Create user and writes to XML-Users.xml
        {
            if (PassMatch())
            {
                CreateUserByType();
                this.Close();
            }


        }
        private void userCreatedMsg(string myUsrCreated)//Message display when user created.
        {
            MessageBox.Show($"User {myUsrCreated} was successfully created", "User created",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
