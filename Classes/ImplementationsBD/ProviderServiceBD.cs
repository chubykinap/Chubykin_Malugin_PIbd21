using Classes.BindingModels;
using Classes.Interfaces;
using Classes.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ImplementationsBD
{
    public class ProviderServiceBD : IProviderService
	{
		private ZooDbContex context;

		public ProviderServiceBD()
		{
			this.context = new ZooDbContex();
		}

		public List<ProviderViewModel> GetList()
		{
			List<ProviderViewModel> result = context.Admins
				.Select(rec => new ProviderViewModel
				{
					ID = rec.ID,
					Login = rec.Login,
                    Password = rec.Password
                })
				.ToList();
			return result;
		}

		public ProviderViewModel GetElement(int ID)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				return new ProviderViewModel
				{
					ID = element.ID,
					Login = element.Login,
                    Password = element.Password
                };
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(ProviderBindingModel model)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.Login == model.Login);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			context.Admins.Add(new Admin
			{
				Login = model.Login,
                Password = model.Password
            });
			context.SaveChanges();
		}

		public void UpdElement(ProviderBindingModel model)
		{
			Provider element = context.Providers.FirstOrDefault(rec =>
										rec.Login == model.Login && rec.ID != model.ID);
			if (element != null)
			{
				throw new Exception("Уже есть сотрудник с таким ФИО");
			}
			element = context.Providers.FirstOrDefault(rec => rec.ID == model.ID);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			element.Login = model.Login;
            element.Password = model.Password;
            context.SaveChanges();
		}

		public void DelElement(int ID)
		{
			Provider element = context.Providers.FirstOrDefault(rec => rec.ID == ID);
			if (element != null)
			{
				context.Providers.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
	}
}
