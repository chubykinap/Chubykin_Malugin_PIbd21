using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ImplementationsBD
{
    public class StorageServiceBD : IStorageService
	{
		private ZooDbContex context;

		public StorageServiceBD()
		{
			this.context = new ZooDbContex();
		}

		public List<StorageViewModel> GetList()
		{
			List<StorageViewModel> result = context.Storages
				.Select(rec => new StorageViewModel
				{
					ID = rec.Id,
					StorageName = rec.StorageName,
					ProductStorages = context.ProductStorages
							.Where(recPR => recPR.ProductId == rec.Id)
							.Select(recPR => new ProductStorageViewModel
							{
								ID = recPR.ID,
								ProductId = recPR.ProductId,
								StorageId = recPR.StorageId,
								Count = recPR.Count
							})
							.ToList()
				})
				.ToList();
			return result;
		}

		public StorageViewModel GetElement(int ID)
		{
			Storage element = context.Storages.FirstOrDefault(rec => rec.Id == ID);
			if (element != null)
			{
				return new StorageViewModel
				{
					ID = element.Id,
					ProductStorages = context.ProductStorages
							.Where(recPR => recPR.ProductId == element.Id)
							.Select(recPR => new ProductStorageViewModel
							{
								ID = recPR.ID,
								ProductId = recPR.ProductId,
								StorageId = recPR.StorageId,
								Count = recPR.Count
							})
							.ToList()
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(StorageBindingModel model)
		{
			Storage element = context.Storages.FirstOrDefault(rec => rec.Id != model.ID);
			context.Storages.Add(new Storage
			{
				StorageName = model.StorageName
			});
			context.SaveChanges();
		}

		public void UpdElement(StorageBindingModel model)
		{
			Storage element = context.Storages.FirstOrDefault(rec =>
										rec.Id != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			element = context.Storages.FirstOrDefault(rec => rec.Id == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.StorageName = model.StorageName;
			context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Storage element = context.Storages.FirstOrDefault(rec => rec.Id == ID);
					if (element != null)
					{
						context.ProductStorages.RemoveRange(
											context.ProductStorages.Where(rec => rec.ProductId == ID));
						context.Storages.Remove(element);
						context.SaveChanges();
					}
					else
					{
						throw new Exception("Элемент не найден");
					}
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
}
