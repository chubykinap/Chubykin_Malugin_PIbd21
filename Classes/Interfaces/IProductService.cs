using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface IProductService
	{
		List<ProductViewModel> GetList();

		ProductViewModel GetElement(int id);

		void AddElement(ProductBindingModel model);

		void UpdElement(ProductBindingModel model);

		void DelElement(int id);
	}
}
