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
    public partial class ProfileEdit : Form
    {
        UserFromDb userFromDb = new UserFromDb();
        public ProfileEdit()
        {
            InitializeComponent();
        }

        private void ProfileEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = AuthorizationForm.currentUser.First_name;
            textBox2.Text = AuthorizationForm.currentUser.Last_name;
            textBox3.Text = AuthorizationForm.currentUser.Patronymic;
            dateTimePicker1.Value = AuthorizationForm.currentUser.Date_of_birthday;
            textBox4.Text = AuthorizationForm.currentUser.Phone;
            textBox5.Text = AuthorizationForm.currentUser.Adress;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            AuthorizationForm.currentUser.First_name = textBox1.Text;
            AuthorizationForm.currentUser.Last_name = textBox2.Text;
            AuthorizationForm.currentUser.Patronymic = textBox3.Text;
            AuthorizationForm.currentUser.Date_of_birthday = dateTimePicker1.Value;
            AuthorizationForm.currentUser.Phone = textBox4.Text;
            AuthorizationForm.currentUser.Adress = textBox5.Text;

            userFromDb.UserUpdateProfil(AuthorizationForm.currentUser);
            Close();
        }
    }
}
