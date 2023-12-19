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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Cooking.Forms
{
    public partial class SearchBludForm : Form
    {
        public static List<Bludo> bludos = new List<Bludo>();
        BludaFromDB bludaFromDB = new BludaFromDB();

        public List<Product> products = new List<Product>();
        ProductFromDB productFromDB = new ProductFromDB();

        public SearchBludForm()
        {

            InitializeComponent();
            dataGridView1.Columns[0].DataPropertyName = "bludo_id";
            dataGridView1.Columns[1].DataPropertyName = "Image";
            dataGridView1.Columns[2].DataPropertyName = "bludo_name";
            dataGridView1.Columns[3].DataPropertyName = "category";
            dataGridView1.Columns[4].DataPropertyName = "osnova";
            dataGridView1.Columns[5].DataPropertyName = "vihod";

            dataGridView2.Columns[0].DataPropertyName = "products_id";
            dataGridView2.Columns[1].DataPropertyName = "products_name";
            dataGridView2.Columns[6].DataPropertyName = "belki";
            dataGridView2.Columns[7].DataPropertyName = "jiry";
            dataGridView2.Columns[8].DataPropertyName = "uglevody";

        }

        private void SearchBludForm_Load(object sender, EventArgs e)
        {
            ViewAllProducts();
            ViewAllBludos();
        }

        private void ViewAllProducts()
        {
            products = productFromDB.GetProducts();
            dataGridView2.DataSource = products;
        }

        private void ViewAllBludos()
        {
            bludos = bludaFromDB.LoadBludos();
            dataGridView1.DataSource = bludos;
        }

        private List<Product> Search()
        {
            List<Product> selectedProducts = new List<Product>();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Column9"];
                if (chk.Value != null && (bool)chk.Value == true)
                {
                    Product product = (Product)row.DataBoundItem;
                    selectedProducts.Add(product);
                }
            }

            return selectedProducts;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Product> selected = Search();
            if (selected.Count == 0)
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            bludos = bludaFromDB.FiltrBludosByProducts(selected);
            dataGridView1.DataSource = bludos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Product> selected = Search();
            if (selected.Count == 0)
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            bludos = bludaFromDB.FiltrBludosByProductsOff(selected);
            dataGridView1.DataSource = bludos;

        }
    }
}
