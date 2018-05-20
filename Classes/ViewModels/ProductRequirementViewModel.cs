using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ViewModels
{
	public class ProductRequirementViewModel
	{
		public int ID { set; get; }

		public int FoodId { set; get; }

		public int ProductId { set; get; }

		public int Count { set; get; }

		public string ProductName { set; get; }

		public string FoodName { set; get; }
	}
}
