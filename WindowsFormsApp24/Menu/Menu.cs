using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using WindowsFormsApp24;
using Main;
using NewUsers;
using MAIN_GUI_Mangaer_window.ma_controller;
using System.IO;



namespace main
{
    public partial class Menu : Form


    {
       List<Panel> listPanel = new List<Panel>();//יצירת רשימה של פא נלים למעבר נח בן בפאנלים
        List<Button> listUpButton = new List<Button>();//יצירת רשימה של כפתורים המראים באיזה פאנל המשתמש נמצא
        List<Dish> dishes = new List<Dish>();//יצירת רשימה של מנות לצורך אחסנת המנות בהזמנה של הלקוח
        List<Label> labels = new List<Label>();//יצירת רשימה של כל הלייבלים לצורך מעבר נח
        List<string> namesDishes = new List<string>();//יצירת רשימה של שמות המנות שהלקוח בחר כדי שיהיו מאוחסנות במקום ונוכל לקחת אותם ולהציגם ללקוח
        List<Button> buttons = new List<Button>();//יצירת רשימת הכפתורים האדומים להסרת מנה שהלקוח בחר
        User user = new User();
        Regex regexCn = new Regex("[0-9][0-9][0-9][0-9]");//במסך תשלום מאפשר ללקוח להכניס את פרטי האשראי רק לפי התבנית הזאת
        Regex regexEd = new Regex("[0-9][0-9]['/'][0-9][0-9]");
        Regex regexEd2 = new Regex("[0][0]['/'][0][0]");
        Regex regex3d = new Regex("[0-9][0-9][0-9]");
        OrderService myOrder = new OrderService();
        Pay pay = new Pay();
        Feedback fb = new Feedback();
        Dish myDish = new Dish();
        int count = 0;
        int checkCardNumber;//אתחול משתנים של הכרטיס אשראי
        int checkExpirationdate;
        int checkDigit;
        int numIteractionButtonOrdersMain = 1;//מונה המסדר את הכפתורים האדומים של הסרת המנה בסדר אעיד וקבוע
        int numIteractionlabelsMain = 1;//מונה המסדר את הלייבלים האדומים של הסרת המנה בסדר אעיד וקבוע
        int numIteractionButtonsMain = 0;//מונה המסדר את הכפתורים בכל התפריט  מנות פתיחה,ראשית,שתיה,וקינוח
        int numIteractionButtonsDessert = 0;
        int numIteractionButtonsDrink = 0;
        int numIteractionButtonsAppetizer = 0;
        double totalCost;
        string notes;
        string str;
        static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);//נתיה הנותן את הכתובת של האייקונים של הכפתורים בתפריט
        static DirectoryInfo myDir = new DirectoryInfo(AppPath);
        static string dataDir = myDir.Parent.Parent.FullName.ToString();
        public static string ButtonMenu = $"{dataDir}\\Resources";




        public Menu()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            #region Panels && UpButtons Control

            listPanel.Add(ChooseDish_panel);//הוספה לרשימת הפאנלים את כל 5 הפאנלים שבתפריט
            listPanel.Add(EditDish_panel);
            listPanel.Add(Pay_pnl);
            listPanel.Add(feedback_pnl);
            listPanel.Add(end_pnl);
            for (int i = 1; i < 5; i++)//לולאה המאתחלת את כל הפאנלים להיות בלתי נראים חוץ מהפאנל הראשון בעת טעינת הטופס
            {
                listPanel[i].Visible = false;
            }
            listPanel[count].Visible = true;//אתחול הפאנל הראשון של בחירת מנה

            listUpButton.Add(ChooseDish_btn);// הוספת הכפתורים העליונים לרשימת הכפתורים המציגים את שלב ההזמנה
            listUpButton.Add(EditDish_btn);
            listUpButton.Add(Pay_btn);
            listUpButton.Add(FeedBack_btn);
            listUpButton.Add(finish_btn1);
            listUpButton[count].Enabled = true;// מציג במסך פתיחה את השלב של מצב תהליך ההזמנה ,כפתור בחירת המנה
            for (int i = 1; i < 5; i++)//הופך את שאר הכפתורים המראם את שלב ההזמנה ללא זמינים
            {
                listUpButton[i].Enabled = false;
            }

            Previous_Choose_btn.Enabled = false;//בעת אתחול הטופס כפתור האחורה אינו מאופשר
            LoadDishesButtonsInSections(); //XML טעינת הכפתורים ע"פ נתוני ה 
            #endregion Panels && UpButtons
        }

        #region Next && Previous Controll
        private void Next_Choose_btn_Click(object sender, EventArgs e)//NEXT אירוע  לחיצת כפתור      
        {
            count++;//המונה משתנה כדי לבצע מעבר בין הפאנלים
            Previous_Choose_btn.Enabled = true;//מאופשר Previous ברגע שעברנו את המסך הראשון כפתור ה 
            PayCheck();//קריאה לשיטה שבודקת האם אנחנו במסך תשלום ואם כן מבצעת את מה שיש בפנים
            listUpButton[count].Enabled = true;//אפשור כפתור מצב ההזמנה הנוכחי
            listUpButton[count - 1].Enabled = false;//מבטל את האפשור של כפתור מצב ההזמנה הקודם
            listPanel[count].Visible = true;//מאפשר את הפאנל הנוכחי
            DisheMenu_tab.Visible = false;//מבטל את הפאנל של כפתורי הזמנת המנות מהפאנל הראשון
            NextPreviouscheck();//קריאה לשיטות וביצוע לפי הפאנל הנוכחי(הבדיקה איזה שיטה מתבצעת) היא בתוך השיטות עצמן
            ChooseCheck();
            EditCheck();
            CreateFeedBack();
        }

        private void Previous_Choose_btn_Click(object sender, EventArgs e)
        {
            count--;
            listPanel[count].Visible = true;//טעינת הפאנל הנוכחי
            listUpButton[count].Enabled = true;//טעינת כפתור מצב ההזמנה הנוכחי
            listPanel[count + 1].Visible = false;/*כל פעם שעובר פאנל פאנל אחד מוצג , ואחד נעלם*/
            listUpButton[count + 1].Enabled = false;/*כל פעם שעובר פאנל כפתור אחד מוצג , ואחד נעלם*/
            NextPreviouscheck();//קריאה לשיטות וביצוע לפי הפאנל הנוכחי(הבדיקה איזה שיטה מתבצעת) היא בתוך השיטות עצמן
            ChooseCheck();
            EditCheck();
            CreateFeedBack();
        }

        private void NextPreviouscheck()/*גורמת לכפתור ה"קודם" להיות אפורה בהתחלה, וגורמת לכפתור ה"הבא" להיות בפאנל האחרון אפור*/
        {
            if (count == 4 || count == 2)
            {
                Next_Choose_btn.Enabled = false;//לא מאופשר NEXT בפאנלים של תשלום ושל הסיום ההזמנה כפתור ה 
            }
            else
            {
                Next_Choose_btn.Enabled = true;
            }
        }

        #endregion Next && Previous Controll

        #region Creation's
        private void CreateFeedBack()//בפאנל הפידבק,ואפשור כפתור הדירוג והתיבת טקסט NEXT יצירת הפידבק בעת לחיצת 
        {
            if (count == 4)//יצירת המופע של פידבק
            {
                int rate = Convert.ToInt32(fb_rate.Value);
                string desc = fb_description.Text;
                fb_commant_lbl.Visible = false;
                rate_lbl.Visible = false;
                Feedback feedback = new Feedback(desc, rate);
                this.fb = feedback;

            }
            else if (count == 3)//אפשור הכפתורים במסך הפידבק
            {
                ok_paynum_lbl.Visible = false;
                Previous_Choose_btn.Enabled = false;
                rate_lbl.Visible = true;
                fb_commant_lbl.Visible = true;
            }
        }

        private void CreatePay()// שיטה היוצרת את פאנל התשלום ואת התשלום עצמו
        {
            if (checkCardNumber == 1 && checkExpirationdate == 1 && checkDigit == 1)//תנאי הבודק אם כל תנאי התשלום בוצעו כהלכה
            {
                string CreditCardNum = (textPay1.Text + textPay2.Text + textPay3.Text + textPay4.Text);//NEXT ביצוע התשלום ואפשור כבפתור ה 
                ok_paynum_lbl.BringToFront();
                ok_paynum_lbl.Visible = true;
                wrong_paynow_lbl.Visible = false;
                Next_Choose_btn.Enabled = true;
                textPay1.Enabled = false;
                textPay2.Enabled = false;
                textPay3.Enabled = false;
                textPay4.Enabled = false;
                edText.Enabled = false;
                digitext3.Enabled = false;
                paynow_btn.Enabled = false;
                this.pay.creditCardNumber = CreditCardNum;
                this.pay.threeDigit = digitext3.Text;
                this.pay.expirationDate = edText.Text;
                myOrder.pay = this.pay;

            }
            else
            {
                ok_paynum_lbl.Visible = false;
            }

        }

        private void finish_end_btn_Click_1(object sender, EventArgs e)//XML יוצרת את ההזמנה ומכניסה אותה ל  FINISH שיטה שבעת לחיצת כפתור  
        {

            myOrder.dishes = this.dishes;
            //myOrder.user = user;
            myOrder.price = this.totalCost;
            myOrder.feedBack = this.fb;
            myOrder.seatOrGo = get_seat_orGo_lbl.Text;
            myOrder.notes = notes;
            XmlParser.XmlParserOrder(myOrder);
            this.Close();
        }




        #endregion Creation's

        #region PayPanel
        private void CheckCardNumber()//שיטה הבודקת את התבנית של ספרות כרטיס האשראי
        {

            if (this.regexCn.IsMatch(textPay1.Text) &&
                this.regexCn.IsMatch(textPay2.Text) &&
                this.regexCn.IsMatch(textPay3.Text) &&
                this.regexCn.IsMatch(textPay4.Text))
            {
                ok_cardnumber_lbl.Visible = true;// אם הכל מתאים תוצג הודעה בהתאם
                cnWrong_lbl.Visible = false;
                this.checkCardNumber = 1;
            }
            else
            {
                cnWrong_lbl.Visible = true;//במידה ולא תוצג הודעה המתאימה
                ok_cardnumber_lbl.Visible = false;
                this.checkCardNumber = 0;
            }
        }

        private void CheckExpirationdate()// שיטה הבודקת אם תאריך הכרטיס תקף ולפי התבנית ומציגה הודעה בהתאם
        {

            if (this.regexEd.IsMatch(edText.Text) && edText.Text != "00/00")
            {
                ok_ed_lbl.Visible = true;
                ed_worng_lbl.Visible = false;
                this.checkExpirationdate = 1;

            }
            else
            {
                ed_worng_lbl.Visible = true;
                ok_ed_lbl.Visible = false;
                this.checkExpirationdate = 0;
            }
        }


        private void Check3digit()//שיטה הבודקת האם 3 הספרות בגב הכרטיס נכונות ולפי התבנית המתאימה ומציגה הודעה בהתאם
        {

            if (this.regex3d.IsMatch(digitext3.Text))
            {
                ok_3digit_lbl.Visible = true;
                digit_worng_lbl.Visible = false;
                this.checkDigit = 1;
            }
            else
            {
                digit_worng_lbl.Visible = true;
                ok_3digit_lbl.Visible = false;
                this.checkDigit = 0;
            }
        }
        private void PayCheck()//שיטה ההבודקת אם אנחנו בפאנל תשלום 
        {
            if (count == 2)//יצא מאפשור PREVIOS במידה וכן תוצג הודעה במעבר לפאנל, כמו כן יוצג המחיר הכולל וכפתור ה
            {
                if ((MessageBox.Show("This is the last time to edit before the pay, are you sure u want to continue?", "Pre-payment Notice",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    //gettotalCost();
                    get_total_price_lbl.Text = totalCost.ToString() + " ILS";
                    Previous_Choose_btn.Enabled = false;

                    if (get_club_member_lbl.Text != "guest")//במידה והמשתמש הוא לא אורח אלא אורח רשום או מנהל הוא יקבל הנחה של 30%
                    {
                        double newtotalCost = totalCost;
                        get_discount_lbl.Visible = true;
                        VipMemberPrice_label.Visible = true;
                        get_discount_lbl.Text = (newtotalCost * 0.7).ToString() + "ILS";
                    }

                }

            }
        }
        private void paynow_btn_Click(object sender, EventArgs e)//ולאחר מכן קריאה לשיטות הבדיקה של התשלום PAY אירוע בעת לחיצת כפתור   
        {
            if ((MessageBox.Show("You're sure your details are correct and you want to make a payment?", "Pre-payment Notice",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                CheckCardNumber();
                CheckExpirationdate();
                Check3digit();
                CreatePay();

            }

        }

        #region payButton
        private void Call_Service_Choose_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Call was sent please wait", "Employee's order");
        }

        private void save_changes_btn_Click(object sender, EventArgs e)
        {
            this.notes = richTextBox1.Text;
            MessageBox.Show("The Changes Saved", "Employee's order");
        }

        private void textPay1_TextChanged(object sender, EventArgs e)
        {
            this.textPay1.ForeColor = System.Drawing.Color.Black;
            int s = textPay1.Text.Length;
            if(s==4)
            {
                textPay2.Focus();
            }
        }

        private void textPay2_TextChanged(object sender, EventArgs e)
        {
            this.textPay2.ForeColor = System.Drawing.Color.Black;
            int s = textPay2.Text.Length;
            if (s == 4)
            {
                textPay3.Focus();
            }
        }

        private void textPay3_TextChanged(object sender, EventArgs e)
        {
            this.textPay3.ForeColor = System.Drawing.Color.Black;
            int s = textPay3.Text.Length;
            if (s == 4)
            {
                textPay4.Focus();
            }
        }

        private void textPay4_TextChanged(object sender, EventArgs e)
        {
            this.textPay4.ForeColor = System.Drawing.Color.Black;
            int s = textPay4.Text.Length;
            if (s == 4)
            {
                edText.Focus();
            }
        }

        private void edText_TextChanged(object sender, EventArgs e)
        {
            this.edText.ForeColor = System.Drawing.Color.Black;
            int s = edText.Text.Length;
            if (s == 5)
            {
                digitext3.Focus();
            }
        }

        private void digitext3_TextChanged(object sender, EventArgs e)
        {
            this.digitext3.ForeColor = System.Drawing.Color.Black;
            int s = digitext3.Text.Length;
            if (s == 3)
            {
                paynow_btn.Focus();
            }
        }

        #endregion

        #endregion

        #region ChooseDishPanel
        #region RemoveGroupboxinChooseDish
        private void AddDishToOrder(string nameOfButton)//כמו כן המחיר שלה יתווסף למחיר הכולל והיא תתווסף לפאנל של הצגת בחירת המנות של המשתמש XML בחירת מנה ובדיקה האם נמצאת בקובץ ה 
        {
            Dish myDish = new Dish();
            foreach (XElement xe in (XDocument.Load(XmlParser.xmlDishPath).XPathSelectElements("//Dish")))
            {
                if (xe.Element("Name").Value.Equals(nameOfButton))
                {
                    myDish.dishName = xe.Element("Name").Value;
                    myDish.dishSize = Convert.ToInt32(xe.Element("Size").Value);
                    myDish.dishPrice = Convert.ToInt32(xe.Element("Price").Value);
                    myDish.dishDescription = xe.Element("Description").Value;
                    if ((MessageBox.Show(String.Format("Add '{0}' to the order pack?", myDish.dishName), "Employee",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        this.dishes.Add(myDish);
                        totalCost += myDish.dishPrice;
                        AddLabelToOrderChoose(myDish);
                    }

                }
            }

        }

        private void AddLabelToOrderChoose(Dish myDish)//  שיטה המוסיפה לפאנל שנמצא על הגרופ בוקס את אותו שם המנה שנבחר בתפריט וכפתור אדום לצורך הסרת המנה מהסל 
        {
            Label newLabel = new Label();
            Label newLabelEdit = new Label();
            Button newButton = new Button();
            AddLabelOrderChoose(newLabel);
            AddButtonOrderChoose(newButton);
            newLabel.Text = myDish.dishName;
            namesDishes.Add(newLabel.Text);
            labels.Add(newLabel);
            buttons.Add(newButton);
            order_Choose_pnl.Controls.Add(newLabel);
            order_Choose_pnl.Controls.Add(newButton);
            numIteractionButtonOrdersMain += 1;
            numIteractionlabelsMain += 1;
            newButton.Click += (s, e) =>//אירוע לצורך הסרת מנה מפאנל הצגת המנות בעת לחיצה על הכפתור האדום
            {
                this.totalCost -= myDish.dishPrice;
                numIteractionlabelsMain = 1;
                numIteractionButtonOrdersMain = 1;
                namesDishes.Remove(newLabel.Text);
                labels.Remove(newLabel);
                buttons.Remove(newButton);
                this.dishes.Remove(myDish);
                order_Choose_pnl.Controls.Clear();
                labels.Remove(newLabel);
                buttons.Remove(newButton);
                namesDishes.Remove(newButton.Text);
                int numofmember = labels.Count();
                for (int i = 0; i < numofmember; i++)
                {
                    AddLabelOrderChoose(labels[i]);
                    labels[i].Text = namesDishes[i];
                    numIteractionlabelsMain += 1;
                }

                for (int i = 0; i < numofmember; i++)
                {
                    AddButtonOrderChoose(buttons[i]);
                    numIteractionButtonOrdersMain += 1;
                }
            };

        }

       private void AddLabelOrderChoose(Label label)//יצירת שם המנה בפאנל ע"פ סדר
        {
            order_Choose_pnl.Controls.Add(label);
            label.Top = numIteractionlabelsMain * 20;
            label.Font = new System.Drawing.Font("Georgia", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Left = 40;
            label.Height = 20;
            label.Width = 150;
        }

        private void AddButtonOrderChoose(Button button)//יצירת כפתור ההסרה לכל שם מנה שמוצג בפאנל הצגת המנות ללקוח
        {
            order_Choose_pnl.Controls.Add(button);
            button.Left = 10;
            button.BackColor = Color.Red;
            button.Top = numIteractionButtonOrdersMain * 20;
            button.Height = 10;
            button.Width = 20;
        }
        #endregion
        private void ChooseCheck()/*בודקת האם הגעת לעריכת מנה או בחירת מנה*/
        {
            if (count == 0)
            {
                listPanel[count].Visible = true;
                listPanel[count].Visible = true;
                DisheMenu_tab.Visible = true;
                Previous_Choose_btn.Enabled = false;
                DishInfo_pnl.Visible = true;
               
            }
        }
        private void LoadDishesButtonsInSections()
        {
            DishInfo_pnl.Visible = true;
            DishInfo_pnl.BringToFront();

            foreach (XElement xe in (XDocument.Load(XmlParser.xmlDishPath).XPathSelectElements("//Dish")))
            {
                if (xe.Element("Type").Value.Equals("Appetizer"))
                {
                    AddButtonToCategoryAppetizer(xe.Element("Name").Value);

                }
                else if (xe.Element("Type").Value.Equals("Main"))
                {
                    AddButtonToCategoryMain(xe.Element("Name").Value);
                }
                else if (xe.Element("Type").Value.Equals("Dessert"))
                {
                    AddButtonToCategoryDessert(xe.Element("Name").Value);
                }
                else if (xe.Element("Type").Value.Equals("Drink"))
                {
                    AddButtonToCategoryDrink(xe.Element("Name").Value);
                }
            }
        }




        private void AddButtonToCategoryAppetizer(string nameOfButton)
        {

            List<Button> buttons = new List<Button>();//Part of integration yo0x
            Button newButton = new Button();
            buttons.Add(newButton);
            this.Controls.Add(newButton);
            newButton.MouseHover += (s, e) => { ShowDishData(nameOfButton); };
            newButton.Click += (s, e) => { AddDishToOrder(nameOfButton); };
            appitizer_pnl.Controls.Add(newButton);
            newButton.Top = numIteractionButtonsAppetizer * 40;
            newButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newButton.Image = Image.FromFile(ButtonMenu + "//AppetizerButton.jpg");
            newButton.Left = 3;
            newButton.Text = nameOfButton;
            numIteractionButtonsAppetizer += 1;
            newButton.Height = 40;
            newButton.Width = 285;

            //return newButton;
        }
        private void AddButtonToCategoryMain(string nameOfButton)
        {

            List<Button> buttons = new List<Button>();//Part of integration yo0x
            Button newButton = new Button();
            buttons.Add(newButton);
            this.Controls.Add(newButton);
            newButton.MouseHover += (s, r) => { ShowDishData(nameOfButton); };
            newButton.Click += (s, e) => { AddDishToOrder(nameOfButton); };
            mainCourse_pnl.Controls.Add(newButton);
            newButton.Image = Image.FromFile(ButtonMenu + "//MainCourseButton.jpg");
            newButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newButton.Top = numIteractionButtonsMain * 40;
            newButton.Left = 3;
            newButton.Text = nameOfButton;
            numIteractionButtonsMain += 1;
            newButton.Height = 40;
            newButton.Width = 285;

            //return newButton;
        }
        private void AddButtonToCategoryDessert(string nameOfButton)
        {

            List<Button> buttons = new List<Button>();//Part of integration yo0x
            Button newButton = new Button();
            buttons.Add(newButton);
            this.Controls.Add(newButton);
            newButton.MouseHover += (s, r) => { ShowDishData(nameOfButton); };
            newButton.Click += (s, e) => { AddDishToOrder(nameOfButton); };
            Dessert_pnl.Controls.Add(newButton);
            newButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newButton.Image = Image.FromFile(ButtonMenu + "//DessertButton.jpg");
            newButton.Top = numIteractionButtonsDessert * 40;
            newButton.Left = 3;
            newButton.Text = nameOfButton;
            numIteractionButtonsDessert += 1;
            newButton.Height = 40;
            newButton.Width = 285;
            //return newButton;
        }
        private void AddButtonToCategoryDrink(string nameOfButton)
        {
            List<Button> buttons = new List<Button>();//Part of integration yo0x
            Button newButton = new Button();
            buttons.Add(newButton);
            this.Controls.Add(newButton);
            newButton.MouseHover += (s, r) => { ShowDishData(nameOfButton); };
            newButton.Click += (s, e) => { AddDishToOrder(nameOfButton); };
            drink_pnl.Controls.Add(newButton);
            //newButton.BackgroundImage = Image.FromFile("\\Resources\\MainCourseButton");
            newButton.Top = numIteractionButtonsDrink * 40;
            newButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newButton.Left = 3;
            newButton.Text = nameOfButton;
            newButton.Image = Image.FromFile(ButtonMenu+"//DrinkButton.jpg");
            numIteractionButtonsDrink += 1;
            newButton.Height = 40;
            newButton.Width = 285;
            //return newButton;
        }

        private void ShowDishData(string dishName)
        {

            foreach (XElement xe in (XDocument.Load(XmlParser.xmlDishPath).XPathSelectElements("//Dish")))
            {
                if (xe.Element("Name").Value.Equals(dishName))
                {

                    label15dishName.Text = xe.Element("Name").Value;
                    label14dishSize.Text = xe.Element("Size").Value+ " CAL";
                    pictureBox1.Load(xe.Element("Image").Value);
                    get_price_dish_lbl.Text = xe.Element("Price").Value + " ILS";
                    textBox1dishDescription.Text = xe.Element("Description").Value;

                }
            }
        }



        private int CountDishesInXml(string xPathStr, string xmlPath)
        {
            return XDocument.Load(xmlPath).XPathSelectElements(xPathStr).Count();
        }

        private string GetNameDishesXml(string myXmlFile)
        {
            return XDocument.Load(myXmlFile).Root.Element("Dish").Element("Name").Value;
        }

        #endregion

        #region EditDishPanel
        private void EditCheck()//שיטה הבודקת האם אנחנו בפאנל עריכת המנה
        {
            if (count == 1)//במידה וכן יוצג הפאנל עם התשלום הכולל
            {
                EditDish_panel.Visible = true;
                EditDish_btn.Visible = true;
                DishInfo_pnl.Visible = false;
                dishnames_lbl.Text = GetDishNamesChoose();
                showTotalCostLbl.Text = totalCost.ToString() + " ILS ";

            }
            else if (count==0)//מונע שכפול של שם המנות בעת מעבר מפאנל בחירת המנה לפאנל עריכת המנה הלוך ושוב
            {
                str = "";
            }
        }
        private string GetDishNamesChoose()//שיטה המשרשרת את שמות המנות למחרוזת אחת שתוצג ללקוח
        {
             for (int i = 0; i < namesDishes.Count(); i ++)
            {
                str += namesDishes[i] + "\n";
            }
            return str;
        }

        #endregion

    }
}