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

namespace Cooking.Forms
{
    public partial class ProductForm : Form
    {
        ProductFromDB productFromDB = new ProductFromDB();
        List<ProductForm> products = new List<ProductForm>();
        List<Product> products1 = new List<Product>();
        public ProductForm()
        {
            InitializeComponent();

            dataGridView1.Columns[0].DataPropertyName = "products_id";
            dataGridView1.Columns[1].DataPropertyName = "products_name";
            dataGridView1.Columns[2].DataPropertyName = "belki";
            dataGridView1.Columns[3].DataPropertyName = "jiry";
            dataGridView1.Columns[4].DataPropertyName = "uglevody";
            dataGridView1.Columns[0].Visible = false;
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
           products1 = productFromDB.GetProducts();
           dataGridView1.DataSource= products1;
        }
        public List<Product> SeachProduct(string textBox1)
        {
            List<Product> products = new List<Product>();
            foreach (Product item in products1)
            {
                if (item.Products_name.StartsWith(textBox1))
                {
                    products.Add(item);
                }
            }
            return products;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              dataGridView1.DataSource = SeachProduct(textBox1.Text); 
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProductsFormAdd productsFormAdd = new ProductsFormAdd();
            DialogResult dialogResult = productsFormAdd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                dataGridView1.DataSource = productFromDB.GetProducts();
            }
            dataGridView1.DataSource = productFromDB.GetProducts();
        }

        private Product GetSelectedProduct()
        {
            return (Product)dataGridView1.SelectedRows[0].DataBoundItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Product removeProduct = GetSelectedProduct();
                string warrnigText = "Вы действительно хотите удалить продукт " + removeProduct.Products_name + " ?";
                DialogResult result = MessageBox.Show(warrnigText, "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    productFromDB.DeleteProduct(removeProduct);
                    dataGridView1.DataSource = productFromDB.GetProducts();
                }
            }
            else
                MessageBox.Show("Строка не выделена!");
        }
    }
}
