using System;
using Main.yonor;
using System.Windows.Forms;

namespace WindowsFormsApp24.Login_Screen.Login_Screen.Login_Screen
{

    /// <summary>
    /// This form allows users to recover their password.
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)//Closes the form
        {
            this.Close();
        }

        private void Button1_RecoverPassEmail_Click(object sender, EventArgs e)//Invokes the static method Mailer.EmailPassword(textBox1_emailToRecover.Text) recover users password.
        {
            MessageBox.Show("If you are registered, you will get an email with your password shortly.", "Recover password",
                MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            Mailer.EmailPassword(textBox1_emailToRecover.Text);
            this.Close();
        }
    }
}
