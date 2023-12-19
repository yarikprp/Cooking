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
    public partial class AddBludaForm : Form
    {
        string picFileName = "picture.jpg";
        ProductFromDB productFromDB = new ProductFromDB();
        BludaFromDB bludaFromDB = new BludaFromDB();
        public AddBludaForm()
        {
            InitializeComponent();
            dataGridView1.Columns[0].DataPropertyName = "Products_name";
            dataGridView1.Columns[1].DataPropertyName = "Weight";

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"..\..\Images\picture.jpg");
        }

        private void AddBludaForm_Load(object sender, EventArgs e)
        {
            combox1_Load();
            combox2_Load();
        }

        private void combox1_Load()
        {
            comboBox1.DataSource = MainForm.categoriya;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "Id";
        }

        private void combox2_Load()
        {
            comboBox2.DataSource = productFromDB.GetProducts();
            comboBox2.DisplayMember = "Products_name";
            comboBox2.ValueMember = "Products_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                picFileName = Path.GetFileName(ofd.FileName);
                string distinPath = @"..\..\Images\" + picFileName;

                if (!File.Exists(distinPath))
                {
                    fileInfo.CopyTo(distinPath);
                }
                pictureBox1.Image = Image.FromFile(distinPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!DuplicateRows(comboBox2.Text))
            {
                dataGridView1.Rows.Add(comboBox2.Text, textBox4.Text);
            }
        }
        private bool DuplicateRows(string selectProduct)
        {
            bool isDuplicateRows = false;

            if (dataGridView1 != null)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == selectProduct)
                    {
                        isDuplicateRows = true;
                        MessageBox.Show("Такой продукт уже есть в списке!");
                        break;
                    }
                }
            }
            return isDuplicateRows;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string picPath = @"..\..\Images\" + picFileName;

            Bludo newBludo = new Bludo(0, textBox1.Text, comboBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), picPath);

            List<SostavBluda> sostavBludas = new List<SostavBluda>();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sostavBludas.Add(new SostavBluda(0, dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value)));
            }

            bludaFromDB.AddNewBludo(newBludo, sostavBludas, (int)comboBox1.SelectedValue, picPath);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
