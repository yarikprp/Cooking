using Cooking.Classes;
using Cooking.Model;
using Microsoft.VisualBasic.ApplicationServices;
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
using User = Cooking.Classes.User;

namespace Cooking.Forms
{
    public partial class Users : Form
    {
        UserFromDb userFromDb = new UserFromDb();
        List<User> users = new List<User>();

        RoleFromDB roleFromDB = new RoleFromDB();
        List<Role> roles = new List<Role>();
        private int selectedRowIndex;

        public Users()
        {
            InitializeComponent();

            dataGridView1.Columns[0].DataPropertyName = "user_id";
            dataGridView1.Columns[1].DataPropertyName = "first_name";
            dataGridView1.Columns[2].DataPropertyName = "last_name";
            dataGridView1.Columns[3].DataPropertyName = "patronymic";
            dataGridView1.Columns[4].DataPropertyName = "date_of_birthday";
            dataGridView1.Columns[5].DataPropertyName = "login";
            dataGridView1.Columns[6].DataPropertyName = "password";
            dataGridView1.Columns[7].DataPropertyName = "phone";
            dataGridView1.Columns[8].DataPropertyName = "adress";
            dataGridView1.Columns[9].DataPropertyName = "role_id";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            AllUsers();
            comboBox1.Items.AddRange(roles.ToArray());
        }
        private void AllUsers()
        {
            users = userFromDb.UsersLoad();
            dataGridView1.DataSource = users;
        }
        void DispalyUsers(int i)
        {
            textBox1.Text = users[i].first_name;
            textBox2.Text = users[i].last_name;
            textBox3.Text = users[i].patronymic;
            dateTimePicker1.Value = users[i].date_of_birthday;
            textBox4.Text = users[i].phone;
            textBox5.Text = users[i].adress;
            comboBox1.SelectedIndex = users[i].role_id - 1;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            AllUsers();
        }
        private User GetSelectedUser()
        {
            return (User)dataGridView1.SelectedRows[0].DataBoundItem;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                User removeUser = GetSelectedUser();
                string warrnigText = "Вы действительно хотите удалить пользователя " + removeUser.first_name + " " + removeUser.last_name + " ?";
                DialogResult result = MessageBox.Show(warrnigText, "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    userFromDb.DeleteUSer(removeUser);
                    AllUsers();
                }
            }
            else
                MessageBox.Show("Строка не выделена!");
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            { 
            selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            DispalyUsers(selectedRowIndex);
            }
            AllUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userFromDb.СhangeRole(users[selectedRowIndex], comboBox1.SelectedIndex + 1); 
            AllUsers();
            dataGridView1.DataSource = users;
        }
    }
}
