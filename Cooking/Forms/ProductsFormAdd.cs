using Cooking.Classes;
using Cooking.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cooking.Forms
{
    public partial class ProductsFormAdd : Form
    {
        ProductFromDB productFromDB = new ProductFromDB();
        public ProductsFormAdd()
        {
            InitializeComponent();
        }

        private void ProductsFormAdd_Load(object sender, EventArgs e)
        {

        }
        private bool CheckFields()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") { return true; }
            else { return false; }
        }
        private Product NewProduct()
        {
            Product newProduct = null;
            if (CheckFields())
            {
                newProduct = new Product(0, textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            }
            return newProduct;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Product product = NewProduct();
            productFromDB.AddProduct(product);
   
            Close();
        }
    }
}
