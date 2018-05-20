using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BindingModels
{
	public class ProductBindingModel
	{
		public int ID { set; get; }
		
		public string ProductName { set; get; }

		public List<ProductRequirementBindingModel> ProductRequirements { get; set; }

		public List<ProductStorageBindingModel> ProductStorages { get; set; }
	}
}
