using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ViewModels
{
	public class TransferViewModel
	{
		public int ID { get; set; }

		public int AdminId { set; get; }

		public string LoginA { get; set; }

		public int ProviderId { set; get; }

		public string LoginP { get; set; }

		public int StorageId { set; get; }

		public string StorageName { get; set; }

		public int ProductId { set; get; }

		public string ProductName { get; set; }

		public int Count { get; set; }

		public string Status { get; set; }

		public string DateCreate { get; set; }
	}
}
