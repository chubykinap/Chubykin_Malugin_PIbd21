using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Classes.ImplementationsBD
{
    public class TransferServiceBD : ITransferService
	{
		private ZooDbContex context;

		public TransferServiceBD()
		{
			this.context = new ZooDbContex();
		}

		public List<TransferViewModel> GetList()
		{
			List<TransferViewModel> result = context.Transfers
				.Select(rec => new TransferViewModel
				{
					ID = rec.ID,
					ProviderId = rec.ProviderId,
					AdminId = rec.AdminId,
					ProductId = rec.ProductId,
					DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
								SqlFunctions.DateName("mm", rec.DateCreate) + " " +
								SqlFunctions.DateName("yyyy", rec.DateCreate),
					Status = rec.Status.ToString(),
					ProductName = rec.Product.ProductName,
					Count = rec.Count
				})
				.ToList();
			return result;
		}

		public void CreateOrder(TransferBindingModel model)
		{
			context.Transfers.Add(new Transfer
			{
				ID = model.ID,
				ProviderId = model.ProviderId,
				AdminId = model.AdminId,
				ProductId = model.ProductId,
				DateCreate = DateTime.Now,
				Count = model.Count
			});
			context.SaveChanges();
		}

		public void TakeOrderInWork(int ID)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{

					Transfer element = context.Transfers.FirstOrDefault(rec => rec.ID == ID);
					if (element == null)
					{
						throw new Exception("Элемент не найден");
					}
					/*
                    var productComponents = context.ServiceResources
                                                .Where(rec => rec.serviceId == element.serviceId);
                    foreach (var productComponent in productComponents)
                    {
                        int countOnDelivers = productComponent.count;
                        var deliverComponents = context.DeliveryResources
                                                    .Where(rec => rec.resourceId == productComponent.resourceId);
                        foreach (var stockComponent in deliverComponents)
                        {
                            if (stockComponent.count >= countOnDelivers)
                            {
                                stockComponent.count -= countOnDelivers;
                                countOnDelivers = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnDelivers -= stockComponent.count;
                                stockComponent.count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnDelivers > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                productComponent.resource.resourceName + " требуется " +
                                productComponent.count + ", не хватает " + countOnDelivers);
                        }
                    }
                   */
					element.Status = ZooStatus.Выполняется;
					context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		public void FinishOrder(int ID)
		{
			Transfer element = context.Transfers.FirstOrDefault(rec => rec.ID == ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.Status = ZooStatus.Готово;
			context.SaveChanges();
		}

		public void PayOrder(int ID)
		{
/*			Transfer element = context.Transfers.FirstOrDefault(rec => rec.ID == ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.Status = ZooStatus.Оплачено;
			context.SaveChanges();*/
		}

		public void PutComponent(ProductStorageBindingModel model)
		{
			ProductStorage element = context.ProductStorages
												.FirstOrDefault(rec => rec.ProductId == model.ProductId &&
																	rec.StorageId == model.StorageId);
			if (element != null)
			{
				element.Count += model.Count;
			}
			else
			{
				context.ProductStorages.Add(new ProductStorage
				{
					ProductId = model.ProductId,
					StorageId = model.StorageId,
					Count = model.Count
				});
			}
			context.SaveChanges();
		}
	}
}
