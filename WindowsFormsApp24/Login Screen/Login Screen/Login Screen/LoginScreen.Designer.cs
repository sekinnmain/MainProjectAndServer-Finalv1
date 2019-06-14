namespace main
{
    partial class LoginScreen
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PassWordTextBox = new System.Windows.Forms.TextBox();
            this.UserNamelbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SignUpLabel = new System.Windows.Forms.LinkLabel();
            this.MangerLoginPanel = new System.Windows.Forms.Panel();
            this.ManagerEatOutSideButton = new System.Windows.Forms.Button();
            this.ManagerEatInsideButton = new System.Windows.Forms.Button();
            this.ManagerLogOutLabel = new System.Windows.Forms.LinkLabel();
            this.WelcomeVipCustomerLabel = new System.Windows.Forms.Label();
            this.manager_service_btn = new System.Windows.Forms.Button();
            this.InvalidTextPanel = new System.Windows.Forms.Panel();
            this.InvalidOKbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.GuestLoginPanel = new System.Windows.Forms.Panel();
            this.GuestEatInsideButton = new System.Windows.Forms.Button();
            this.GuestSignUpLabal = new System.Windows.Forms.LinkLabel();
            this.SignInLabel = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.GuestEatOutsideButton = new System.Windows.Forms.Button();
            this.VipLoginPanel = new System.Windows.Forms.Panel();
            this.VipCustomerEatOutSideButton = new System.Windows.Forms.Button();
            this.VipCustomerEatInsideButton = new System.Windows.Forms.Button();
            this.VipLogOutLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SignInGuestLabel = new System.Windows.Forms.Label();
            this.forgetPass_btn = new System.Windows.Forms.Button();
            this.guest_btn = new System.Windows.Forms.Button();
            this.FaceBook_btn = new System.Windows.Forms.Button();
            this.ins_btn = new System.Windows.Forms.Button();
            this.twitter_btn = new System.Windows.Forms.Button();
            this.MangerLoginPanel.SuspendLayout();
            this.InvalidTextPanel.SuspendLayout();
            this.GuestLoginPanel.SuspendLayout();
            this.VipLoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.White;
            this.LoginButton.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.LogInButton1;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(404, 365);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(150, 65);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            this.LoginButton.MouseEnter += new System.EventHandler(this.LoginButton_MouseEnter);
            this.LoginButton.MouseLeave += new System.EventHandler(this.LoginButton_MouseLeave);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.UserNameTextBox.Location = new System.Drawing.Point(439, 244);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(170, 19);
            this.UserNameTextBox.TabIndex = 2;
            this.UserNameTextBox.Text = "Enter User Name Here";
            this.UserNameTextBox.Click += new System.EventHandler(this.UserNameTextBoxClicked);
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.UserNameTextBox.Enter += new System.EventHandler(this.UserNameTextBox_Enter);
            // 
            // PassWordTextBox
            // 
            this.PassWordTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PassWordTextBox.Location = new System.Drawing.Point(439, 277);
            this.PassWordTextBox.Name = "PassWordTextBox";
            this.PassWordTextBox.Size = new System.Drawing.Size(170, 19);
            this.PassWordTextBox.TabIndex = 3;
            this.PassWordTextBox.Text = "Enter Pass Word Here";
            this.PassWordTextBox.Click += new System.EventHandler(this.textBox2_Click);
            this.PassWordTextBox.Enter += new System.EventHandler(this.PassWordTextBox_Enter);
            // 
            // UserNamelbl
            // 
            this.UserNamelbl.AutoSize = true;
            this.UserNamelbl.BackColor = System.Drawing.Color.White;
            this.UserNamelbl.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNamelbl.ForeColor = System.Drawing.Color.Black;
            this.UserNamelbl.Location = new System.Drawing.Point(343, 244);
            this.UserNamelbl.Name = "UserNamelbl";
            this.UserNamelbl.Size = new System.Drawing.Size(93, 17);
            this.UserNamelbl.TabIndex = 4;
            this.UserNamelbl.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(351, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pass word:";
            // 
            // SignUpLabel
            // 
            this.SignUpLabel.AutoSize = true;
            this.SignUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignUpLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SignUpLabel.DisabledLinkColor = System.Drawing.Color.Black;
            this.SignUpLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpLabel.LinkColor = System.Drawing.Color.Black;
            this.SignUpLabel.Location = new System.Drawing.Point(809, 28);
            this.SignUpLabel.Name = "SignUpLabel";
            this.SignUpLabel.Size = new System.Drawing.Size(99, 27);
            this.SignUpLabel.TabIndex = 7;
            this.SignUpLabel.TabStop = true;
            this.SignUpLabel.Text = "Sign Up";
            this.SignUpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignUpLabel_LinkClicked);
            this.SignUpLabel.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // MangerLoginPanel
            // 
            this.MangerLoginPanel.BackColor = System.Drawing.Color.White;
            this.MangerLoginPanel.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.MangerLoginPanel.Controls.Add(this.ManagerEatOutSideButton);
            this.MangerLoginPanel.Controls.Add(this.ManagerEatInsideButton);
            this.MangerLoginPanel.Controls.Add(this.ManagerLogOutLabel);
            this.MangerLoginPanel.Controls.Add(this.WelcomeVipCustomerLabel);
            this.MangerLoginPanel.Controls.Add(this.manager_service_btn);
            this.MangerLoginPanel.Location = new System.Drawing.Point(0, 0);
            this.MangerLoginPanel.Name = "MangerLoginPanel";
            this.MangerLoginPanel.Size = new System.Drawing.Size(932, 552);
            this.MangerLoginPanel.TabIndex = 9;
            this.MangerLoginPanel.Visible = false;
            this.MangerLoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.VipPanel_Paint);
            // 
            // ManagerEatOutSideButton
            // 
            this.ManagerEatOutSideButton.AutoSize = true;
            this.ManagerEatOutSideButton.BackColor = System.Drawing.Color.White;
            this.ManagerEatOutSideButton.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.ManagerEatOutSideButton.FlatAppearance.BorderSize = 4;
            this.ManagerEatOutSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManagerEatOutSideButton.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerEatOutSideButton.ForeColor = System.Drawing.Color.Black;
            this.ManagerEatOutSideButton.Location = new System.Drawing.Point(116, 379);
            this.ManagerEatOutSideButton.Name = "ManagerEatOutSideButton";
            this.ManagerEatOutSideButton.Size = new System.Drawing.Size(722, 45);
            this.ManagerEatOutSideButton.TabIndex = 12;
            this.ManagerEatOutSideButton.Text = "Eat Out side";
            this.ManagerEatOutSideButton.UseVisualStyleBackColor = false;
            this.ManagerEatOutSideButton.Click += new System.EventHandler(this.ManagerEatOutSideButton_Click);
            // 
            // ManagerEatInsideButton
            // 
            this.ManagerEatInsideButton.AutoSize = true;
            this.ManagerEatInsideButton.BackColor = System.Drawing.Color.White;
            this.ManagerEatInsideButton.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.ManagerEatInsideButton.FlatAppearance.BorderSize = 4;
            this.ManagerEatInsideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManagerEatInsideButton.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerEatInsideButton.ForeColor = System.Drawing.Color.Black;
            this.ManagerEatInsideButton.Location = new System.Drawing.Point(116, 314);
            this.ManagerEatInsideButton.Name = "ManagerEatInsideButton";
            this.ManagerEatInsideButton.Size = new System.Drawing.Size(722, 45);
            this.ManagerEatInsideButton.TabIndex = 11;
            this.ManagerEatInsideButton.Text = "Eat in side";
            this.ManagerEatInsideButton.UseVisualStyleBackColor = false;
            this.ManagerEatInsideButton.Click += new System.EventHandler(this.ManagerEatInsideButton_Click);
            // 
            // ManagerLogOutLabel
            // 
            this.ManagerLogOutLabel.AutoSize = true;
            this.ManagerLogOutLabel.Location = new System.Drawing.Point(23, 20);
            this.ManagerLogOutLabel.Name = "ManagerLogOutLabel";
            this.ManagerLogOutLabel.Size = new System.Drawing.Size(42, 13);
            this.ManagerLogOutLabel.TabIndex = 4;
            this.ManagerLogOutLabel.TabStop = true;
            this.ManagerLogOutLabel.Text = "LogOut";
            this.ManagerLogOutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogOutLabel_LinkClicked);
            // 
            // WelcomeVipCustomerLabel
            // 
            this.WelcomeVipCustomerLabel.AutoSize = true;
            this.WelcomeVipCustomerLabel.Font = new System.Drawing.Font("Georgia", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeVipCustomerLabel.ForeColor = System.Drawing.Color.Black;
            this.WelcomeVipCustomerLabel.Image = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.WelcomeVipCustomerLabel.Location = new System.Drawing.Point(86, 145);
            this.WelcomeVipCustomerLabel.Name = "WelcomeVipCustomerLabel";
            this.WelcomeVipCustomerLabel.Size = new System.Drawing.Size(816, 72);
            this.WelcomeVipCustomerLabel.TabIndex = 0;
            this.WelcomeVipCustomerLabel.Text = "Welcome VIP Customer";
            // 
            // manager_service_btn
            // 
            this.manager_service_btn.BackColor = System.Drawing.Color.Snow;
            this.manager_service_btn.FlatAppearance.BorderSize = 4;
            this.manager_service_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manager_service_btn.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manager_service_btn.Image = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.manager_service_btn.Location = new System.Drawing.Point(10, 451);
            this.manager_service_btn.Name = "manager_service_btn";
            this.manager_service_btn.Size = new System.Drawing.Size(170, 75);
            this.manager_service_btn.TabIndex = 6;
            this.manager_service_btn.Text = "Manager Service";
            this.manager_service_btn.UseVisualStyleBackColor = false;
            this.manager_service_btn.Click += new System.EventHandler(this.manager_service_btn_Click);
            // 
            // InvalidTextPanel
            // 
            this.InvalidTextPanel.BackColor = System.Drawing.Color.White;
            this.InvalidTextPanel.Controls.Add(this.InvalidOKbutton);
            this.InvalidTextPanel.Controls.Add(this.richTextBox1);
            this.InvalidTextPanel.Location = new System.Drawing.Point(385, 436);
            this.InvalidTextPanel.Name = "InvalidTextPanel";
            this.InvalidTextPanel.Size = new System.Drawing.Size(194, 74);
            this.InvalidTextPanel.TabIndex = 10;
            this.InvalidTextPanel.Visible = false;
            // 
            // InvalidOKbutton
            // 
            this.InvalidOKbutton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidOKbutton.Location = new System.Drawing.Point(70, 46);
            this.InvalidOKbutton.Name = "InvalidOKbutton";
            this.InvalidOKbutton.Size = new System.Drawing.Size(75, 23);
            this.InvalidOKbutton.TabIndex = 1;
            this.InvalidOKbutton.Text = "OK";
            this.InvalidOKbutton.UseVisualStyleBackColor = true;
            this.InvalidOKbutton.Click += new System.EventHandler(this.InvalidOKbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(14, 8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(170, 33);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Something went wrong , plz try again !";
            // 
            // GuestLoginPanel
            // 
            this.GuestLoginPanel.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.GuestLoginPanel.Controls.Add(this.GuestEatInsideButton);
            this.GuestLoginPanel.Controls.Add(this.GuestSignUpLabal);
            this.GuestLoginPanel.Controls.Add(this.SignInLabel);
            this.GuestLoginPanel.Controls.Add(this.label7);
            this.GuestLoginPanel.Controls.Add(this.GuestEatOutsideButton);
            this.GuestLoginPanel.Location = new System.Drawing.Point(0, 0);
            this.GuestLoginPanel.Name = "GuestLoginPanel";
            this.GuestLoginPanel.Size = new System.Drawing.Size(929, 552);
            this.GuestLoginPanel.TabIndex = 11;
            this.GuestLoginPanel.Visible = false;
            // 
            // GuestEatInsideButton
            // 
            this.GuestEatInsideButton.AutoSize = true;
            this.GuestEatInsideButton.BackColor = System.Drawing.Color.White;
            this.GuestEatInsideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuestEatInsideButton.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestEatInsideButton.ForeColor = System.Drawing.Color.Black;
            this.GuestEatInsideButton.Location = new System.Drawing.Point(116, 184);
            this.GuestEatInsideButton.Name = "GuestEatInsideButton";
            this.GuestEatInsideButton.Size = new System.Drawing.Size(722, 43);
            this.GuestEatInsideButton.TabIndex = 10;
            this.GuestEatInsideButton.Text = "Eat in side";
            this.GuestEatInsideButton.UseVisualStyleBackColor = false;
            this.GuestEatInsideButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GuestSignUpLabal
            // 
            this.GuestSignUpLabal.AutoSize = true;
            this.GuestSignUpLabal.Location = new System.Drawing.Point(1313, 46);
            this.GuestSignUpLabal.Name = "GuestSignUpLabal";
            this.GuestSignUpLabal.Size = new System.Drawing.Size(45, 13);
            this.GuestSignUpLabal.TabIndex = 9;
            this.GuestSignUpLabal.TabStop = true;
            this.GuestSignUpLabal.Text = "Sign Up";
            this.GuestSignUpLabal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GuestSignUpLabal_LinkClicked);
            this.GuestSignUpLabal.Click += new System.EventHandler(this.GuestSignUpLabal_Click);
            // 
            // SignInLabel
            // 
            this.SignInLabel.AutoSize = true;
            this.SignInLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignInLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SignInLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInLabel.LinkColor = System.Drawing.Color.Black;
            this.SignInLabel.Location = new System.Drawing.Point(786, 30);
            this.SignInLabel.Name = "SignInLabel";
            this.SignInLabel.Size = new System.Drawing.Size(91, 27);
            this.SignInLabel.TabIndex = 8;
            this.SignInLabel.TabStop = true;
            this.SignInLabel.Text = "Sign In";
            this.SignInLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignInLabel_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Georgia", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Image = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.label7.Location = new System.Drawing.Point(51, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(883, 72);
            this.label7.TabIndex = 7;
            this.label7.Text = "Welcome Guest Customer";
            // 
            // GuestEatOutsideButton
            // 
            this.GuestEatOutsideButton.AutoSize = true;
            this.GuestEatOutsideButton.BackColor = System.Drawing.Color.White;
            this.GuestEatOutsideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuestEatOutsideButton.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuestEatOutsideButton.ForeColor = System.Drawing.Color.Black;
            this.GuestEatOutsideButton.Location = new System.Drawing.Point(116, 252);
            this.GuestEatOutsideButton.Name = "GuestEatOutsideButton";
            this.GuestEatOutsideButton.Size = new System.Drawing.Size(722, 43);
            this.GuestEatOutsideButton.TabIndex = 6;
            this.GuestEatOutsideButton.Text = "Eat out side";
            this.GuestEatOutsideButton.UseVisualStyleBackColor = false;
            this.GuestEatOutsideButton.Click += new System.EventHandler(this.GuestOrderFromMenuButton_Click);
            this.GuestEatOutsideButton.MouseEnter += new System.EventHandler(this.GuestOrderFromMenuButton_MouseEnter);
            this.GuestEatOutsideButton.MouseLeave += new System.EventHandler(this.GuestOrderFromMenuButton_MouseLeave);
            // 
            // VipLoginPanel
            // 
            this.VipLoginPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.VipLoginPanel.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.VipLoginPanel.Controls.Add(this.VipCustomerEatOutSideButton);
            this.VipLoginPanel.Controls.Add(this.VipCustomerEatInsideButton);
            this.VipLoginPanel.Controls.Add(this.VipLogOutLabel);
            this.VipLoginPanel.Controls.Add(this.label1);
            this.VipLoginPanel.Location = new System.Drawing.Point(0, 0);
            this.VipLoginPanel.Name = "VipLoginPanel";
            this.VipLoginPanel.Size = new System.Drawing.Size(917, 549);
            this.VipLoginPanel.TabIndex = 12;
            this.VipLoginPanel.Visible = false;
            // 
            // VipCustomerEatOutSideButton
            // 
            this.VipCustomerEatOutSideButton.AutoSize = true;
            this.VipCustomerEatOutSideButton.BackColor = System.Drawing.Color.White;
            this.VipCustomerEatOutSideButton.FlatAppearance.BorderSize = 4;
            this.VipCustomerEatOutSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VipCustomerEatOutSideButton.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VipCustomerEatOutSideButton.ForeColor = System.Drawing.Color.Black;
            this.VipCustomerEatOutSideButton.Location = new System.Drawing.Point(116, 310);
            this.VipCustomerEatOutSideButton.Name = "VipCustomerEatOutSideButton";
            this.VipCustomerEatOutSideButton.Size = new System.Drawing.Size(722, 45);
            this.VipCustomerEatOutSideButton.TabIndex = 12;
            this.VipCustomerEatOutSideButton.Text = "Eat Out side";
            this.VipCustomerEatOutSideButton.UseVisualStyleBackColor = false;
            this.VipCustomerEatOutSideButton.Click += new System.EventHandler(this.VipCustomerEatOutSideButton_Click);
            // 
            // VipCustomerEatInsideButton
            // 
            this.VipCustomerEatInsideButton.AutoSize = true;
            this.VipCustomerEatInsideButton.BackColor = System.Drawing.Color.White;
            this.VipCustomerEatInsideButton.FlatAppearance.BorderSize = 4;
            this.VipCustomerEatInsideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VipCustomerEatInsideButton.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VipCustomerEatInsideButton.ForeColor = System.Drawing.Color.Black;
            this.VipCustomerEatInsideButton.Location = new System.Drawing.Point(116, 255);
            this.VipCustomerEatInsideButton.Name = "VipCustomerEatInsideButton";
            this.VipCustomerEatInsideButton.Size = new System.Drawing.Size(722, 45);
            this.VipCustomerEatInsideButton.TabIndex = 11;
            this.VipCustomerEatInsideButton.Text = "Eat in side";
            this.VipCustomerEatInsideButton.UseVisualStyleBackColor = false;
            this.VipCustomerEatInsideButton.Click += new System.EventHandler(this.VipCustomerEatInsideButton_Click);
            // 
            // VipLogOutLabel
            // 
            this.VipLogOutLabel.AutoSize = true;
            this.VipLogOutLabel.Location = new System.Drawing.Point(23, 20);
            this.VipLogOutLabel.Name = "VipLogOutLabel";
            this.VipLogOutLabel.Size = new System.Drawing.Size(42, 13);
            this.VipLogOutLabel.TabIndex = 4;
            this.VipLogOutLabel.TabStop = true;
            this.VipLogOutLabel.Text = "LogOut";
            this.VipLogOutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.VipLogOutLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.label1.Location = new System.Drawing.Point(86, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome VIP Customer";
            // 
            // SignInGuestLabel
            // 
            this.SignInGuestLabel.BackColor = System.Drawing.Color.Transparent;
            this.SignInGuestLabel.Font = new System.Drawing.Font("Palace Script MT", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInGuestLabel.ForeColor = System.Drawing.Color.White;
            this.SignInGuestLabel.Image = global::WindowsFormsApp24.Properties.Resources.LogoSignin;
            this.SignInGuestLabel.Location = new System.Drawing.Point(187, 9);
            this.SignInGuestLabel.Name = "SignInGuestLabel";
            this.SignInGuestLabel.Size = new System.Drawing.Size(568, 232);
            this.SignInGuestLabel.TabIndex = 0;
            this.SignInGuestLabel.Click += new System.EventHandler(this.SignInGuestLabel_Click);
            // 
            // forgetPass_btn
            // 
            this.forgetPass_btn.BackColor = System.Drawing.Color.White;
            this.forgetPass_btn.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.ForgetPassWord;
            this.forgetPass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forgetPass_btn.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetPass_btn.ForeColor = System.Drawing.Color.White;
            this.forgetPass_btn.Location = new System.Drawing.Point(331, 301);
            this.forgetPass_btn.Name = "forgetPass_btn";
            this.forgetPass_btn.Size = new System.Drawing.Size(147, 54);
            this.forgetPass_btn.TabIndex = 1;
            this.forgetPass_btn.UseVisualStyleBackColor = false;
            this.forgetPass_btn.Click += new System.EventHandler(this.forgetPass_btn_Click);
            this.forgetPass_btn.MouseEnter += new System.EventHandler(this.LoginButton_MouseEnter);
            this.forgetPass_btn.MouseLeave += new System.EventHandler(this.LoginButton_MouseLeave);
            // 
            // guest_btn
            // 
            this.guest_btn.BackColor = System.Drawing.Color.White;
            this.guest_btn.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.EnterAsGuest1;
            this.guest_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guest_btn.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_btn.ForeColor = System.Drawing.Color.White;
            this.guest_btn.Location = new System.Drawing.Point(485, 301);
            this.guest_btn.Name = "guest_btn";
            this.guest_btn.Size = new System.Drawing.Size(154, 58);
            this.guest_btn.TabIndex = 1;
            this.guest_btn.UseVisualStyleBackColor = false;
            this.guest_btn.Click += new System.EventHandler(this.guest_btn_Click);
            this.guest_btn.MouseEnter += new System.EventHandler(this.LoginButton_MouseEnter);
            this.guest_btn.MouseLeave += new System.EventHandler(this.LoginButton_MouseLeave);
            // 
            // FaceBook_btn
            // 
            this.FaceBook_btn.BackColor = System.Drawing.Color.Transparent;
            this.FaceBook_btn.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.FaceBookButton;
            this.FaceBook_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FaceBook_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FaceBook_btn.Location = new System.Drawing.Point(4, 492);
            this.FaceBook_btn.Margin = new System.Windows.Forms.Padding(2);
            this.FaceBook_btn.Name = "FaceBook_btn";
            this.FaceBook_btn.Size = new System.Drawing.Size(50, 50);
            this.FaceBook_btn.TabIndex = 13;
            this.FaceBook_btn.UseVisualStyleBackColor = false;
            // 
            // ins_btn
            // 
            this.ins_btn.BackColor = System.Drawing.Color.Transparent;
            this.ins_btn.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.instgramButton;
            this.ins_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ins_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ins_btn.Location = new System.Drawing.Point(113, 492);
            this.ins_btn.Margin = new System.Windows.Forms.Padding(2);
            this.ins_btn.Name = "ins_btn";
            this.ins_btn.Size = new System.Drawing.Size(50, 50);
            this.ins_btn.TabIndex = 14;
            this.ins_btn.UseVisualStyleBackColor = false;
            // 
            // twitter_btn
            // 
            this.twitter_btn.BackColor = System.Drawing.Color.Transparent;
            this.twitter_btn.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.TwitterButton;
            this.twitter_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.twitter_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.twitter_btn.Location = new System.Drawing.Point(58, 492);
            this.twitter_btn.Margin = new System.Windows.Forms.Padding(2);
            this.twitter_btn.Name = "twitter_btn";
            this.twitter_btn.Size = new System.Drawing.Size(50, 50);
            this.twitter_btn.TabIndex = 15;
            this.twitter_btn.UseVisualStyleBackColor = false;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::WindowsFormsApp24.Properties.Resources.BackGroundChooseDIsh;
            this.ClientSize = new System.Drawing.Size(920, 545);
            this.Controls.Add(this.VipLoginPanel);
            this.Controls.Add(this.GuestLoginPanel);
            this.Controls.Add(this.MangerLoginPanel);
            this.Controls.Add(this.SignUpLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserNamelbl);
            this.Controls.Add(this.PassWordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.forgetPass_btn);
            this.Controls.Add(this.guest_btn);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.SignInGuestLabel);
            this.Controls.Add(this.InvalidTextPanel);
            this.Controls.Add(this.ins_btn);
            this.Controls.Add(this.twitter_btn);
            this.Controls.Add(this.FaceBook_btn);
            this.Name = "LoginScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.Click += new System.EventHandler(this.LoginScreen_Click);
            this.MangerLoginPanel.ResumeLayout(false);
            this.MangerLoginPanel.PerformLayout();
            this.InvalidTextPanel.ResumeLayout(false);
            this.GuestLoginPanel.ResumeLayout(false);
            this.GuestLoginPanel.PerformLayout();
            this.VipLoginPanel.ResumeLayout(false);
            this.VipLoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SignInGuestLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PassWordTextBox;
        private System.Windows.Forms.Label UserNamelbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel SignUpLabel;
        private System.Windows.Forms.Panel MangerLoginPanel;
        private System.Windows.Forms.Panel InvalidTextPanel;
        private System.Windows.Forms.Button InvalidOKbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel ManagerLogOutLabel;
        private System.Windows.Forms.Label WelcomeVipCustomerLabel;
        private System.Windows.Forms.Panel GuestLoginPanel;
        private System.Windows.Forms.LinkLabel GuestSignUpLabal;
        private System.Windows.Forms.LinkLabel SignInLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GuestEatOutsideButton;
        private System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button manager_service_btn;
        private System.Windows.Forms.Button GuestEatInsideButton;
        private System.Windows.Forms.Button ManagerEatOutSideButton;
        private System.Windows.Forms.Button ManagerEatInsideButton;
        private System.Windows.Forms.Panel VipLoginPanel;
        private System.Windows.Forms.Button VipCustomerEatOutSideButton;
        private System.Windows.Forms.Button VipCustomerEatInsideButton;
        private System.Windows.Forms.LinkLabel VipLogOutLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button forgetPass_btn;
        private System.Windows.Forms.Button guest_btn;
        private System.Windows.Forms.Button FaceBook_btn;
        private System.Windows.Forms.Button ins_btn;
        private System.Windows.Forms.Button twitter_btn;
    }
}

