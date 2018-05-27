using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ImplementationsBD
{
    public class FoodServiceBD : IFoodService
	{
		private ZooDbContex context;

		public FoodServiceBD(ZooDbContex context)
		{
			this.context = context;
		}

		public List<FoodViewModel> GetList()
		{
			List<FoodViewModel> result = context.Foods
				.Select(rec => new FoodViewModel
				{
					ID = rec.ID,
					FoodName = rec.FoodName,
					ProductRequirements = context.ProductRequirements
							.Where(recPR => recPR.ProductId == rec.ID)
							.Select(recPR => new ProductRequirementViewModel
							{
								ID = recPR.ID,
								ProductId = recPR.ProductId,
								FoodId = recPR.FoodId,
								ProductName = recPR.Product.ProductName,
								FoodName = recPR.Food.FoodName,
								Count = recPR.Count
							})
							.ToList()
				})
				.ToList();
			return result;
		}

		public FoodViewModel GetElement(int ID)
		{
			Food element = context.Foods.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				return new FoodViewModel
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
								FoodName = recPR.Food.FoodName,
								Count = recPR.Count
							})
							.ToList()
				};
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(FoodBindingModel model)
		{
			Food element = context.Foods.FirstOrDefault(rec => rec.ID != model.ID);
			context.Foods.Add(new Food
			{
				FoodName = model.FoodName
			});
			context.SaveChanges();
		}

		public void UpdElement(FoodBindingModel model)
		{
			Food element = context.Foods.FirstOrDefault(rec =>
										rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			element = context.Foods.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.FoodName = model.FoodName;
			context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Food element = context.Foods.FirstOrDefault(rec => rec.ID == ID);
					if (element != null)
					{
						context.ProductRequirements.RemoveRange(
											context.ProductRequirements.Where(rec => rec.FoodId == ID));
						context.Foods.Remove(element);
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
