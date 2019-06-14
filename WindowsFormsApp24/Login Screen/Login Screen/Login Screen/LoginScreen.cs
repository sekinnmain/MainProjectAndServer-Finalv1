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
using Login_Screen;
using Main.yonor;
using MAIN_GUI_Mangaer_window;
using WindowsFormsApp24.Login_Screen.Login_Screen.Login_Screen;


namespace main
{
    public partial class LoginScreen : Form
    {

       
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserNameTextBoxClicked(object sender, EventArgs e)//מנקה את התיבה ברגע הלחיצה ומשנה את הכתב מאפור לשחור
        {
            UserNameTextBox.Clear();
            UserNameTextBox.ForeColor = Color.Black;
            if (UserNameTextBox.Text == "")
            {
                PassWordTextBox.UseSystemPasswordChar = false;
                PassWordTextBox.ForeColor = Color.Gray;
                PassWordTextBox.Text = "Enter Pass Word Here";

            }

        }

        private void textBox2_Click(object sender, EventArgs e)//אותו דבר כמו התיבה של השם משתמש
        {
            
            PassWordTextBox.Clear();
            PassWordTextBox.ForeColor = Color.Black;
            PassWordTextBox.UseSystemPasswordChar = true;
            
            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.ForeColor = Color.Gray;
                UserNameTextBox.Text = "Enter User Name Here";
            }
        }

        private void linkLabel2_Click(object sender, EventArgs e)//פותח חלון חדש של הרשמה ומחביא את החלון הנוכחי
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
            //  listsign.Add(signUp);
            //  listsign[0].Show();
        }
        private void forgetPass_btn_Click(object sender, EventArgs e)//
        {
            ForgotPass fp = new ForgotPass();
            fp.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            bool chkvip = XmlLoader.CheckIfVipCustomerExist(UserNameTextBox.Text, PassWordTextBox.Text);//שיטה הבודקת אם קיים שם משתמש וססמה במאגר כמו השם משתמש והססימה בתיבות שלהם
            bool chktypemng = XmlLoader.CheckIfManagerExist(UserNameTextBox.Text,PassWordTextBox.Text);// בודק אם השם משתמש והססמה שהוכנסו תואמים למשתמש מסוג מנהל
            if (UserNameTextBox.Text != "" && PassWordTextBox.Text != "" && chkvip == true && chktypemng== false)//במקרה שקיים משתמש עם השם משתמש והססמה והוא לא מנהל אז יפתח פאנל הוי איי פי
            {
                if (UserNameTextBox.Text != "Enter User Name Here" && PassWordTextBox.Text != "Enter Pass Word Here")
                {
                    VipLoginPanel.Visible = true;
                     UserNameTextBox.ForeColor = Color.Gray;
                     UserNameTextBox.Text = "Enter User Name Here";
                     PassWordTextBox.UseSystemPasswordChar = false;
                     PassWordTextBox.ForeColor = Color.Gray;
                     PassWordTextBox.Text = "Enter Pass Word Here";
                }
                else 
                {
                    InvalidTextPanel.Visible = true;
                }


            }
            else if (UserNameTextBox.Text != "" && PassWordTextBox.Text != "" && chktypemng == true)//במקרה ויש שם משתמש וססמה התואמים והוא גם מסוג מנהל אז יפתח פאנל המנהל
            {
                MangerLoginPanel.Visible = true;
                UserNameTextBox.ForeColor = Color.Gray;
                UserNameTextBox.Text = "Enter User Name Here";
                PassWordTextBox.UseSystemPasswordChar = false;
                PassWordTextBox.ForeColor = Color.Gray;
                PassWordTextBox.Text = "Enter Pass Word Here";
                
            }
            else 
            {
                InvalidTextPanel.Visible = true;
            }
            

        }

        private void InvalidOKbutton_Click(object sender, EventArgs e)
        {
            InvalidTextPanel.Visible = false;
        }

        private void VipPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogOutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//מסתיר את פאנל המנהל
        {
            MangerLoginPanel.Visible = false;
        }

        private void VIPorderFromMenuButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//מפעיל את פאנל האורחים ללא קשר למה שיש בתוך תיבות השם משתמש והסיסמה
        {
             UserNameTextBox.ForeColor = Color.Gray;
            UserNameTextBox.Text = "Enter User Name Here";
            PassWordTextBox.UseSystemPasswordChar = false;
            PassWordTextBox.ForeColor = Color.Gray;
            PassWordTextBox.Text = "Enter Pass Word Here";

            GuestLoginPanel.Visible = true;
        }

        private void GuestOrderFromMenuButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "OutSide";
            menu.get_club_member_lbl.Text = "guest";
            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void SignInLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//מסתיר את פאנל האורח על מנת להתחבר
        {
            GuestLoginPanel.Visible =false ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void EatInsdieButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void EatInsdieButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void EatSomeWhereElseButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void EatSomeWhereElseButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void GamesButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void GamesButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void GuestOrderFromMenuButton_MouseEnter(object sender, EventArgs e)//סתם ליופי
        {
            GuestEatOutsideButton.BackColor = Color.DarkGoldenrod;
        }

        private void GuestOrderFromMenuButton_MouseLeave(object sender, EventArgs e)//סתם ליופי
        {
            GuestEatOutsideButton.BackColor = Color.Goldenrod;
        }

        private void GuestRetrunButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void GuestRetrunButton_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void LoginButton_MouseEnter(object sender, EventArgs e)//סתם ליופי
        {
            LoginButton.BackColor = Color.DarkGoldenrod;
        }

        private void LoginButton_MouseLeave(object sender, EventArgs e)//סתם ליופי
        {
            LoginButton.BackColor = Color.Goldenrod;
        }

        private void PointShopButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void PointShopButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void ReturnButton_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void ReturnButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void VIPorderFromMenuButton_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void VIPorderFromMenuButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void GuestLocationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GuestLocationPanel_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.ForeColor = Color.Gray;
                UserNameTextBox.Text = "Enter User Name Here";
            }
            if (PassWordTextBox.Text == "")
            {
                PassWordTextBox.ForeColor = Color.Gray;
                PassWordTextBox.Text = "Enter User Name Here";
            }
        }

        private void LoginScreen_Click(object sender, EventArgs e)//ברגע שנלחץ הפאנל והתיבות ריקות אז הוא מאתחל את מה שהיה רשום שם
        {
            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.ForeColor = Color.Gray;
                UserNameTextBox.Text = "Enter Pass Word Here";
            }
            if (PassWordTextBox.Text == "")
            {
                PassWordTextBox.UseSystemPasswordChar = false;
                PassWordTextBox.ForeColor = Color.Gray;
                PassWordTextBox.Text = "Enter Pass Word Here";
            }
        }

        private void GuestSignUpLabal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void SignUpLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void SignInGuestLabel_Click(object sender, EventArgs e)
        {

        }

        private void SignUpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void GuestSignUpLabal_Click(object sender, EventArgs e)//מפעיל את חלון ההרשמה מתוך הפאנל של האורח
        {
            SignUp sign = new SignUp();
            this.Hide();
            sign.Show();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void EatInsideButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Guest";
            
            this.Hide();
        }

        private void EatSomeWhereElseButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "OutSide";
            menu.get_club_member_lbl.Text = "Vip Member";
            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void EatSomeWhereElseButtonGuestButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "OutSide";
            menu.get_club_member_lbl.Text = "guest";

            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void EatInsdieButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Vip Member";
            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void manager_service_btn_Click(object sender, EventArgs e)//מתוך פאנל המנהל מפעיל את שירות המנהל
        {
            main_manager_wnd myManager = new main_manager_wnd();
            myManager.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            MangerLoginPanel.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "guest";
            
            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void ManagerEatInsideButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Manager";
            
            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void ManagerEatOutSideButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Manager";

            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void VipCustomerEatInsideButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Vip Customer";

            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void VipCustomerEatOutSideButton_Click(object sender, EventArgs e)//פותח את חלון האורדר סרויס ומגדיר לו ערכים לפי הכפתור שנבחר
        {
            Menu menu = new Menu();
            menu.Show();
            menu.get_seat_orGo_lbl.Text = "Inside";
            menu.get_club_member_lbl.Text = "Vip Customer";

            menu.Call_Service_Choose_btn.Enabled = true;
            this.Hide();
        }

        private void VipLogOutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//מסתיר את חלון הוי איי פי
        {
            VipLoginPanel.Visible = false;
        }

        private void UserNameTextBox_Enter(object sender, EventArgs e)// ברגע שנכנסים לתיבה אז נמחק כל התוכן בו והכתב הופך לשחור
        {
            UserNameTextBox.Clear();
            UserNameTextBox.ForeColor = Color.Black;
            if (UserNameTextBox.Text == "")
            {
                PassWordTextBox.UseSystemPasswordChar = false;
                PassWordTextBox.ForeColor = Color.Gray;
                PassWordTextBox.Text = "Enter Pass Word Here";

            }
        }

        private void PassWordTextBox_Enter(object sender, EventArgs e)// ברגע שנכנסים לתיבה אז נמחק כל התוכן בו והכתב הופך לשחור
        {
            PassWordTextBox.Clear();
            PassWordTextBox.ForeColor = Color.Black;
            PassWordTextBox.UseSystemPasswordChar = true;

            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.ForeColor = Color.Gray;
                UserNameTextBox.Text = "Enter User Name Here";
            }
        }


        private void Button1_Click_2(object sender, EventArgs e)//מפעיל לינק של אינטרנט עם הרבה משחקים
        {
            string url = " https://www.gogy.com/?gclid=Cj0KCQjw6IfoBRCiARIsAF6q06vZgT6Qc9KD8iXFv2m372HCNGPL_gTrEAURJctrNaeC-cBRBOgwcjgaAsp7EALw_wcB";
            System.Diagnostics.Process.Start("iexplore.exe", url);


        }

        private void guest_btn_Click(object sender, EventArgs e)
        {
            UserNameTextBox.ForeColor = Color.Gray;
            UserNameTextBox.Text = "Enter User Name Here";
            PassWordTextBox.UseSystemPasswordChar = false;
            PassWordTextBox.ForeColor = Color.Gray;
            PassWordTextBox.Text = "Enter Pass Word Here";

            GuestLoginPanel.Visible = true;
        }
    }
}
