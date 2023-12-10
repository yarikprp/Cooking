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
                    äîáàâèòüÁëşäîToolStripMenuItem.Visible = false;
                    óäàëèòüÁëşäîToolStripMenuItem.Visible = false;
                    ïîëüçîâàòåëèToolStripMenuItem.Visible = false;
                    break;
                case 3:
                    äîáàâèòüToolStripMenuItem.Visible = false;
                    ïîëüçîâàòåëèToolStripMenuItem.Visible = false;
                    break;
            }
            ïåòğîâÂàñèëèéÏåòğîâè÷ToolStripMenuItem.Text = AuthorizationForm.currentUser.First_name + " " + AuthorizationForm.currentUser.Last_name;
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

        private void ïåòğîâÂàñèëèéÏåòğîâè÷ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ñìåíèòüÏàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPassword editPassword = new EditPassword();
            editPassword.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ğåäàêòèğîâàòüÏğîôèëüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileEdit profileEdit = new ProfileEdit();
            DialogResult result = profileEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                ïåòğîâÂàñèëèéÏåòğîâè÷ToolStripMenuItem.Text = AuthorizationForm.currentUser.First_name + " " + AuthorizationForm.currentUser.Last_name;
            }
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ñìåíèòüÏîëüçîâàòåëÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
            this.Hide();
        }

        private void ïîëüçîâàòåëèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
        private void ïğîäóêòToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ïğîñìîòğÏğîäóêòîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productsForm = new ProductForm();
            productsForm.Show();
        }

        private void äîáàâèòüToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void óäàëèòüÁëşäîToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
