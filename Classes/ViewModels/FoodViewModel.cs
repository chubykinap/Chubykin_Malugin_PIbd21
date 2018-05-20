using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ViewModels
{
	public class FoodViewModel
	{
		public int ID { set; get; }

		public string FoodName { set; get; }

		public int something1 { set; get; }

		public int something2 { set; get; }

		public int something3 { set; get; }

		public List<ProductRequirementViewModel> ProductRequirements { get; set; }
	}
}
