namespace WindowsFormsApp24.Login_Screen.Login_Screen.Login_Screen
{
    partial class ForgotPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1_RecoverPassEmail = new System.Windows.Forms.Button();
            this.textBox1_emailToRecover = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter email to recover:";
            // 
            // button1_RecoverPassEmail
            // 
            this.button1_RecoverPassEmail.Location = new System.Drawing.Point(64, 96);
            this.button1_RecoverPassEmail.Name = "button1_RecoverPassEmail";
            this.button1_RecoverPassEmail.Size = new System.Drawing.Size(75, 23);
            this.button1_RecoverPassEmail.TabIndex = 1;
            this.button1_RecoverPassEmail.Text = "Recover";
            this.button1_RecoverPassEmail.UseVisualStyleBackColor = true;
            this.button1_RecoverPassEmail.Click += new System.EventHandler(this.Button1_RecoverPassEmail_Click);
            // 
            // textBox1_emailToRecover
            // 
            this.textBox1_emailToRecover.Location = new System.Drawing.Point(143, 42);
            this.textBox1_emailToRecover.Name = "textBox1_emailToRecover";
            this.textBox1_emailToRecover.Size = new System.Drawing.Size(155, 20);
            this.textBox1_emailToRecover.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 161);
            this.Controls.Add(this.textBox1_emailToRecover);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1_RecoverPassEmail);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPass";
            this.Text = "Main - Forgot password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1_RecoverPassEmail;
        private System.Windows.Forms.TextBox textBox1_emailToRecover;
        private System.Windows.Forms.Button button2;
    }
}