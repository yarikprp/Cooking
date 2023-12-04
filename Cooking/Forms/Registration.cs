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
    public partial class Registration : Form
    {
        UserFromDb userFromDb = new UserFromDb();

        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            { MessageBox.Show("Необходимо заполнить все поля!"); return; }
            bool rez = userFromDb.CheckPassword(textBox4.Text, textBox5.Text);
            if (!rez) return;
            else
            if (userFromDb.CheckUser(textBox3.Text))
            {
                userFromDb.UserAdd(textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text);
            }
            else return;
            Close();
        }
    }
}
