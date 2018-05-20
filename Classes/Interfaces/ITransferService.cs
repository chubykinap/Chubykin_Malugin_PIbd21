using Classes.BindingModels;
using Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
	public interface ITransferService
	{
		List<TransferViewModel> GetList();

		void CreateOrder(TransferBindingModel model);

		void TakeOrderInWork(int ID);

		void FinishOrder(int ID);

		void PayOrder(int ID);

		void PutComponent(ProductStorageBindingModel model);
	}
}
