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
    public partial class EditPassword : Form
    {
        UserFromDb userFromDb = new UserFromDb();
        public EditPassword()
        {
            InitializeComponent();
        }

        private void EditPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            { MessageBox.Show("Необходимо заполнить все поля!"); return; }
            bool rez = userFromDb.CheckPassword(textBox2.Text, textBox3.Text);
            if (!rez) return;
            else
            {
                try
                {
                    if(Verification.VerifySHA512Hash(textBox1.Text, AuthorizationForm.currentUser.password))
                    { userFromDb.EditPassword(textBox2.Text); }
                    else { MessageBox.Show("Старый пароль неверный"); return; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Close();
        }
    }
}
