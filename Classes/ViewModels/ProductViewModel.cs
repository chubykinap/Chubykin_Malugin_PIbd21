using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ViewModels
{
	public class ProductViewModel
	{
		public int ID { set; get; }

		public string ProductName { set; get; }

		public List<ProductRequirementViewModel> ProductRequirements { get; set; }

		public List<ProductStorageViewModel> ProductStorages { get; set; }
	}
}
