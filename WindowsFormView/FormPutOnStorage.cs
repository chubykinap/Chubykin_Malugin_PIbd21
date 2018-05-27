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
	public partial class FormPutOnStorage : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly IStorageService serviceS;

		private readonly IProductService serviceP;

		private readonly ITransferService serviceT;

		public FormPutOnStorage(IStorageService serviceS, IProductService serviceP, ITransferService serviceT)
		{
			InitializeComponent();
			this.serviceS = serviceS;
			this.serviceP = serviceP;
			this.serviceT = serviceT;
		}

		private void FormPutOnStorage_Load(object sender, EventArgs e)
		{
			try
			{
				List<ProductViewModel> listT = serviceP.GetList();
				if (listT != null)
				{
					comboBoxTerm.DisplayMember = "ProductName";
					comboBoxTerm.ValueMember = "Id";
					comboBoxTerm.DataSource = listT;
					comboBoxTerm.SelectedItem = null;
				}
				List<StorageViewModel> listS = serviceS.GetList();
				if (listS != null)
				{
					comboBoxStorage.DisplayMember = "StorageName";
					comboBoxStorage.ValueMember = "Id";
					comboBoxStorage.DataSource = listS;
					comboBoxStorage.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxTerm.SelectedValue == null)
			{
				MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxStorage.SelectedValue == null)
			{
				MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				serviceT.PutComponent(new ProductStorageBindingModel
				{
					ProductId = Convert.ToInt32(comboBoxTerm.SelectedValue),
					StorageId = Convert.ToInt32(comboBoxStorage.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text)
				});
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
