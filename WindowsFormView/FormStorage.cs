using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace WindowsFormView
{
	public partial class FormStorage : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { ID = value; } }

		private readonly IStorageService service;

		private int? ID;

		public FormStorage(IStorageService service)
		{
			InitializeComponent();
			this.service = service;
		}

		private void FormStock_Load(object sender, EventArgs e)
		{
			if (ID.HasValue)
			{
				try
				{
					StorageViewModel view = service.GetElement(ID.Value);
					if (view != null)
					{
						textBoxName.Text = view.StorageName;
						dataGridView.DataSource = view.ProductStorages;
						dataGridView.Columns[0].Visible = false;
						dataGridView.Columns[1].Visible = false;
						dataGridView.Columns[2].Visible = false;
						dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				if (ID.HasValue)
				{
					service.UpdElement(new StorageBindingModel
					{
						ID = ID.Value,
						StorageName = textBoxName.Text
					});
				}
				else
				{
					service.AddElement(new StorageBindingModel
					{
						StorageName = textBoxName.Text
					});
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
