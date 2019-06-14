using System;
using System.Windows.Forms;
using Main;
using MAIN_GUI_Mangaer_window.ma_controller;

namespace MAIN_GUI_Mangaer_window.ma_views
{
    /// <summary>
    /// Developed by Yonatan Orozko.
    /// </summary>
    public partial class CreateDish : Form
    {
        Dish myDish = new Dish();
        string imageDishCreatePath;
        public CreateDish()
        {
            InitializeComponent();
        }
        private void Button2Create_Click(object sender, EventArgs e)//Creates Sets the values to the Dish instance and write it to the XML file 
        {
            myDish.dishName = textBox1CreateDishName.Text;
            myDish.dishDescription = textBox4DishDescripton.Text;
            var priceDish = Convert.ToInt32(numericUpDown1CreDishPrice.Value);
            myDish.dishPrice = priceDish;
            myDish.dishSize = Convert.ToInt32(numericUpDown2DishCreateSize.Value);
            myDish.dishType = this.comboBox1DishType.SelectedItem.ToString();
            myDish.dishImage = imageDishCreatePath;
            XmlParser.XmlParserDish(myDish);
            MessageBox.Show($"Your {myDish.dishName} dish has been created.", "Dish created!");
            this.Close();
        }
        private void Button1CraDishImage_Click(object sender, EventArgs e)//Gets the path for the Dish image and Sets it to the Dish Instance
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // image file path  
                imageDishCreatePath = open.FileName;
                label7PathToImgDish.Text = $"* Image Loaded at: *{open.FileName}";
            }
        }
        private void CreateDish_Load(object sender, EventArgs e)//Sets the values for the combo box Dishes.
        {
            comboBox1DishType.Items.Add("Appetizer");
            comboBox1DishType.Items.Add("Main");
            comboBox1DishType.Items.Add("Dessert");
            comboBox1DishType.Items.Add("Drink");
        }
        private void Button3Cancel_Click(object sender, EventArgs e)//Close the form.
        {
            this.Close();
        }
    }
}
