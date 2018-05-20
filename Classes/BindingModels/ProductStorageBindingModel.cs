using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BindingModels
{
	public class ProductStorageBindingModel
	{
		public int ID { set; get; }
		
		public int StorageId { set; get; }
		
		public int ProductId { set; get; }

		public int Count { set; get; }
	}
}
