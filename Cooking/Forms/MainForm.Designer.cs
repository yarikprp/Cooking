namespace Cooking
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            блюдаToolStripMenuItem = new ToolStripMenuItem();
            просмотрБлюдToolStripMenuItem = new ToolStripMenuItem();
            добавитьБлюдоToolStripMenuItem = new ToolStripMenuItem();
            удалитьБлюдоToolStripMenuItem = new ToolStripMenuItem();
            продуктToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            рецептToolStripMenuItem = new ToolStripMenuItem();
            петровВасилийПетровичToolStripMenuItem = new ToolStripMenuItem();
            редактироватьПрофильToolStripMenuItem = new ToolStripMenuItem();
            сменитьПаToolStripMenuItem = new ToolStripMenuItem();
            сменитьПользователяToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            Column0 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            listBox1 = new ListBox();
            пользователиToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { блюдаToolStripMenuItem, продуктToolStripMenuItem, рецептToolStripMenuItem, петровВасилийПетровичToolStripMenuItem, пользователиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1038, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // блюдаToolStripMenuItem
            // 
            блюдаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { просмотрБлюдToolStripMenuItem, добавитьБлюдоToolStripMenuItem, удалитьБлюдоToolStripMenuItem });
            блюдаToolStripMenuItem.Image = Properties.Resources.dish;
            блюдаToolStripMenuItem.Name = "блюдаToolStripMenuItem";
            блюдаToolStripMenuItem.Size = new Size(88, 24);
            блюдаToolStripMenuItem.Text = "Блюда";
            // 
            // просмотрБлюдToolStripMenuItem
            // 
            просмотрБлюдToolStripMenuItem.Name = "просмотрБлюдToolStripMenuItem";
            просмотрБлюдToolStripMenuItem.Size = new Size(209, 26);
            просмотрБлюдToolStripMenuItem.Text = "Просмотр блюд";
            // 
            // добавитьБлюдоToolStripMenuItem
            // 
            добавитьБлюдоToolStripMenuItem.Name = "добавитьБлюдоToolStripMenuItem";
            добавитьБлюдоToolStripMenuItem.Size = new Size(209, 26);
            добавитьБлюдоToolStripMenuItem.Text = "Добавить блюдо";
            // 
            // удалитьБлюдоToolStripMenuItem
            // 
            удалитьБлюдоToolStripMenuItem.Name = "удалитьБлюдоToolStripMenuItem";
            удалитьБлюдоToolStripMenuItem.Size = new Size(209, 26);
            удалитьБлюдоToolStripMenuItem.Text = "Удалить блюдо";
            // 
            // продуктToolStripMenuItem
            // 
            продуктToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem });
            продуктToolStripMenuItem.Image = Properties.Resources.diet;
            продуктToolStripMenuItem.Name = "продуктToolStripMenuItem";
            продуктToolStripMenuItem.Size = new Size(100, 24);
            продуктToolStripMenuItem.Text = "Продукт";
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(159, 26);
            добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // рецептToolStripMenuItem
            // 
            рецептToolStripMenuItem.Image = Properties.Resources.recipe;
            рецептToolStripMenuItem.Name = "рецептToolStripMenuItem";
            рецептToolStripMenuItem.Size = new Size(91, 24);
            рецептToolStripMenuItem.Text = "Рецепт";
            // 
            // петровВасилийПетровичToolStripMenuItem
            // 
            петровВасилийПетровичToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            петровВасилийПетровичToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { редактироватьПрофильToolStripMenuItem, сменитьПаToolStripMenuItem, сменитьПользователяToolStripMenuItem, выходToolStripMenuItem });
            петровВасилийПетровичToolStripMenuItem.Image = Properties.Resources.profil;
            петровВасилийПетровичToolStripMenuItem.Name = "петровВасилийПетровичToolStripMenuItem";
            петровВасилийПетровичToolStripMenuItem.Size = new Size(229, 24);
            петровВасилийПетровичToolStripMenuItem.Text = "Петров Василий Петрович";
            петровВасилийПетровичToolStripMenuItem.Click += MainForm_Load;
            // 
            // редактироватьПрофильToolStripMenuItem
            // 
            редактироватьПрофильToolStripMenuItem.Name = "редактироватьПрофильToolStripMenuItem";
            редактироватьПрофильToolStripMenuItem.Size = new Size(260, 26);
            редактироватьПрофильToolStripMenuItem.Text = "Редактировать профиль";
            редактироватьПрофильToolStripMenuItem.Click += редактироватьПрофильToolStripMenuItem_Click;
            // 
            // сменитьПаToolStripMenuItem
            // 
            сменитьПаToolStripMenuItem.Name = "сменитьПаToolStripMenuItem";
            сменитьПаToolStripMenuItem.Size = new Size(260, 26);
            сменитьПаToolStripMenuItem.Text = "Сменить пароль";
            сменитьПаToolStripMenuItem.Click += сменитьПаToolStripMenuItem_Click;
            // 
            // сменитьПользователяToolStripMenuItem
            // 
            сменитьПользователяToolStripMenuItem.Name = "сменитьПользователяToolStripMenuItem";
            сменитьПользователяToolStripMenuItem.Size = new Size(260, 26);
            сменитьПользователяToolStripMenuItem.Text = "Сменить пользователя";
            сменитьПользователяToolStripMenuItem.Click += сменитьПользователяToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(260, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(440, 58);
            label1.Name = "label1";
            label1.Size = new Size(112, 41);
            label1.TabIndex = 1;
            label1.Text = "Меню";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 131);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 2;
            label2.Text = "Поиск блюда";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(444, 131);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 3;
            label3.Text = "Категория";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(797, 180);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 4;
            label4.Text = "Состав блюда";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(929, 180);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 5;
            label5.Text = "название";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 124);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 27);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Zakyski", "Syp", "Goryachee", "Desert", "Napitok" });
            comboBox1.Location = new Point(531, 123);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column0, Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(12, 183);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(676, 368);
            dataGridView1.TabIndex = 8;
            // 
            // Column0
            // 
            Column0.HeaderText = "id";
            Column0.MinimumWidth = 6;
            Column0.Name = "Column0";
            Column0.Width = 6;
            // 
            // Column1
            // 
            Column1.FillWeight = 200F;
            Column1.HeaderText = "Картинка";
            Column1.Image = Properties.Resources.recipe;
            Column1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            Column1.Width = 80;
            // 
            // Column2
            // 
            Column2.HeaderText = "Название";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Категория";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Основа";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Вес";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(797, 224);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(219, 204);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // пользователиToolStripMenuItem
            // 
            пользователиToolStripMenuItem.Image = Properties.Resources.profil;
            пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            пользователиToolStripMenuItem.Size = new Size(142, 24);
            пользователиToolStripMenuItem.Text = "Пользователи";
            пользователиToolStripMenuItem.Click += пользователиToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 563);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Кафе";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem блюдаToolStripMenuItem;
        private ToolStripMenuItem просмотрБлюдToolStripMenuItem;
        private ToolStripMenuItem добавитьБлюдоToolStripMenuItem;
        private ToolStripMenuItem удалитьБлюдоToolStripMenuItem;
        private ToolStripMenuItem продуктToolStripMenuItem;
        private ToolStripMenuItem рецептToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private ListBox listBox1;
        private DataGridViewTextBoxColumn Column0;
        private DataGridViewImageColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem петровВасилийПетровичToolStripMenuItem;
        private ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private ToolStripMenuItem сменитьПользователяToolStripMenuItem;
        private ToolStripMenuItem сменитьПаToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem пользователиToolStripMenuItem;
    }
}
