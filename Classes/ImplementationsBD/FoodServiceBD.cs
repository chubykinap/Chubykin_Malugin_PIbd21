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

		public FoodServiceBD()
		{
			this.context = new ZooDbContex();
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
			Food Product = context.Foods.FirstOrDefault(rec => rec.ID == ID);
			if (Product != null)
			{
				return new FoodViewModel
				{
					ID = Product.ID,
					ProductRequirements = context.ProductRequirements
							.Where(recPR => recPR.ProductId == Product.ID)
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
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Food Product = context.Foods.FirstOrDefault(rec => rec.FoodName == model.FoodName);
                    if (Product != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    Product = new Food
                    {
                        FoodName = model.FoodName
                    };
                    context.Foods.Add(Product);
                    context.SaveChanges();
                    var groupProducts = model.ElementRequirement
                                                .GroupBy(rec => rec.ProductId)
                                                .Select(rec => new
                                                {
                                                    ProductID = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupProduct in groupProducts)
                    {
                        context.ProductRequirements.Add(new ProductRequirement
                        {
                            FoodId = Product.ID,
                            ProductId = groupProduct.ProductID
                        });
                        context.SaveChanges();
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

		public void UpdElement(FoodBindingModel model)
		{
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Food Product = context.Foods.FirstOrDefault(rec =>
                                        rec.FoodName == model.FoodName && rec.ID != model.ID);
                    if (Product != null)
                    {
                        throw new Exception("Уже есть питание с таким названием");
                    }
                    Product = context.Foods.FirstOrDefault(rec => rec.ID == model.ID);
                    if (Product == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    Product.FoodName = model.FoodName;
                    context.SaveChanges();

                    var compIDs = model.ElementRequirement.Select(rec => rec.ProductId).Distinct();
                    var updateProducts = context.ProductRequirements
                                                    .Where(rec => rec.FoodId == model.ID &&
                                                        compIDs.Contains(rec.ProductId));
                    foreach (var updateProduct in updateProducts)
                    {
                        updateProduct.Count = model.ElementRequirement
                                                        .FirstOrDefault(rec => rec.ID == updateProduct.ID).Count;
                    }
                    context.SaveChanges();
                    context.ProductRequirements.RemoveRange(
                                        context.ProductRequirements.Where(rec => rec.FoodId == model.ID &&
                                                                            !compIDs.Contains(rec.ProductId)));
                    context.SaveChanges();
                    var groupProducts = model.ElementRequirement
                                                .Where(rec => rec.ID == 0)
                                                .GroupBy(rec => rec.ProductId)
                                                .Select(rec => new
                                                {
                                                    ProductID = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupProduct in groupProducts)
                    {
                        ProductRequirement ProductPC = context.ProductRequirements
                                                .FirstOrDefault(rec => rec.FoodId == model.ID &&
                                                                rec.ProductId == groupProduct.ProductID);
                        if (ProductPC != null)
                        {
                            context.SaveChanges();
                        }
                        else
                        {
                            context.ProductRequirements.Add(new ProductRequirement
                            {
                                FoodId = model.ID,
                                ProductId = groupProduct.ProductID
                            });
                            context.SaveChanges();
                        }
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

		public void DelElement(int ID)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Food Product = context.Foods.FirstOrDefault(rec => rec.ID == ID);
					if (Product != null)
					{
						context.ProductRequirements.RemoveRange(
											context.ProductRequirements.Where(rec => rec.FoodId == ID));
						context.Foods.Remove(Product);
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
