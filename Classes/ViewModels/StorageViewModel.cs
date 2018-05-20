using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ViewModels
{
	public class StorageViewModel
	{
		public int ID { get; set; }

		public string StorageName { get; set; }

		public List<ProductStorageViewModel> ProductStorages { get; set; }
	}
}
