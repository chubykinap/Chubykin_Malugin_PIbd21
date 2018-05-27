﻿using Classes.BindingModels;
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
	public partial class FormProduct : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		public int Id { set { ID = value; } }

		private readonly IProductService service;

		private int? ID;

		public FormProduct(IProductService service)
		{
			InitializeComponent();
			this.service = service;
		}

		private void FormProduct_Load(object sender, EventArgs e)
		{
			if (ID.HasValue)
			{
				try
				{
					ProductViewModel view = service.GetElement(ID.Value);
					if (view != null)
					{
						textBoxName.Text = view.ProductName;
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
					service.UpdElement(new ProductBindingModel
					{
						ID = ID.Value,
						ProductName = textBoxName.Text
					});
				}
				else
				{
					service.AddElement(new ProductBindingModel
					{
						ProductName = textBoxName.Text,
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
