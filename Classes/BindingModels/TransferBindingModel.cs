using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BindingModels
{
	public class TransferBindingModel
	{
		public int ID { set; get; }

		public int AdminId { set; get; }

		public int ProviderId { set; get; }

		public int StorageId { set; get; }

		public string StorageName { get; set; }

		public int ProductId { set; get; }

		public string ProductName { get; set; }

		public int Count { get; set; }

		public DateTime DateCreate { get; set; }
	}
}
