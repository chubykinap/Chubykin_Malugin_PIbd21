using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface IAdminService
	{
		List<AdminViewModel> GetList();

		AdminViewModel GetElement(int id);

		void AddElement(AdminBindingModel model);

		void UpdElement(AdminBindingModel model);

		void DelElement(int id);
	}
}
