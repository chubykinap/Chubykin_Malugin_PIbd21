using Classes.BindingModels;
using Classes.ViewModels;
using System.Collections.Generic;

namespace Classes.Interfaces
{
    public interface IAdminService
	{
		List<AdminViewModel> GetList();

		AdminViewModel GetElement(int id);

		void AddElement(AdminBindingModel model);

		void UpdElement(AdminBindingModel model);

		void DelElement(int id);

        void TryEnter(AdminBindingModel model);
	}
}
