using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomException
{
    public partial class frmAddProduct : Form
    {
        // 5. In the frmAddProduct class, declare the variables and set an access modifier
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        // 9. Binding source declared
        private BindingSource showProductList;

        public frmAddProduct()
        {
            InitializeComponent();
            // Binding source initialized
            showProductList = new BindingSource();
        }

        // 8. Copy the methods in 03 Laboratory Exercise 2 – Method.txt file and paste it in the frmAddProduct class.
        // Exception added


        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new StringFormatException("Product name must only contain letters.");
            return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                throw new NumberFormatException("Quantity must only contain numbers.");
            return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                throw new CurrencyFormatException("Selling price must be a valid number.");
            return Convert.ToDouble(price);
        }

        // 10. Double click the Add Product button to generate a click event. Then, add the following code

        // challenge exercise : Exception handling added
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;

            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtProductName.Clear();
                cbCategory.SelectedIndex = -1;
                dtPickerMfgDate.Value = DateTime.Now;
                dtPickerExpDate.Value = DateTime.Now;
                richTxtDescription.Clear();
                txtQuantity.Clear();
                txtSellPrice.Clear();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        // 6. Double click the frmAddProduct form to generate a Load event
        // Create a string array named ListOfProductCategory.
        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[] {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };

            // 7. Write a foreach statement to show the data of the created string array inside the ComboBox
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }



        }
    }
}
