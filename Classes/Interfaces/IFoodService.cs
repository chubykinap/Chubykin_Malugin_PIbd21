using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface IFoodService
	{
		List<FoodViewModel> GetList();

		FoodViewModel GetElement(int id);

		void AddElement(FoodBindingModel model);

		void UpdElement(FoodBindingModel model);

		void DelElement(int id);
	}
}
