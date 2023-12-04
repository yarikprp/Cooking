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
    public partial class AuthorizationForm : Form
    {
        UserFromDb userFromDb = new UserFromDb();
        public static User currentUser { get; set; } = null;
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text != "" && textBox2.Text != ""))
            {
                MessageBox.Show("Введите данные"); return;
            }
            else
            {
                currentUser = userFromDb.GetUser(textBox1.Text, textBox2.Text);
                if (currentUser != null)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Нет такого пользователя!"); return;
                }
            }
        }

        private void reg_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
