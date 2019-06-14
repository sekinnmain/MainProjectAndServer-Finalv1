using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Main;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class Edit_Dish : Form
    {
        Dish myDisToEdit = new Dish();//Instance of Dish to be used in the edition.
        string myDishToEditName;//Name of Dish to be edited.
        public Edit_Dish(string dishToEdit)//Binds the dish data to Form and sets Dish name to be used in edition.
        {
            myDishToEditName = dishToEdit;
            InitializeComponent();
            BindDataEditDish(dishToEdit);
        }
        private void Edit_Dish_Load(object sender, EventArgs e)//Calls LoadDefaultTypeForDish
        {
            LoadDefaultTypeForDish();
        }
        private void LoadDefaultTypeForDish()//Ads dish category to ComoboBox.
        {
            comboBox1DishTypeEdit.Items.Add("Appetizer");
            comboBox1DishTypeEdit.Items.Add("Main");
            comboBox1DishTypeEdit.Items.Add("Dessert");
            comboBox1DishTypeEdit.Items.Add("Drink");
            comboBox1DishTypeEdit.SelectedIndex = 2;
        }
        private void BindDataEditDish(string myEditDish)//Binds the data of the Dish to be edited. Data is loaded from XML-Dishes.xml
        {

            foreach (XElement xe in (XDocument.Load(ma_controller.XmlParser.xmlDishPath).XPathSelectElements("//Dish")))
            {
                if (xe.Element("Name").Value.Equals(myEditDish))
                {
                    //AddButtonToCategoryAppetizer(xe.Element("Name").Value);
                    //comboBox1DishTypeEdit.SelectedIndex = 0;
                    //                    comboBox1DishTypeEdit.SelectedItem = xe.Element("Type").Value;
                    textBox1EditDishName.Text = xe.Element("Name").Value;
                    numericUpDown2DishEditSize.Text = xe.Element("Size").Value;
                    numericUpDown1EditDishPrice.Text = xe.Element("Price").Value;
                    textBox4DishDescriptonEdit.Text = xe.Element("Description").Value;
                    try
                    {
                        label7PathToImgDishEdit.Text = "Image loaded at: " + xe.Element("Image").Value;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }


            //DataSet DishLoad = new DataSet();
            //DishLoad.ReadXml(ma_controller.XmlParser.xmlDishPath);

            //textBox1EditDishName.DataBindings.Add("Text", DishLoad.Tables[0], "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            ////comboBox1DishTypeEdit.DataBindings.Add("Text",DishLoad.Tables[])
        }
        private void Button1EditDishImage_Click(object sender, EventArgs e)//Sets edited image path to Dish instance to be written.
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                // image file path  
                myDisToEdit.dishImage = open.FileName;
                label7PathToImgDishEdit.Text = $"* Image Loaded at: *{open.FileName}";

            }
        }
        private void Button2EditDish_Click(object sender, EventArgs e)
        {
            SetValuesToDishInstance();
            WriteInstanceToXml();
            this.Close();


        }
        private void SetValuesToDishInstance()//Sets values to the Dish instance to be written in the XML
        {
            myDisToEdit.dishType = comboBox1DishTypeEdit.SelectedItem.ToString();
            myDisToEdit.dishName = textBox1EditDishName.Text;
            var priceDish = Convert.ToInt32(numericUpDown1EditDishPrice.Value);
            myDisToEdit.dishPrice = priceDish;
            var sizeDish = Convert.ToInt32(numericUpDown2DishEditSize.Value);
            myDisToEdit.dishSize = sizeDish;
            myDisToEdit.dishDescription = textBox4DishDescriptonEdit.Text;
        }
        private void WriteInstanceToXml()//Writes instance to XML
        {

            var doc = XElement.Load(ma_controller.XmlParser.xmlDishPath);

            var dishEdition = doc.XPathSelectElements("//Dish").Where(c => c.Element("Name").Value == myDishToEditName).Single();
            dishEdition.SetElementValue("Name", myDisToEdit.dishName);
            dishEdition.SetElementValue("Price", myDisToEdit.dishPrice);
            dishEdition.SetElementValue("Size", myDisToEdit.dishSize);
            dishEdition.SetElementValue("Image", myDisToEdit.dishImage);
            dishEdition.SetElementValue("Type", myDisToEdit.dishType);
            dishEdition.SetElementValue("Description", myDisToEdit.dishDescription);
            //dishEdition.Element("balance").Value = "50";
            doc.Save(ma_controller.XmlParser.xmlDishPath);
            MessageBox.Show($"Your {myDisToEdit.dishName} dish has been edited.", "Edit created!");

        }
    }
}
