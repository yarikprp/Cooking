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
    public partial class RecipeForm : Form
    {
        public List<Bludo> bludos = new List<Bludo>();
        BludaFromDB bludaFromDB = new BludaFromDB();
        public List<SostavBluda> sostavBluda = new List<SostavBluda>();
        RecipeFromDB recipeFromDB = new RecipeFromDB();
        List<Recipe> recipes = new List<Recipe>();
        int index = 0;

        public RecipeForm()
        {
            InitializeComponent();
        }

        public RecipeForm(List<Bludo> bludos, List<SostavBluda> sostavBluda)
        {
            InitializeComponent();
            DefaultValues(bludos, sostavBluda);
        }
        private void DefaultValues(List<Bludo> bludos, List<SostavBluda> sostavBluda)
        {
            this.bludos = bludos;
            this.sostavBluda = sostavBluda;

            sostavBluda = bludaFromDB.SostavBludFromDB(bludos[0].Id);
            PrintSostavBluda(sostavBluda, bludos[0].BludoName);

            recipes = recipeFromDB.LoadRecipe(bludos[0].Id);
            Print(bludos[0].Id);
        }
        void PrintSostavBluda(List<SostavBluda> sostavBludas, string bludoName)
        {
            listBox1.Items.Clear();
            label2.Text = bludoName;
            foreach (SostavBluda item in sostavBludas)
            {
                listBox1.Items.Add(item.ProductName + ", " + item.Weight);
            }
        }
        void Print(int idBludo)
        {
            textBox1.Clear();
            foreach (Recipe item in recipes)
                textBox1.Text = item.Rezepty;
        }

        private void RecipeForm_Load(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                sostavBluda = bludaFromDB.SostavBludFromDB(bludos[index].Id);
                PrintSostavBluda(sostavBluda, bludos[index].BludoName);
                recipes = recipeFromDB.LoadRecipe(bludos[index].Id);
                Print(bludos[index].Id);
            }
            if (index == 0)
            {
                button5.Visible = false;
            }
            if (index < bludos.Count)
            {
                button4.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index++;
            if (index < bludos.Count)
            {
                sostavBluda = bludaFromDB.SostavBludFromDB(bludos[index].Id);
                PrintSostavBluda(sostavBluda, bludos[index].BludoName);
                recipes = recipeFromDB.LoadRecipe(bludos[index].Id);
                Print(bludos[index].Id);
            }
            if (index > 0)
            {
                button5.Visible = true;
            }
            if (index == bludos.Count - 1)
            {
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecipeAddForm recipeAddForm = new RecipeAddForm(bludos[index].Id);
            DialogResult result = recipeAddForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                recipes = recipeFromDB.LoadRecipe(bludos[index].Id);
                Print(bludos[index].Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecipeAddForm recipeAddForm = new RecipeAddForm(bludos[index].Id, textBox1.Text);
            DialogResult result = recipeAddForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                recipes = recipeFromDB.LoadRecipe(bludos[index].Id);
                Print(bludos[index].Id);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string warningText = "Вы действительно хотите удалить рецепт?";
            DialogResult result = MessageBox.Show(warningText, "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (bludos[index].Id == bludos.Count)
                {
                    recipeFromDB.DeleteRecipe(bludos[index].Id);
                    index = 0;
                    DefaultValues(bludos, sostavBluda);
                }
                else
                {
                    recipeFromDB.DeleteRecipe(bludos[index].Id);

                    index++;
                    sostavBluda = bludaFromDB.SostavBludFromDB(bludos[index].Id);
                    PrintSostavBluda(sostavBluda, bludos[index].BludoName);
                    recipes = recipeFromDB.LoadRecipe(bludos[index].Id);
                    Print(bludos[index].Id);
                }

            }
        }
    }
}
