using Classes.Interfaces;
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
	public partial class FormMain : Form
	{
		[Dependency]
        public new IUnityContainer Container { get; set; }

		private readonly ITransferService service;

		public FormMain(ITransferService service)
		{
			InitializeComponent();
			this.service = service;
		}

		private void LoadData()
		{
			try
			{
	/*			List<TourOrderViewModel> list = service.GetList();
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].Visible = false;
					dataGridView.Columns[3].Visible = false;
					dataGridView.Columns[5].Visible = false;
					dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}*/
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void продуктыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormProducts>();
			form.ShowDialog();
		}

		private void складыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormStorages>();
			form.ShowDialog();
		}

		private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormPutOnStorage>();
			form.ShowDialog();
		}
	}
}
