using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BindingModels
{
	public class ProductRequirementBindingModel
	{
		public int ID { set; get; }
		
		public int FoodId { set; get; }
		
		public int ProductId { set; get; }

		public int Count { set; get; }
	}
}
