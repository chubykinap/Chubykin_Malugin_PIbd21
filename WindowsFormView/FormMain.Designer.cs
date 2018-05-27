namespace WindowsFormView
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.зоопарЮрскийПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.продуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonCreateOrder = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зоопарЮрскийПериодToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// зоопарЮрскийПериодToolStripMenuItem
			// 
			this.зоопарЮрскийПериодToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.продуктыToolStripMenuItem,
            this.складыToolStripMenuItem});
			this.зоопарЮрскийПериодToolStripMenuItem.Name = "зоопарЮрскийПериодToolStripMenuItem";
			this.зоопарЮрскийПериодToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
			this.зоопарЮрскийПериодToolStripMenuItem.Text = "Зоопарк \"Юрский период\"";
			// 
			// продуктыToolStripMenuItem
			// 
			this.продуктыToolStripMenuItem.Name = "продуктыToolStripMenuItem";
			this.продуктыToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.продуктыToolStripMenuItem.Text = "Продукты";
			this.продуктыToolStripMenuItem.Click += new System.EventHandler(this.продуктыToolStripMenuItem_Click);
			// 
			// складыToolStripMenuItem
			// 
			this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
			this.складыToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.складыToolStripMenuItem.Text = "Склады";
			this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
			// 
			// пополнитьСкладToolStripMenuItem
			// 
			this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
			this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
			this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
			this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 44);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(656, 366);
			this.dataGridView1.TabIndex = 1;
			// 
			// buttonCreateOrder
			// 
			this.buttonCreateOrder.Location = new System.Drawing.Point(674, 44);
			this.buttonCreateOrder.Name = "buttonCreateOrder";
			this.buttonCreateOrder.Size = new System.Drawing.Size(114, 23);
			this.buttonCreateOrder.TabIndex = 2;
			this.buttonCreateOrder.Text = "Создать заказ";
			this.buttonCreateOrder.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(674, 73);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "От";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(674, 102);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(114, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(674, 131);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(114, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttonCreateOrder);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMain";
			this.Text = "FormMain";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem зоопарЮрскийПериодToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem продуктыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonCreateOrder;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}