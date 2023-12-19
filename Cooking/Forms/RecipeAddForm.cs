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
    public partial class RecipeAddForm : Form
    {
        int index;
        RecipeFromDB recipeFromDB = new RecipeFromDB();
        public RecipeAddForm()
        {
            InitializeComponent();
        }

        public RecipeAddForm(int index)
        {
            InitializeComponent();
            button2.Visible = false;
            this.index = index;
        }
        public RecipeAddForm(int index, string recipe)
        {
            InitializeComponent();
            button1.Visible = false;
            this.index = index;
            textBox1.Text = recipe;
        }

        private void RecipeAddForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recipeFromDB.AddRecipe(index, textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recipeFromDB.AddRecipe(index, textBox1.Text);
            this.Close();
        }
    }
}
