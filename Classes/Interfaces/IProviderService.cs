using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface IProviderService
	{
		List<ProviderViewModel> GetList();

		ProviderViewModel GetElement(int id);

		void AddElement(ProviderBindingModel model);

		void UpdElement(ProviderBindingModel model);

		void DelElement(int id);
	}
}
