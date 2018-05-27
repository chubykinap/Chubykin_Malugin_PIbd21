namespace WindowsFormView
{
	partial class FormPutOnStorage
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxTerm = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxStorage = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(265, 88);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// comboBoxTerm
			// 
			this.comboBoxTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTerm.FormattingEnabled = true;
			this.comboBoxTerm.Location = new System.Drawing.Point(88, 35);
			this.comboBoxTerm.Name = "comboBoxTerm";
			this.comboBoxTerm.Size = new System.Drawing.Size(252, 21);
			this.comboBoxTerm.TabIndex = 14;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Кол-во:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Компонент:";
			// 
			// comboBoxStorage
			// 
			this.comboBoxStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStorage.FormattingEnabled = true;
			this.comboBoxStorage.Location = new System.Drawing.Point(88, 6);
			this.comboBoxStorage.Name = "comboBoxStorage";
			this.comboBoxStorage.Size = new System.Drawing.Size(252, 21);
			this.comboBoxStorage.TabIndex = 11;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(184, 88);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 10;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(88, 62);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(252, 20);
			this.textBoxCount.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Склад:";
			// 
			// FormPutOnStorage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 123);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.comboBoxTerm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBoxStorage);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.label1);
			this.Name = "FormPutOnStorage";
			this.Text = "FormPutOnStorage";
			this.Load += new System.EventHandler(this.FormPutOnStorage_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboBoxTerm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxStorage;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label label1;
	}
}