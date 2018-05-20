using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BindingModels
{
	public class FoodBindingModel
	{
		public int ID { set; get; }

		public string FoodName { set; get; }

		public int something1 { set; get; }
		
		public int something2 { set; get; }
		
		public int something3 { set; get; }

		public List<ProductRequirementBindingModel> ProductRequirements { get; set; }
	}
}
