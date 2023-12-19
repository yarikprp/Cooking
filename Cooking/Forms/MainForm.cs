using Cooking.Classes;
using Cooking.Forms;
using Cooking.Model;

namespace Cooking
{
    public partial class MainForm : Form
    {
        public List<Bludo> bludos = new List<Bludo>();
        public List<SostavBluda> sostavBlud = new List<SostavBluda>();
        BludaFromDB bludaFromDB = new BludaFromDB();

        public static List<Categoriya> categoriya = new List<Categoriya>();
        CategoriyaFromDB categoriyaFromDB = new CategoriyaFromDB();

        private int selectedRowIndex;
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Image";
            dataGridView1.Columns[2].DataPropertyName = "BludoName";
            dataGridView1.Columns[3].DataPropertyName = "Categoriya";
            dataGridView1.Columns[4].DataPropertyName = "Osnova";
            dataGridView1.Columns[5].DataPropertyName = "Vyhod";
            dataGridView1.Columns[0].Visible = false;
        }
        private void ViewAllBludos()
        {
            bludos = bludaFromDB.LoadBludos();
            dataGridView1.DataSource = bludos;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ViewAllBludos();

            categoriya = categoriyaFromDB.LoadCategoris();
            categoriya.Insert(0, new Categoriya(0, "Vse"));
            comboBox1.DataSource = categoriya;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "Id";
            switch (AuthorizationForm.currentUser.Role_id)
            {
                case 1:
                    break;
                case 2:
                    добавитьБлюдоToolStripMenuItem.Visible = false;
                    удалитьБлюдоToolStripMenuItem.Visible = false;
                    пользователиToolStripMenuItem.Visible = false;
                    break;
                case 3:
                    добавитьToolStripMenuItem.Visible = false;
                    пользователиToolStripMenuItem.Visible = false;
                    break;
            }
            петровВасилийПетровичToolStripMenuItem.Text = AuthorizationForm.currentUser.First_name + " " + AuthorizationForm.currentUser.Last_name;
        }
        public List<Bludo> SearchBludos(string textBox1)
        {
            List<Bludo> products = new List<Bludo>();
            foreach (Bludo item in bludos)
            {
                if (item.BludoName.StartsWith(textBox1) || item.Osnova.StartsWith(textBox1))
                {
                    products.Add(item);
                }
            }
            return products;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bludaFromDB.SearchBludos(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ViewAllBludos();
            }
            else
            {
                bludos = bludaFromDB.FilterBludosByCategory(Convert.ToInt32(comboBox1.SelectedValue));
                dataGridView1.DataSource = bludos;
            }
        }

        private void петровВасилийПетровичToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сменитьПаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPassword editPassword = new EditPassword();
            editPassword.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void редактироватьПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileEdit profileEdit = new ProfileEdit();
            DialogResult result = profileEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                петровВасилийПетровичToolStripMenuItem.Text = AuthorizationForm.currentUser.First_name + " " + AuthorizationForm.currentUser.Last_name;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
            this.Hide();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
        private void продуктToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void просмотрПродуктоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productsForm = new ProductForm();
            productsForm.Show();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsFormAdd productsFormAdd = new ProductsFormAdd();
            productsFormAdd.Show();
        }
        void PrintSostavBluda(List<SostavBluda> sostavBludas, string BludoName)
        {
            ClearSostavBluda();

            label5.Text = BludoName;

            foreach (SostavBluda item in sostavBludas)
            {
                listBox1.Items.Add(item.ProductName + ", " + item.Weight);
            }
        }
        void ClearSostavBluda()
        {
            listBox1.Items.Clear();
            label5.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedRowIndex = dataGridView1.CurrentRow.Index;
            sostavBlud = bludaFromDB.SostavBludFromDB(bludos[selectedRowIndex].Id);
            PrintSostavBluda(sostavBlud, bludos[selectedRowIndex].BludoName);
        }
        private Bludo GetSelectedBludo()
        {
            return (Bludo)dataGridView1.SelectedRows[0].DataBoundItem;
        }

        private void удалитьБлюдоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Bludo removeBludo = GetSelectedBludo();
                string warrnigText = "Вы действительно хотите удалить блюдо: " + removeBludo.BludoName + " ?";
                DialogResult result = MessageBox.Show(warrnigText, "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    bludaFromDB.DeleteBludo(removeBludo);
                    dataGridView1.DataSource = bludaFromDB.LoadBludos();
                }
            }
            else
                MessageBox.Show("Строка не выделена!");
            listBox1.Items.Clear();
            label1.Text = "";
            textBox1.Clear();
        }

        private void добавитьБлюдоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBludaForm addBludaForm = new AddBludaForm();
            addBludaForm.ShowDialog();
            dataGridView1.DataSource = bludaFromDB.LoadBludos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void рецептToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecipeForm recipeForm = new RecipeForm(bludos, sostavBlud);
            recipeForm.ShowDialog();
        }

        private void поискПоКритериямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBludForm search = new SearchBludForm();
            search.ShowDialog();
        }
    }
}
