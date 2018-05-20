using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.ImplementationsBD
{
	public class ProductServiceBD : IProductService
	{
		private ZooDbContex context;

		public ProductServiceBD(ZooDbContex context)
		{
			this.context = context;
		}

		public List<ProductViewModel> GetList()
		{
			List<ProductViewModel> result = context.Products
				.Select(rec => new ProductViewModel
				{
					ID = rec.ID,
					ProductName = rec.ProductName,
					ProductRequirements= context.ProductRequirements
							.Where(recPR => recPR.ProductId == rec.ID)
							.Select(recPR => new ProductRequirementViewModel
							{
								ID = recPR.ID,
								ProductId = recPR.ProductId,
								FoodId = recPR.FoodId,
								ProductName = recPR.Product.ProductName,
								Count = recPR.Count
							})
							.ToList()
				})
				.ToList();
			return result;
		}

		public ProductViewModel GetElement(int ID)
		{
			Product element = context.Products.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				return new ProductViewModel
				{
					ID = element.ID,
					ProductRequirements = context.ProductRequirements
							.Where(recPR => recPR.ProductId == element.ID)
							.Select(recPR => new ProductRequirementViewModel
							{
								ID = recPR.ID,
								ProductId = recPR.ProductId,
								FoodId = recPR.FoodId,
								ProductName = recPR.Product.ProductName,
								Count = recPR.Count
							})
							.ToList()
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(ProductBindingModel model)
		{
			Product element = context.Products.FirstOrDefault(rec => rec.ID != model.ID);
			context.Products.Add(new Product
			{
				ProductName = model.ProductName
			});
			context.SaveChanges();
		}

		public void UpdElement(ProductBindingModel model)
		{
			Product element = context.Products.FirstOrDefault(rec =>
										rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			element = context.Products.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.ProductName = model.ProductName;
			context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Product element = context.Products.FirstOrDefault(rec => rec.ID == ID);
					if (element != null)
					{
						context.ProductRequirements.RemoveRange(
											context.ProductRequirements.Where(rec => rec.ProductId == ID));
						context.Products.Remove(element);
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
