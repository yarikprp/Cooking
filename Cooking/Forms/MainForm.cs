using Cooking.Classes;
using Cooking.Forms;
using Cooking.Model;

namespace Cooking
{
    public partial class MainForm : Form
    {
        public List<Bludo> bludos = new List<Bludo>();
        BludaFromDB bludaFromDB = new BludaFromDB();

        public static List<Categoriya> categoriya = new List<Categoriya>();
        CategoriyaFromDB categoriyaFromDB = new CategoriyaFromDB();
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
            switch (AuthorizationForm.currentUser.role_id)
            {
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
            ïåòğîâÂàñèëèéÏåòğîâè÷ToolStripMenuItem.Text = AuthorizationForm.currentUser.first_name + " " + AuthorizationForm.currentUser.last_name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            BludaFromDB bludaFromDB = new BludaFromDB();
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
                ïåòğîâÂàñèëèéÏåòğîâè÷ToolStripMenuItem.Text = AuthorizationForm.currentUser.first_name + " " + AuthorizationForm.currentUser.last_name;
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
    }
}
