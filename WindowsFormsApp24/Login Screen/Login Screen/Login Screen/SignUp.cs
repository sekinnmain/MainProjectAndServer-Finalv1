using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewUsers;
using System.Xml.Linq;
using main;
using System.Text.RegularExpressions;
using MAIN_GUI_Mangaer_window.ma_controller;

namespace Login_Screen
{
    public partial class SignUp : Form
    {
        DataTable dt = new DataTable("dt");
        Regex PhoneNumberReg = new Regex("[0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
        

        public SignUp()
        {
            InitializeComponent();

        }

        private void CheckButton1_MouseEnter(object sender, EventArgs e)//סתם ליופי
        {
            CheckButton1.BackColor = Color.DarkGreen;
        }

        private void CheckButton1_MouseLeave(object sender, EventArgs e)//סתם ליופי
        {
            CheckButton1.BackColor = Color.SeaGreen;
        }

        private void SignUpButton_MouseEnter(object sender, EventArgs e)//סתם ליופי
        {
            SignUpButton.BackColor = Color.DarkGreen;
        }

        private void SignUpButton_MouseLeave(object sender, EventArgs e)//סתם ליופי
        {
            SignUpButton.BackColor = Color.SeaGreen;
        }

        private void CheckButton1_Click(object sender, EventArgs e)
        {

            bool chk = XmlLoader.CheckIfUserNameExist(RegisterUserName1TextBox.Text);//שיטה הבודקת האם קיים שם משתמש שבתוך התיבה במאגר
            
            if (RegisterUserName1TextBox.Text.Length >= 4 && RegisterUserName1TextBox.Text.Length <= 14 && chk == false )//בודק אם אורך תוכן התיבה הוא מתאים
            {
                AviableUserNameName1.Visible = true;
                UnAviableUserNameLabel1.Visible = false;
            }
            else
            {
                UnAviableUserNameLabel1.Visible = true;
                AviableUserNameName1.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void RegisterPhone1TextBox_TextChanged(object sender, EventArgs e)
        {
            RegisterPhone1TextBox.MaxLength = 7;
        }

        private void SignUpButton_Click(object sender, EventArgs e)// על ההתחלה מגדיר את כל הלייבלים של הטעות להיות ניראים
        {
            UnSuccesEmailCheckLabel.Visible = true;
            UnSuccesFirstNameCheckLabel.Visible = true;
            UnSuccesLastNameCheckLabel.Visible = true;
            UnSuccesPassWordCheckLabel.Visible = true;
            UnSuccesPhoneCheckLabel.Visible = true;
            UnSuccesStreetCheckLabel.Visible = true;
            UnSuccesUserNameCheckLabel.Visible = true;
            UnSuccesVerifyPassWordCheckLabel.Visible = true;
            if (AviableUserNameName1.Visible == true)//אם רואים את לייבל היוזר אפשרי אז ידלק לייבל ההצלחה
            {
                SuccesUserNameCheckLabel.Visible = true;
                UnSuccesUserNameCheckLabel.Visible = false;
            }
            if (RegisterPassWord1TextBox.Text.Length <= 14 && RegisterPassWord1TextBox.Text.Length >= 4)//אם אורך הטקסט נכון אז הלייבל של הטעות יוסתר והלייבל של ההצלחיה יודלק
            {
                SuccesPassWordCheckLabel.Visible = true;
                UnSuccesPassWordCheckLabel.Visible = false;
                
            }
            if (VerfyPassWordTextBox.Text == RegisterPassWord1TextBox.Text)// אם הטקסט של תיבת הסיסמה ותיבת האימות סיסמה שוות אז תידלק ליילב ההצלחה
            {
                SuccesVerifyPassWordCheckLabel.Visible = true;
                UnSuccesVerifyPassWordCheckLabel.Visible = false;

            }
            if (RegisterEmail1TextBox.Text.Length >= 4 && RegisterEmail1TextBox.Text.Length <= 14 && RegisterEmail1ComboBox.Text != "")//אם טקסט של האימייל באורך מתאים ונבחר משהו מהקובו בוקס אז תידלק לייבל ההצלחה
            {
                SuccesEmailCheckLabel.Visible = true;
                UnSuccesEmailCheckLabel.Visible = false;
            }
            if (PhoneNumberReg.IsMatch(RegisterPhone1TextBox.Text) && RegisterPhone1ComboBox.Text != "")// אם הטקס של הפלאפון מתאים למבנה של השדה המוגדר בחלון זה מתאים וגם נבחר משהו מהקומבו בוקס תידלק לייבל ההצלחה
            {
                SuccesPhoneCheckLabel.Visible = true;
                UnSuccesPhoneCheckLabel.Visible = false;
            }
            if (RegisterStreet1TextBox.Text != "")// אם הטקסט  לא ריק תידלק לייבל ההצלחה
            {
                SuccesStreetCheckLabel.Visible = true;
                UnSuccesStreetCheckLabel.Visible = false;
            }
            if (textBox1.Text != "")// אם הטקסט  לא ריק תידלק לייבל ההצלחה
            {
                SuccesFirstNameCheckLabel.Visible = true;
                UnSuccesFirstNameCheckLabel.Visible = false;
            }
            if (textBox2.Text != "")// אם הטקסט  לא ריק תידלק לייבל ההצלחה
            {
                SuccesLastNameCheckLabel.Visible = true;
                UnSuccesLastNameCheckLabel.Visible = false;
            }
            if (SuccesEmailCheckLabel.Visible == true && SuccesFirstNameCheckLabel.Visible == true && SuccesLastNameCheckLabel.Visible == true && SuccesPassWordCheckLabel.Visible == true && SuccesPhoneCheckLabel.Visible == true && SuccesStreetCheckLabel.Visible == true && SuccesUserNameCheckLabel.Visible == true && SuccesVerifyPassWordCheckLabel.Visible == true )//אם כל הלייבלים של ההצלחה ניראות , אז יתווסף יוזר חדש מסוג וי איי פי לתוך האסאמאל , החלון יסגר ויפתח חלון חדש של לוגין סקרין
           {
                VipCustomer vip = new VipCustomer();//מופע היקבל את כל הערכים הנדרשים על מנת ליצור משתמש
                vip.FirstName = textBox1.Text;
                vip.LastName = textBox2.Text;
                vip.UserName = RegisterUserName1TextBox.Text;
                vip.PassWord = RegisterPassWord1TextBox.Text;
                vip.Email = RegisterEmail1TextBox.Text + "@" + RegisterEmail1ComboBox.Text;
                vip.Address = RegisterStreet1TextBox.Text;
                vip.PhoneNumber = RegisterPhone1ComboBox.Text + RegisterPhone1TextBox.Text;
                vip.userType = "Vipuser";

                XmlParser.XmlParserVipCustomer(vip);//שיטה היוצרת משתמש

                MessageBox.Show("Successfully Registered", "WOOHOO");

                this.Close();

            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)//במקרה של סגירה , יפתח חלון חדש של לוגין סקרין
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
        }
    }
}
